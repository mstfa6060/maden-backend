namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Update;

public class Mapper
{
	public void MapToExistingEntity(Job job, RequestModel request)
	{
		job.Title = request.Title;
		job.Description = request.Description;
		job.Salary = request.Salary;
		job.Type = request.Type;
		job.Status = request.Status;
	}
}
