namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Update;

public class DataAccess : IDataAccess
{
    private readonly HirovoModuleDbContext _dbContext;

    public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbContext = dependencyProvider.GetInstance<HirovoModuleDbContext>();
    }

    public async Task<Job?> GetById(Guid id)
    {
        return await _dbContext.Jobs.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
    }

    public async Task Update(Job job)
    {
        _dbContext.Jobs.Update(job);
        await _dbContext.SaveChangesAsync();
    }
}
