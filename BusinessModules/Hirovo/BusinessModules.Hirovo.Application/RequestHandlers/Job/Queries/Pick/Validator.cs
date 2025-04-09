namespace BusinessModules.Hirovo.Application.RequestHandlers.Jobs.Queries.Pick;

public class Validator : IRequestValidator
{
	public Validator(ArfBlocksDependencyProvider dependencyProvider) { }

	public void ValidateRequestModel(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		var request = (RequestModel)payload;
		var validationResult = new RequestModel_Validator().Validate(request);

		if (!validationResult.IsValid)
			throw new ArfBlocksValidationException(validationResult.ToString("~"));
	}

	public async Task ValidateDomain(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		await Task.CompletedTask;
	}
}

public class RequestModel_Validator : AbstractValidator<RequestModel>
{
	public RequestModel_Validator()
	{
		RuleFor(x => x.Limit)
			.GreaterThan(0)
			.WithMessage(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.JobErrors.LimitMustBeGreaterThanZero));
	}
}

