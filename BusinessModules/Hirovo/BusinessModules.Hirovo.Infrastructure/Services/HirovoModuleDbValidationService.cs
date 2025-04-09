using Arfware.ArfBlocks.Core.Exceptions;
using BusinessModules.Hirovo.Domain.Errors;
using Common.Services.ErrorCodeGenerator;

public class HirovoModuleDbValidationService : DefinitionDbValidationService
{
    private readonly HirovoModuleDbContext _dbContext;

    public HirovoModuleDbValidationService(HirovoModuleDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task ValidateJobExist(Guid jobId)
    {
        var job = await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == jobId && !j.IsDeleted);

        if (job is null)
        {
            throw new ArfBlocksValidationException(
                ErrorCodeGenerator.GetErrorCode(() => DomainErrors.JobErrors.JobNotFound)
            );
        }
    }


    public async Task ValidateUserExist(Guid id, bool isAdmin)
    {
        var user = await _dbContext.AppUsers.FirstOrDefaultAsync(x => x.Id == id);

        if (user == null)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.WorkerErrors.UserIdNotExist));

        if (!isAdmin && user.IsDeleted)
            throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.WorkerErrors.UserIdNotExist));
    }

}