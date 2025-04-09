using Arfware.ArfBlocks.Core.Exceptions;
using BusinessModules.Hirovo.Domain.Errors;
using Common.Services.ErrorCodeGenerator;

namespace BusinessModules.Hirovo.Infrastructure.Services;

public class HirovoModuleDbVerificationService : DefinitionDbValidationService
{
    private readonly HirovoModuleDbContext _dbContext;

    public HirovoModuleDbVerificationService(HirovoModuleDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task ValidateJobAlreadyApplied(Guid jobId, Guid workerId)
    {
        var alreadyApplied = await _dbContext.JobApplications
            .AnyAsync(x => x.JobId == jobId && x.WorkerId == workerId);

        if (alreadyApplied)
            throw new ArfBlocksValidationException(
                ErrorCodeGenerator.GetErrorCode(() => DomainErrors.JobApplicationErrors.JobAlreadyApplied)
            );
    }

}
