using System.Security.Cryptography;

namespace BaseModules.IAM.Application.Handlers.Auth.Commands.Login;
public class Handler : IRequestHandler
{
	private readonly DataAccess _dataAccessLayer;
	private readonly ArfBlocksCommunicator _communicator;
	private readonly IJwtService _jwtService;

	public Handler(ArfBlocksDependencyProvider dependencyProvider, object dataAccess)
	{
		_dataAccessLayer = (DataAccess)dataAccess;
		_communicator = dependencyProvider.GetInstance<ArfBlocksCommunicator>();
		_jwtService = dependencyProvider.GetInstance<IJwtService>();
	}

	public async Task<ArfBlocksRequestResult> Handle(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var mapper = new Mapper();
		var request = (RequestModel)payload;

		User user = null;

		// Kullanıcıyı tespit et (provider'a göre)
		switch (request.Provider?.ToLower())
		{
			case "native":
				user = await _dataAccessLayer.GetUser(request.UserName);
				break;

			case "google":
				user = await _dataAccessLayer.GetUserByExternalId("google", request.Token); // token doğrulaması Validator tarafında
				break;

			case "itunes":
				user = await _dataAccessLayer.GetUserByExternalId("itunes", request.Token);
				break;

			default:
				throw new ArfBlocksValidationException("Geçersiz giriş sağlayıcısı");
		}

		// Kullanıcı doğrulaması (sadece native için)
		if (request.Provider.ToLower() == "native")
		{
			if (user == null || !SecurityHelper.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt))
				throw new ArfBlocksValidationException("Kullanıcı adı veya şifre hatalı");
		}

		// Token süresi hesapla
		var expiresAt = DateTime.UtcNow.AddDays(_jwtService.GetExpirationDayCount());

		// JWT üret
		var token = _jwtService.GenerateJwt(
			user.Id,
			user.UserName,
			$"{user.FirstName} {user.Surname}",
			request.Platform,
			expiresAt,
			user.UserSource
		);

		var response = mapper.MapToResponse(token, expiresAt, user);
		return ArfBlocksResults.Success(response);
	}
}

