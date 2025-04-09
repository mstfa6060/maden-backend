namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Update;

public class RequestModel : IRequestModel
{
	public Guid JobId { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public decimal Salary { get; set; }
	public JobType Type { get; set; }
	public JobStatus Status { get; set; }
}

public class ResponseModel : IResponseModel
{
	public Guid Id { get; set; }
}
