namespace BusinessModules.Hirovo.Application.RequestHandlers.JobApplications.Commands.Create;

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
		var request = (RequestModel)payload;
		await Task.CompletedTask;

		// await _authorizationService.ForResource(typeof(Verificator).Namespace)
		// 						   .VerifyTenant<User>(request.WorkerId)
		// 						   .VerifyActor()
		// 						   .Assert();
	}

	public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var request = (RequestModel)payload;
		await _dbVerificator.ValidateJobAlreadyApplied(request.JobId, request.WorkerId);
	}
}
