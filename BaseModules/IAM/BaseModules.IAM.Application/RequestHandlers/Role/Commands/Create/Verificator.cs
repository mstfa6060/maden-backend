
namespace BaseModules.IAM.Application.RequestHandlers.Roles.Commands.Create;

public class Verificator : IRequestVerificator
{
    private readonly IamDbValidationService _dbVerificator;
    // private readonly CurrentUserService _currentUserService;
    private readonly AuthorizationService _authorizationService;

    public Verificator(ArfBlocksDependencyProvider dependencyProvider)
    {
        _dbVerificator = dependencyProvider.GetInstance<IamDbValidationService>();
        // _currentUserService = dependencyProvider.GetInstance<CurrentUserService>();
        _authorizationService = dependencyProvider.GetInstance<AuthorizationService>();
    }

    public async Task VerificateActor(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        var requestPayload = (RequestModel)payload;
        await _authorizationService.ForResource(typeof(Verificator).Namespace)
                                 .VerifyActor()
                                 .Assert();

        // Sadece sistem adminlerine izin ver
        bool isAdmin = await _authorizationService.IsSystemAdmin(ModuleTypes.Platform);
        if (!isAdmin)
        {
            throw new ArfBlocksVerificationException("Sadece sistem yöneticileri rol işlemi yapabilir.");
        }
        await Task.CompletedTask;

    }

    public async Task VerificateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
    {
        //NOP:
        await Task.CompletedTask;

        var requestPayload = (RequestModel)payload;


    }
}