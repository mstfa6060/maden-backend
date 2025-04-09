namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Queries.Pick;

public class Handler : IRequestHandler
{
	private readonly DataAccess _dataAccessLayer;
	public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
	{
		_dataAccessLayer = (DataAccess)dataAccess;
	}

	public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var mapper = new Mapper();
		var requestPayload = (RequestModel)payload;

		var workers = await _dataAccessLayer.GetWorkers(requestPayload.SelectedIds, requestPayload.Keyword, requestPayload.Limit);
		var response = mapper.MapToResponse(workers);

		return ArfBlocksResults.Success(response);
	}
}