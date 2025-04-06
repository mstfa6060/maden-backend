namespace BaseModules.IAM.Application.RequestHandlers.Roles.Commands.Update;

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
		var mapper = new Mapper();
		var requestPayload = (RequestModel)payload;

		var role = await _dataAccessLayer.GetRoleById(requestPayload.Id);


		mapper.MapToExistingEntity(requestPayload, role);
		await _dataAccessLayer.UpdateRole(role);

		var response = mapper.MapToResponse(role);
		return ArfBlocksResults.Success(response);
	}
}
