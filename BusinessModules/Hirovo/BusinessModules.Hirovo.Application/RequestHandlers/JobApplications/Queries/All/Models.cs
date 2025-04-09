using BusinessModules.Hirovo.Domain.Entities;

namespace BusinessModules.Hirovo.Application.RequestHandlers.JobApplications.Queries.All;

public class ResponseModel : IResponseModel<Array>
{
	public Guid Id { get; set; }
	public Guid JobId { get; set; }
	public Guid WorkerId { get; set; }
	public ApplicationStatus Status { get; set; }
	public DateTime AppliedAt { get; set; }
}

public class RequestModel : IRequestModel
{
	public XSorting Sorting { get; set; }
	public List<XFilterItem> Filters { get; set; }
	public XPageRequest PageRequest { get; set; }
}
