namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Delete;

public class DataAccess : IDataAccess
{
	private readonly HirovoModuleDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbContext = dependencyProvider.GetInstance<HirovoModuleDbContext>();
	}

	public async Task<Job?> GetJobById(Guid jobId)
	{
		return await _dbContext.Jobs.FirstOrDefaultAsync(x => x.Id == jobId);
	}

	public async Task UpdateJob(Job job)
	{
		_dbContext.Jobs.Update(job);
		await _dbContext.SaveChangesAsync();
	}
}
