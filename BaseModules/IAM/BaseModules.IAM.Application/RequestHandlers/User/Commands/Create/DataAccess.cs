// DataAccess.cs
namespace BaseModules.IAM.Application.RequestHandlers.Users.Commands.Create;
public class DataAccess
{
	private readonly IamDbContext _dbContext;

	public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbContext = dependencyProvider.GetInstance<IamDbContext>();
	}

	public async Task AddUser(User user)
	{
		_dbContext.AppUsers.Add(user);
		await _dbContext.SaveChangesAsync();
	}

	public async Task<User> GetUserByEmail(string email)
	{
		return await _dbContext.AppUsers.FirstOrDefaultAsync(u => u.Email == email);
	}
}
