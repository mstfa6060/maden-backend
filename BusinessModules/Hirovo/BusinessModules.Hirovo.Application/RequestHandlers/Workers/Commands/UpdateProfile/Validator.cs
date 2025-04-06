using Common.Definitions.Domain.Errors;

namespace BusinessModules.Hirovo.Application.RequestHandlers.Workers.Commands.UpdateProfile;

public class Validator : IRequestValidator
{
	private readonly DataAccess _dataAccess;

	public Validator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dataAccess = new DataAccess(dependencyProvider);
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
		var requestPayload = (RequestModel)payload;
		var userId = requestPayload.UserId;

		// DB Validations
		var user = await _dataAccess.GetById(userId);
		if (user == null || user.UserType != UserType.Worker)
			throw new ArfBlocksValidationException(ErrorCodeGenerator.GetErrorCode(() => DomainErrors.UserErrors.UserNotFound));
	}
}

public class RequestModel_Validator : AbstractValidator<RequestModel>
{
	public RequestModel_Validator()
	{
		RuleFor(x => x.PhoneNumber).MaximumLength(20).When(x => x.PhoneNumber != null);
		RuleFor(x => x.City).MaximumLength(50).When(x => x.City != null);
		RuleFor(x => x.District).MaximumLength(50).When(x => x.District != null);
	}
}
