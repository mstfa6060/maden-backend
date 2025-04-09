namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Queries.Detail;

public class RequestModel : IRequestModel
{
	public Guid UserId { get; set; }
}

public class ResponseModel : IResponseModel
{
	public Guid Id { get; set; }
	public string? Description { get; set; }
	public string? PhoneNumber { get; set; }
	public DateTime? BirthDate { get; set; }
	public string? City { get; set; }
	public string? District { get; set; }
	public bool? IsAvailable { get; set; }
}
