namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.Detail;

public class Verificator : IRequestVerificator
{
	private readonly HirovoModuleDbVerificationService _dbVerificator;
	private readonly AuthorizationService _authorizationService;
	private readonly CurrentUserService _currentUserService;

	public Verificator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbVerificator = dependencyProvider.GetInstance<HirovoModuleDbVerificationService>();
		_authorizationService = dependencyProvider.GetInstance<AuthorizationService>();
		_currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
	}

	public async Task VerificateActor(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		// Opsiyonel yetkilendirme yazılabilir
		await Task.CompletedTask;
	}

	public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;
	}
}
