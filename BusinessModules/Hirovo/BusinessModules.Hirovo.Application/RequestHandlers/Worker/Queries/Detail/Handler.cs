namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.Detail;

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
		var requestModel = (RequestModel)payload;
		var mapper = new Mapper();

		var job = await _dataAccessLayer.GetJobById(requestModel.JobId);

		var response = mapper.MapToResponse(job);

		return ArfBlocksResults.Success(response);
	}
}
