
namespace BaseModules.IAM.Application.RequestHandlers.Users.Commands.Create;

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

		// Kullanıcının zaten var olup olmadığını kontrol et
		var existingUser = await _dataAccessLayer.GetUserByEmail(requestPayload.Email);
		if (existingUser != null)
		{
			throw new ArfBlocksValidationException("Bu e-posta adresi zaten kullanımda.");
		}

		// Şifre hashlemesi yap
		var salt = SecurityHelper.GenerateSalt();
		var hashedPassword = SecurityHelper.HashPassword(requestPayload.Password, salt);

		// Kullanıcı nesnesini oluştur
		var user = mapper.MapToNewEntity(requestPayload, hashedPassword, salt);

		// Veritabanına ekle
		await _dataAccessLayer.AddUser(user);

		var response = mapper.MapToResponse(user);
		return ArfBlocksResults.Success(response);
	}
}
