namespace BusinessModules.Hirovo.Application.RequestHandlers.JobApplications.Commands.Create;

public class DataAccess : IDataAccess
{
    private readonly HirovoModuleDbContext _dbContext;

    public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbContext = dependencyProvider.GetInstance<HirovoModuleDbContext>();
    }


    public async Task<bool> HasAlreadyApplied(Guid jobId, Guid workerId)
    {
        return await _dbContext.JobApplications
            .AnyAsync(x => x.JobId == jobId && x.WorkerId == workerId);
    }

    public async Task<Guid> AddApplication(JobApplication entity)
    {
        entity.Id = Guid.NewGuid();
        await _dbContext.JobApplications.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity.Id;
    }
}
