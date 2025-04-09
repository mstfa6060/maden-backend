

namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Queries.Detail;

public class Validator : IRequestValidator
{
	private readonly HirovoModuleDbValidationService _dbValidator;
	private readonly AuthorizationService _authorizationService;

	public Validator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbValidator = dependencyProvider.GetInstance<HirovoModuleDbValidationService>();
		_authorizationService = dependencyProvider.GetInstance<AuthorizationService>();
	}

	public void ValidateRequestModel(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var requestModel = (RequestModel)payload;

		var validationResult = new RequestModel_Validator().Validate(requestModel);
		if (!validationResult.IsValid)
		{
			var errors = validationResult.ToString("~");
			throw new ArfBlocksValidationException(errors);
		}
	}

	public async Task ValidateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var isCurrentUserSystemAdmin = await _authorizationService.IsSystemAdmin(ModuleTypes.Hirovo);
		var requestModel = (RequestModel)payload;

		await _dbValidator.ValidateUserExist(requestModel.UserId, isCurrentUserSystemAdmin);
	}
}

public class RequestModel_Validator : AbstractValidator<RequestModel>
{
	public RequestModel_Validator()
	{
		RuleFor(x => x.UserId)
			.NotNull().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.WorkerErrors.UserIdNotValid))
			.NotEqual(Guid.Empty).WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.WorkerErrors.UserIdNotValid));
	}
}
