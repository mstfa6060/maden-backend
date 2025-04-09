namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Queries.Pick;

public class Validator : IRequestValidator
{
	private readonly HirovoModuleDbValidationService _dbValidator;

	public Validator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbValidator = dependencyProvider.GetInstance<HirovoModuleDbValidationService>();
	}

	public void ValidateRequestModel(IRequestModel payload, EndpointContext context, CancellationToken cancellationToken)
	{
		// Get Request Payload
		var requestModel = (RequestModel)payload;

		// Request Model Validation
		var validationResult = new RequestModel_Validator().Validate(requestModel);
		if (!validationResult.IsValid)
		{
			var errors = validationResult.ToString("~");
			throw new ArfBlocksValidationException(errors);
		}
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
	}
}