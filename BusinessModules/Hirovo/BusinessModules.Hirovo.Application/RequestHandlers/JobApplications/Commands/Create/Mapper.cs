namespace BusinessModules.Hirovo.Application.RequestHandlers.JobApplications.Commands.Create;

public class Mapper
{
	public JobApplication MapToEntity(RequestModel request)
	{
		return new JobApplication()
		{
			JobId = request.JobId,
			WorkerId = request.WorkerId,
			Status = ApplicationStatus.Pending,
			CreatedAt = DateTime.UtcNow
		};
	}

	public ResponseModel MapToResponse(JobApplication entity)
	{
		return new ResponseModel()
		{
			JobApplicationId = entity.Id
		};
	}
}
