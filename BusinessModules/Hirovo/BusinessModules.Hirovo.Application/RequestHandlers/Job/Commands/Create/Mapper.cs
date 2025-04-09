using BusinessModules.Hirovo.Domain.Entities;

namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Create;

public class Mapper
{
	public Job MapToNewEntity(RequestModel model)
	{
		return new Job()
		{
			Id = Guid.NewGuid(),
			Title = model.Title,
			Description = model.Description,
			Salary = model.Salary,
			Type = model.Type,
			EmployerId = model.EmployerId,
			Status = JobStatus.Active,
			CreatedAt = DateTime.UtcNow
		};
	}

	public ResponseModel MapToResponse(Job job)
	{
		return new ResponseModel
		{
			Id = job.Id
		};
	}
}
