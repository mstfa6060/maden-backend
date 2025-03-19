namespace BaseModules.IAM.Application.RequestHandlers.Roles.Queries.All;

public class DataAccess : IDataAccess
{
	private readonly IamDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbContext = dependencyProvider.GetInstance<IamDbContext>();
	}

	public async Task<(List<Role>, XPageResponse)> All(XSorting sorting, List<XFilterItem> filters, XPageRequest pageRequest)
	{
		var query = _dbContext.AppRoles
			.Sort(sorting)
			.Filter(filters);

		if (sorting == null)
			query = query.OrderByDescending(c => c.Name);

		var page = query.GetPage(pageRequest);
		var list = await query.Paginate(page).ToListAsync();

		return (list, page);
	}
}
