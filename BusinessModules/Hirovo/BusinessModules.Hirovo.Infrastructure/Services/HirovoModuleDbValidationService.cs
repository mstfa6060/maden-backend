public class CisModuleDbValidationService : DefinitionDbValidationService
{
    private readonly HirovoModuleDbContext _dbContext;

    public CisModuleDbValidationService(HirovoModuleDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}