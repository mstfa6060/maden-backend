namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Queries.Detail;

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

		var user = await _dataAccessLayer.GetUserById(requestModel.UserId);

		var response = mapper.MapToResponse(user);

		return ArfBlocksResults.Success(response);
	}
}
