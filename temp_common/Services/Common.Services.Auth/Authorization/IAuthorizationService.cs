using Common.Definitions.Base.Entity;
using Common.Definitions.Domain.Entities;

namespace Common.Services.Auth.Authorization;

public interface IAuthorizationService
{
    public void EnableLogEverything();
    public void DisableLogEverything();

    public IAuthorizationService VerifyActor();

    public IAuthorizationService ForResource(string nspace);

    public IAuthorizationService ForResource<T>() where T : class;

    public IAuthorizationService VerifyTenant<TEntity>(Guid entityId) where TEntity : CoreEntity, ITenantEntity;

    public Task Assert();

    public Task<bool> Verify();

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    public Task<bool> IsFakeRegisteredUser();
    public Task<bool> IsUserBanned();
    public Task<bool> IsSystemAdmin(ModuleTypes moduleType);
    Task<bool> HasNamespacePermission(Guid userId, string namespacePath);

    /// <summary>
    /// Kullanıcının belirli bir izne sahip olup olmadığını kontrol eder.
    /// </summary>
    /// <param name="userId">Aktif kullanıcı</param>
    /// <param name="permission">İzin tanımı (örn: "Roles.Create")</param>
    /// <returns>Yetkiliyse devam eder, değilse exception fırlatır</returns>
    Task CheckAccess(Guid userId, string permission);
}