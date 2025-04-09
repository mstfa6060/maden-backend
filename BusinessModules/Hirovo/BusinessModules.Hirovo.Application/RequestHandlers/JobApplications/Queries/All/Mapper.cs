using BusinessModules.Hirovo.Domain.Entities;

namespace BusinessModules.Hirovo.Application.RequestHandlers.JobApplications.Queries.All;

public class Mapper
{
	public List<ResponseModel> MapToResponse(List<JobApplication> applications)
	{
		return applications.Select(app => new ResponseModel
		{
			Id = app.Id,
			JobId = app.JobId,
			WorkerId = app.WorkerId,
			Status = app.Status,
			AppliedAt = app.AppliedAt
		}).ToList();
	}
}
