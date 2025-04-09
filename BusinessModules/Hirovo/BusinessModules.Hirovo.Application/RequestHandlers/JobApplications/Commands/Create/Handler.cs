namespace BusinessModules.Hirovo.Application.RequestHandlers.JobApplications.Commands.Create;

public class Handler : IRequestHandler
{
	private readonly DataAccess _dataAccessLayer;
	private readonly ArfBlocksCommunicator _communicator;

	public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
	{
		_dataAccessLayer = (DataAccess)dataAccess;
		_communicator = dependencyProvider.GetInstance<ArfBlocksCommunicator>();
	}

	public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var request = (RequestModel)payload;
		var mapper = new Mapper();

		var entity = mapper.MapToEntity(request);

		var applicationId = await _dataAccessLayer.AddApplication(entity);

		entity.Id = applicationId;

		var response = mapper.MapToResponse(entity);
		return ArfBlocksResults.Success(response);
	}
}
