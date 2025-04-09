namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Commands.Update;

public class Validator : IRequestValidator
{
	private readonly HirovoModuleDbValidationService _dbValidator;

	public Validator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbValidator = dependencyProvider.GetInstance<HirovoModuleDbValidationService>();
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
		await _dbValidator.ValidateJobExist(request.JobId);
	}
}

public class RequestModel_Validator : AbstractValidator<RequestModel>
{
	public RequestModel_Validator()
	{
		RuleFor(x => x.JobId)
			.NotEmpty()
			.WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.JobErrors.IdNotValid));

		RuleFor(x => x.Title)
			.NotEmpty()
			.WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.JobErrors.TitleNotValid));

		RuleFor(x => x.Salary)
			.GreaterThan(0)
			.WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.JobErrors.SalaryNotValid));
	}
}

