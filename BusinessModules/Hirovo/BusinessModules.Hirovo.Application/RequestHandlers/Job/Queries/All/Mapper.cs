namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.All;

public class Mapper
{
	public List<ResponseModel> MapToResponse(List<Job> jobs)
	{
		var mapped = new List<ResponseModel>();

		foreach (var job in jobs)
		{
			mapped.Add(new ResponseModel()
			{
				Id = job.Id,
				Title = job.Title,
				Salary = job.Salary,
				Type = job.Type,
				Status = job.Status
			});
		}

		return mapped;
	}
}
