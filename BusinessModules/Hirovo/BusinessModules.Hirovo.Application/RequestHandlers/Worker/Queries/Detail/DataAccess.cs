namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.Detail;

public class DataAccess : IDataAccess
{
    private readonly HirovoModuleDbContext _dbContext;

    public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbContext = dependencyProvider.GetInstance<HirovoModuleDbContext>();
    }

    public async Task<Job?> GetJobById(Guid jobId)
    {
        return await _dbContext.Jobs.FirstOrDefaultAsync(j => j.Id == jobId);
    }
}
