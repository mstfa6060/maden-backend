namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Delete;

public class RequestModel : IRequestModel
{
	public Guid JobId { get; set; }
	public bool IsDeleted { get; set; }
}

public class ResponseModel : IResponseModel
{
	public Guid Id { get; set; }
	public bool IsDeleted { get; set; }
}
