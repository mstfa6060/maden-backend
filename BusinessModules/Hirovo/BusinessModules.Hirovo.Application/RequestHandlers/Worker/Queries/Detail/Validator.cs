namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.Detail;

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
			throw new ArfBlocksValidationException(validationResult.ToString("~"));
	}

	public async Task ValidateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var requestModel = (RequestModel)payload;
		await _dbValidator.ValidateJobExist(requestModel.JobId);
	}
}

public class RequestModel_Validator : AbstractValidator<RequestModel>
{
	public RequestModel_Validator()
	{
		RuleFor(x => x.JobId)
			.NotEmpty().WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.JobErrors.IdNotValid));
	}
}
