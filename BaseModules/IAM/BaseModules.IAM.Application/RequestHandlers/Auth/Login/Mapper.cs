namespace BaseModules.IAM.Application.Handlers.Auth.Commands.Login;

public class Mapper
{
	public ResponseModel MapToResponse(string jwt, DateTime sessionExpirationDate, User user)
	{
		return new ResponseModel()
		{
			Jwt = jwt,
			SessionExpirationDate = sessionExpirationDate,
			User = new ResponseModel.UserResponse()
			{
				Id = user.Id,
				Username = user.UserName,
				DisplayName = $"{user.FirstName} {user.Surname}",
				Email = user.Email,
			}
		};
	}
}