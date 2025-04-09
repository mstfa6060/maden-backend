namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Delete;

public class Mapper
{
	public ResponseModel MapToResponse(Job job)
	{
		return new ResponseModel
		{
			Id = job.Id,
			IsDeleted = job.IsDeleted
		};
	}
}
