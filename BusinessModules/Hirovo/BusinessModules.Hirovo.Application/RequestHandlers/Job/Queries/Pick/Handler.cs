namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.Pick;

public class Handler : IRequestHandler
{
	private readonly DataAccess _dataAccessLayer;

	public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
	{
		_dataAccessLayer = (DataAccess)dataAccess;
	}

	public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var request = (RequestModel)payload;
		var mapper = new Mapper();

		var jobs = await _dataAccessLayer.GetJobs(request.SelectedIds, request.Keyword, request.Limit);
		var response = mapper.MapToResponse(jobs);

		return ArfBlocksResults.Success(response);
	}
}
