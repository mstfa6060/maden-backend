namespace BaseModules.IAM.Application.Handlers.Auth.Commands.Login;

public class DataAccess : IDataAccess
{
    private readonly IamDbContext _dbContext;

    public DataAccess(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbContext = dependencyProvider.GetInstance<IamDbContext>();
    }


    public async Task<User> GetUserById(Guid userId)
    {
        return await _dbContext.AppUsers.SingleAsync(u => u.Id == userId);
    }
    public async Task<User> GetUser(string userName)
    {
        return await _dbContext.AppUsers.FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower());
    }

    public async Task<User> GetUserByExternalId(string provider, string externalId)
    {
        return await _dbContext.AppUsers.FirstOrDefaultAsync(u =>
            u.AuthProvider == provider && u.ProviderKey == externalId);
    }



}