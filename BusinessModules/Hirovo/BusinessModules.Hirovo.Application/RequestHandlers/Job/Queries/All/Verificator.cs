namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.All;

public class Verificator : IRequestVerificator
{
    private readonly CurrentUserService _currentUserService;
    private readonly AuthorizationService _authorizationService;

    public Verificator(ArfBlocksDependencyProvider dependencyProvider)
    {
        _currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
        _authorizationService = dependencyProvider.GetInstance<AuthorizationService>();
    }

    public async Task VerificateActor(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        // await _authorizationService.ForResource(typeof(Verificator).Namespace)
        //                            .VerifyActor()
        //                            .Assert();
    }

    public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }
}
