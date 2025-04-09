

using BusinessModules.Hirovo.Domain.Entities;

namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Create;

public class DataAccess : IDataAccess
{
    private readonly HirovoModuleDbContext _dbContext;

    public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbContext = dependencyProvider.GetInstance<HirovoModuleDbContext>();
    }

    public async Task AddJob(Job job)
    {
        await _dbContext.Jobs.AddAsync(job);
        await _dbContext.SaveChangesAsync();
    }
}
