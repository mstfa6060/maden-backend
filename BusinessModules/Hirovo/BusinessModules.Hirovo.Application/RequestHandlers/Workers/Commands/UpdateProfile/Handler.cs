namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Commands.UpdateProfile;

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
		var userId = request.UserId;

		var user = await _dataAccessLayer.GetById(userId);
		if (user == null)
			throw new ArfBlocksValidationException("Kullanıcı bulunamadı.");

		if (request.PhoneNumber != null)
			user.PhoneNumber = request.PhoneNumber;
		if (request.BirthDate != null)
			user.BirthDate = request.BirthDate;
		if (request.City != null)
			user.City = request.City;
		if (request.District != null)
			user.District = request.District;
		if (request.IsAvailable != null)
			user.IsAvailable = request.IsAvailable.Value;

		await _dataAccessLayer.Update(user);

		return ArfBlocksResults.Success(new ResponseModel { Id = user.Id });
	}
}
