namespace BusinessModules.Hirovo.Application.RequestHandlers.JobApplications.Commands.Create;

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
		var request = (RequestModel)payload;

		var validationResult = new RequestModel_Validator().Validate(request);
		if (!validationResult.IsValid)
			throw new ArfBlocksValidationException(validationResult.ToString("~"));
	}

	public async Task ValidateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var request = (RequestModel)payload;
		var isCurrentUserSystemAdmin = await _authorizationService.IsSystemAdmin(ModuleTypes.Hirovo);
		var requestModel = (RequestModel)payload;

		await _dbValidator.ValidateUserExist(requestModel.WorkerId, isCurrentUserSystemAdmin);
		await _dbValidator.ValidateJobExist(request.JobId);
	}
}

public class RequestModel_Validator : AbstractValidator<RequestModel>
{
	public RequestModel_Validator()
	{
		RuleFor(x => x.JobId)
			.NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.JobErrors.JobIdRequired));

		RuleFor(x => x.WorkerId)
			.NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => Common.Definitions.Domain.Errors.DomainErrors.AuthErrors.UserIdNotValid));
	}
}
