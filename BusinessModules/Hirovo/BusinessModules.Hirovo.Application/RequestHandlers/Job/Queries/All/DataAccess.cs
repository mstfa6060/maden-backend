namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.All;

public class DataAccess : IDataAccess
{
	private readonly HirovoModuleDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbContext = dependencyProvider.GetInstance<HirovoModuleDbContext>();
	}

	public async Task<(List<Job>, XPageResponse)> All(XSorting sorting, List<XFilterItem> filters, XPageRequest pageRequest)
	{
		var query = _dbContext.Jobs
			.Where(j => j.Status == JobStatus.Active)
			.Sort(sorting)
			.Filter(filters);

		if (sorting == null)
			query = query.OrderByDescending(c => c.Title);

		var page = query.GetPage(pageRequest);
		var list = await query.Paginate(page).ToListAsync();

		return (list, page);
	}
}
