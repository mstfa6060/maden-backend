namespace BaseModules.IAM.Application.Handlers.Auth.Commands.Login;

public class Verificator : IRequestVerificator
{
	private readonly IamDbValidationService _dbVerificator;
	private readonly CurrentUserService _currentUserService;
	private readonly AuthorizationService _authorizationService;

	public Verificator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbVerificator = dependencyProvider.GetInstance<IamDbValidationService>();
		_currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
		_authorizationService = dependencyProvider.GetInstance<AuthorizationService>();
	}

	public async Task VerificateActor(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		// NOP:
		await Task.CompletedTask;
	}

	public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		// Get Request Payload
		var requestPayload = (RequestModel)payload;

	}
}