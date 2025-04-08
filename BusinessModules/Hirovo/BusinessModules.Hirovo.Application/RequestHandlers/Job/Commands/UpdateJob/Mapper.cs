namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.UpdateProfile;

public class Mapper
{
	public User MapToNewEntity(RequestModel request)
	{
		return new User
		{
			Id = Guid.NewGuid(),
			PhoneNumber = request.PhoneNumber,
			BirthDate = request.BirthDate,
			City = request.City,
			District = request.District,
			UserType = UserType.Worker,
			CreatedAt = DateTime.UtcNow
		};
	}

}
