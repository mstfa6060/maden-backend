namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Commands.UpdateProfile;

public class DataAccess : IDataAccess
{
	private readonly HirovoModuleDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbContext = dependencyProvider.GetInstance<HirovoModuleDbContext>();
	}

	public async Task<User> GetById(Guid userId)
	{
		return await _dbContext.AppUsers.FirstOrDefaultAsync(x => x.Id == userId && x.UserType == UserType.Worker);
	}

	public async Task Update(User user)
	{
		_dbContext.AppUsers.Update(user);
		await _dbContext.SaveChangesAsync();
	}

}
