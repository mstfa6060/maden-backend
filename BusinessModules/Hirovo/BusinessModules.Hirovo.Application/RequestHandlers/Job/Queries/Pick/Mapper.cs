namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.Pick;

public class Mapper
{
	public List<ResponseModel> MapToResponse(List<Job> jobs)
	{
		return jobs.Select(j => new ResponseModel
		{
			Id = j.Id,
			Title = j.Title
		}).ToList();
	}
}
