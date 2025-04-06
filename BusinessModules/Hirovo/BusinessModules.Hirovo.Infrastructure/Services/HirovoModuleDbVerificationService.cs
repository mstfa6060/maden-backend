using Arfware.ArfBlocks.Core.Exceptions;
using Common.Services.ErrorCodeGenerator;

namespace BusinessModules.Hirovo.Infrastructure.Services;

public class HirovoModuleDbVerificationService : DefinitionDbValidationService
{
    private readonly HirovoModuleDbContext _dbContext;

    public HirovoModuleDbVerificationService(HirovoModuleDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

}
