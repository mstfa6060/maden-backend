
namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Queries.Pick;

public class Mapper
{
	public List<ResponseModel> MapToResponse(List<User> users)
	{
		return users.Select(u => new ResponseModel
		{
			Id = u.Id,
			FullName = $"{u.FirstName} {u.Surname}"
		}).ToList();
	}
}
