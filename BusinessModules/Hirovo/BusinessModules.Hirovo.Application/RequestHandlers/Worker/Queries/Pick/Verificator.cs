namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Queries.Pick;

public class Verificator : IRequestVerificator
{
	private readonly HirovoModuleDbVerificationService _dbVerificator;
	private readonly CurrentUserService _currentUserService;
	private readonly AuthorizationService _authorizationService;


	public Verificator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbVerificator = dependencyProvider.GetInstance<HirovoModuleDbVerificationService>();
		_currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
		_authorizationService = dependencyProvider.GetInstance<AuthorizationService>();

	}

	public async Task VerificateActor(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var requestPayload = (RequestModel)payload;
		// await _authorizationService.ForResource(typeof(Verificator).Namespace)
		// 						.VerifyActor()
		// 						.VerifyTenant<Company>(requestPayload.RelationId)
		// 						.Assert();
	}

	public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		// NOP:
		await Task.CompletedTask;
	}
}