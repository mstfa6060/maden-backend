namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.All;

public class Handler : IRequestHandler
{
	private readonly DataAccess _dataAccessLayer;
	private readonly AuthorizationService _authorizationService;

	public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
	{
		_dataAccessLayer = (DataAccess)dataAccess;
		_authorizationService = dependencyProvider.GetInstance<AuthorizationService>();
	}

	public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var mapper = new Mapper();
		var requestPayload = (RequestModel)payload;

		var (jobs, page) = await _dataAccessLayer.All(requestPayload.Sorting, requestPayload.Filters, requestPayload.PageRequest);
		var response = mapper.MapToResponse(jobs);

		return ArfBlocksResults.Success(response, page);
	}
}
