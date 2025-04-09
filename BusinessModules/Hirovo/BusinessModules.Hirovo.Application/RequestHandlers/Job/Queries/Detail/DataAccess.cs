namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Queries.Detail;

public class DataAccess : IDataAccess
{
    private readonly HirovoModuleDbContext _dbContext;

    public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbContext = dependencyProvider.GetInstance<HirovoModuleDbContext>();
    }

    public async Task<User?> GetUserById(Guid userId)
    {
        return await _dbContext.AppUsers
            .FirstOrDefaultAsync(u => u.Id == userId);
    }
}
