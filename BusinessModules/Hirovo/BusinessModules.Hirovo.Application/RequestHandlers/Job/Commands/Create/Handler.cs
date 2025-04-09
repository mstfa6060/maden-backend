namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Create;

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
		var requestModel = (RequestModel)payload;

		// Yeni Job nesnesi oluştur
		var job = mapper.MapToNewEntity(requestModel);

		// DB'ye kaydet
		await _dataAccessLayer.AddJob(job);

		// Response dön
		var response = mapper.MapToResponse(job);
		return ArfBlocksResults.Success(response);
	}
}
