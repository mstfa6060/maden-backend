using Common.Definitions.Infrastructure.Services;

namespace BaseModules.IAM.Infrastructure.Services;

public class IamDbValidationService : DefinitionDbValidationService
{
    private readonly IamDbContext _dbContext;
    public IamDbValidationService(IamDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}