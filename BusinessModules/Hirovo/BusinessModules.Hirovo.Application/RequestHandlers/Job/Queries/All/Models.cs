namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.All;

public class ResponseModel : IResponseModel<Array>
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public decimal Salary { get; set; }
	public JobType Type { get; set; }
	public JobStatus Status { get; set; }
}

public class RequestModel : IRequestModel
{
	public XSorting Sorting { get; set; }
	public List<XFilterItem> Filters { get; set; }
	public XPageRequest PageRequest { get; set; }
}
