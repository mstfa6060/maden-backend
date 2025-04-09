
using BusinessModules.Hirovo.Domain.Entities;

namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Create;

public class RequestModel : IRequestModel
{
	public string Title { get; set; }
	public string Description { get; set; }
	public decimal Salary { get; set; }
	public JobType Type { get; set; }
	public Guid EmployerId { get; set; }
}

public class ResponseModel : IResponseModel
{
	public Guid Id { get; set; }
}
