namespace BusinessModules.Hirovo.Application.RequestHandlers.JobApplications.Commands.Create;

public class RequestModel : IRequestModel
{
	public Guid JobId { get; set; }
	public Guid WorkerId { get; set; }
}

public class ResponseModel : IResponseModel
{
	public Guid JobApplicationId { get; set; }
}
