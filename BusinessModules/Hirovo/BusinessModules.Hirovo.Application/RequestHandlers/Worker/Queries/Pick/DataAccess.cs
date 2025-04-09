using Common.Definitions.Domain.Extentions;

namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Queries.Pick;

public class DataAccess : IDataAccess
{
	private readonly HirovoModuleDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbContext = dependencyProvider.GetInstance<HirovoModuleDbContext>();
	}
	public async Task<List<User>> GetWorkers(List<Guid> selectedIds, string keyword, int limit)
	{
		var query = _dbContext.AppUsers
			.Where(u => u.UserType == UserType.Worker && !u.IsDeleted)
			.AsQueryable();

		if (selectedIds != null && selectedIds.Count > 0)
		{
			return await query.Where(u => selectedIds.Contains(u.Id)).ToListAsync();
		}
		else if (!string.IsNullOrEmpty(keyword))
		{
			keyword = keyword.ToLower();
			query = query.Where(u =>
				u.FirstName.ToLower().Contains(keyword) ||
				u.Surname.ToLower().Contains(keyword));
		}

		query = query.Take(limit > 0 ? limit : 5);

		return await query.ToListAsync();
	}
}