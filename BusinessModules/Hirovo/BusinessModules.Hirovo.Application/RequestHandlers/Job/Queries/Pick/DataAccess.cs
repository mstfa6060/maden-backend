namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.Pick;

public class DataAccess : IDataAccess
{
	private readonly HirovoModuleDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbContext = dependencyProvider.GetInstance<HirovoModuleDbContext>();
	}

	public async Task<List<Job>> GetJobs(List<Guid> selectedIds, string keyword, int limit)
	{
		var query = _dbContext.Jobs
			.Where(j => !j.IsDeleted && j.Status == JobStatus.Active)
			.AsQueryable();

		if (selectedIds != null && selectedIds.Any())
			query = query.Where(j => selectedIds.Contains(j.Id));
		else if (!string.IsNullOrWhiteSpace(keyword))
			query = query.Where(j => j.Title.ToLower().Contains(keyword.ToLower()));

		query = query.Take(limit > 0 ? limit : 5);

		return await query.ToListAsync();
	}
}
