namespace BaseModules.IAM.Application.RequestHandlers.Users.Commands.Create;

public class Mapper
{
	public User MapToNewEntity(RequestModel payload, string hashedPassword, string salt)
	{
		return new User()
		{
			Id = Guid.NewGuid(),
			UserName = payload.UserName,
			FirstName = payload.FirstName,
			Surname = payload.Surname,
			Email = payload.Email,
			PasswordHash = hashedPassword,
			PasswordSalt = salt,
			IsActive = true,
			EmailConfirmed = false,
			UserType = payload.UserType,
			CompanyId = payload.CompanyId
		};
	}

	public ResponseModel MapToResponse(User user)
	{
		return new ResponseModel()
		{
			Id = user.Id,
			UserName = user.UserName,
			Email = user.Email,
			FirstName = user.FirstName,
			Surname = user.Surname,
			IsActive = user.IsActive
		};
	}
}
