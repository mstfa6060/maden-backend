using Arfware.ArfBlocks.Core;
using Arfware.ArfBlocks.Core.Exceptions;
using Common.Definitions.Base.Entity;
using Common.Definitions.Domain.Entities;
using Common.Definitions.Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;
using Common.Definitions.Domain.Errors;
using Common.Services.Environment;
using Common.Services.Auth.CurrentUser;

namespace Common.Services.Auth.Authorization;

public partial class AuthorizationService : IAuthorizationService
{
    private readonly DefinitionDbContext _dbContext;

    private readonly CurrentUserService _currentUserService;
    private Resource resource;
    private readonly EnvironmentService _environmentService;
    private bool _isLogginEnabled = false;
    private bool _verifyActor = false;
    private bool _verifyTenant = false;
    private string _nspace = "";
    private Guid _entityId = Guid.Empty;
    private Type _entityType;

    public AuthorizationService(ArfBlocksDependencyProvider dependencyProvider)
    {
        var commonDbContext = dependencyProvider.GetInstance<DbContext>();
        _dbContext = (DefinitionDbContext)commonDbContext;
        _currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
        _environmentService = dependencyProvider.GetInstance<EnvironmentService>(); ;
    }

    public void EnableLogEverything()
    {
        this._isLogginEnabled = true;
    }
    public void DisableLogEverything()
    {
        this._isLogginEnabled = false;
    }
    private void Log(string message)
    {
        if (_isLogginEnabled)
            System.Console.WriteLine($"[{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}] {message}");
    }

    public IAuthorizationService VerifyActor()
    {
        this._verifyActor = true;
        return this;
    }

    public IAuthorizationService ForResource(string nspace)
    {
        this._nspace = nspace;
        return this;
    }

    public IAuthorizationService ForResource<T>() where T : class
    {
        this._nspace = typeof(T).Namespace;
        return this;
    }

    public IAuthorizationService VerifyTenant<TEntity>(Guid entityId) where TEntity : CoreEntity, ITenantEntity
    {
        this._verifyTenant = true;
        this._entityId = entityId;
        this._entityType = typeof(TEntity);
        return this;
    }

    private async Task<Exception> Run()
    {
        // TODO: Seeder geldigi zaman kaldirilacak
        if (_environmentService.Environment == CustomEnvironments.Test)
            return null;

        resource = await _dbContext.AppResources.Include(a => a.Module).FirstOrDefaultAsync(e => e.Namespace == this._nspace);
        if (resource == null)
            return new ArfBlocksVerificationException(ErrorCodeGenerator.ErrorCodeGenerator.GetErrorCode(() => DomainErrors.AuthorizationServiceErrors.NamespaceNotFound));

        if (this._verifyTenant)
        {
            Log("Verify Tenant 1");
            var isTenantOperationPermitted = await this.IsTenantOperationPermitted(resource, _entityId, _entityType);
            if (!isTenantOperationPermitted)
            {
                return new ArfBlocksVerificationException(ErrorCodeGenerator.ErrorCodeGenerator.GetErrorCode(() => DomainErrors.AuthorizationServiceErrors.UserDoesNotHaveSufficientPermission));
            }
        }

        if (this._verifyActor && !this._verifyTenant)
        {
            var isUserBanned = await this.IsUserBanned();
            if (isUserBanned)
            {
                return new ArfBlocksVerificationException(ErrorCodeGenerator.ErrorCodeGenerator.GetErrorCode(() => DomainErrors.AuthorizationServiceErrors.UserIsBanned));
            }

            var isPermitted = await this.IsPermitted(resource);
            if (!isPermitted)
            {
                return new ArfBlocksVerificationException(ErrorCodeGenerator.ErrorCodeGenerator.GetErrorCode(() => DomainErrors.AuthorizationServiceErrors.UserDoesNotHaveSufficientPermission));
            }
        }

        return null;
    }

    public async Task Assert()
    {
        var exception = await Run();
        if (exception != null)
            throw exception;
    }

    public async Task<bool> Verify()
    {
        var exception = await Run();
        if (exception != null)
            return false;

        return true;
    }

    public Task<bool> IsFakeRegisteredUser()
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUserBanned()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsSystemAdmin(ModuleTypes moduleType)
    {
        var currentUserId = _currentUserService.GetCurrentUserId();

        return await _dbContext.AppSystemAdmins
            .Include(a => a.RelSystemUserModules)
            .ThenInclude(s => s.Module)
            .AnyAsync(s => s.UserId == currentUserId
                        && s.IsActive
                        && (
                            s.IsAllModulePermitted
                            || s.RelSystemUserModules.Any(r => r.Module.ModuleType == moduleType)
                        ));
    }



    private async Task<bool> IsTenantOperationPermitted(Resource resource, Guid entityId, Type entityType)
    {
        var isUserBanned = await this.IsUserBanned();
        if (isUserBanned)
        {
            throw new ArfBlocksVerificationException(ErrorCodeGenerator.ErrorCodeGenerator.GetErrorCode(() => DomainErrors.AuthorizationServiceErrors.UserIsBanned));
        }

        var isSystemAdmin = await IsSystemAdmin(resource.Module.ModuleType);
        if (isSystemAdmin)
        {
            return true;
        }

        if (resource.IsEveryoneAllowed)
        {
            Log("resource IsEveryoneAllowed");
            return true;
        }

        var obj = await _dbContext.FindAsync(entityType, entityId);
        object tempObj = null;
        do
        {
            if (tempObj != null)
            {
                obj = tempObj;
            }

            var tenantPropertyName = ((ITenantEntity)obj).GetTenantPropertyName();

            if (!string.IsNullOrEmpty(tenantPropertyName))
            {
                await _dbContext.Entry(obj)
                                    .Reference(tenantPropertyName)
                                    .LoadAsync();
            }

            tempObj = ((ITenantEntity)obj).GetTenantEntity();
        } while (tempObj != null);
        var entityTenantId = ((ITenantEntity)obj).GetTenantId();

        Log("EntityTenantId: " + entityTenantId);

        if (resource.IsEndUserPermitted)
        {
            Log("resource.IsEndUserPermitted");
            var currentUserId = _currentUserService.GetCurrentUserId();

            var isUserAuthorized = await _dbContext.AppResources.AnyAsync(a => a.Id == resource.Id);

            Log($"is user authorized:{isUserAuthorized}");

            return isUserAuthorized;
        }
        System.Console.WriteLine("NOOOOOOOO");
        return false;
    }



    private async Task<bool> IsPermitted(Resource resource)
    {
        if (resource.IsEveryoneAllowed)
        {
            Log("resource IsEveryoneAllowed");
            return true;
        }

        if (resource.IsSystemAdminPermitted)
        {
            var isSystemAdmin = await IsSystemAdmin(resource.Module.ModuleType);
            if (isSystemAdmin)
            {
                Log("current User is Sytem Admin");
                return true;
            }
        }

        if (resource.IsEndUserPermitted)
        {
            var currentUserId = _currentUserService.GetCurrentUserId();
            var isUserAuthorized = await _dbContext.AppResources.AnyAsync(a => a.Id == resource.Id);
            Log($"is user authorized:{isUserAuthorized}");

            return isUserAuthorized;
        }

        return false;
    }

    public async Task<bool> HasNamespacePermission(Guid userId, string namespacePath)
    {
        var roleId = await _dbContext.UserRoles
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.RoleId)
            .FirstOrDefaultAsync();

        if (roleId == null)
            return false;

        var hasPermission = await _dbContext.RolePermissions
            .AnyAsync(rp => rp.RoleId == roleId && rp.Permission == namespacePath);

        return hasPermission;
    }

    public async Task CheckAccess(Guid userId, string permission)
    {
        // Kullanıcının rol ID'lerini al
        var roleIds = await _dbContext.UserRoles
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.RoleId)
            .ToListAsync();

        if (roleIds == null || !roleIds.Any())
            new ArfBlocksVerificationException(ErrorCodeGenerator.ErrorCodeGenerator.GetErrorCode(() => DomainErrors.AuthorizationServiceErrors.UserDoesNotHaveSufficientPermission));


        // Bu rollerden herhangi biri ilgili permission'a sahip mi?
        var hasPermission = await _dbContext.RolePermissions
       .Where(rp => roleIds.Contains(rp.RoleId) && rp.Permission == permission)
       .AnyAsync();

        if (!hasPermission)
            new ArfBlocksVerificationException(ErrorCodeGenerator.ErrorCodeGenerator.GetErrorCode(() => DomainErrors.AuthorizationServiceErrors.UserDoesNotHaveSufficientPermission));

    }

}
