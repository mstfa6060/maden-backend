
using Arfware.ArfBlocks.Core.Exceptions;
using Common.Definitions.Domain.Errors;
using Common.Services.ErrorCodeGenerator;
using Microsoft.EntityFrameworkCore;

namespace Common.Definitions.Infrastructure.Services;


public class DefinitionDbValidationService
{
    private readonly DefinitionDbContext _dbContext;

    public DefinitionDbValidationService(DefinitionDbContext dbContext)
    {
        this._dbContext = dbContext;
    }

    public async Task ValidateRoleExist(string roleName)
    {
        // Get
        var authorizedModuleExistById = await _dbContext.AppRoles.AnyAsync(d => d.Name.ToLower() == roleName.ToLower());

        // Check
        if (authorizedModuleExistById)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.RoleErrors.NameValid));
    }

    public async Task ValidateUserByUserNameExist(string userName)
    {
        // Get
        var authorizedModuleExistById = await _dbContext.AppUsers.AnyAsync(d => d.UserName.ToLower() == userName.ToLower());

        // Check
        if (authorizedModuleExistById)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.UserNameValid));
    }

    public async Task ValidateUserByEmailExist(string email)
    {
        // Get
        var authorizedModuleExistById = await _dbContext.AppUsers.AnyAsync(d => d.Email.ToLower() == email.ToLower());

        // Check
        if (authorizedModuleExistById)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.EmailValid));
    }
}