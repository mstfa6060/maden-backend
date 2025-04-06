namespace BaseModules.IAM.Application.Handlers.Auth.Commands.Login;

public class Validator : IRequestValidator
{
	private readonly IamDbValidationService _dbValidator;

	public Validator(ArfBlocksDependencyProvider dependencyProvider)
	{
		_dbValidator = dependencyProvider.GetInstance<IamDbValidationService>();
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
		var requestModel = (RequestModel)payload;

		switch (requestModel.Provider?.ToLower())
		{
			case "google":
				var googleUserId = await _dbValidator.ValidateGoogleToken(requestModel.Token);
				if (string.IsNullOrEmpty(googleUserId))
					throw new ArfBlocksValidationException("Google token doğrulanamadı");
				break;

			case "itunes":
				var appleUserId = await _dbValidator.ValidateAppleToken(requestModel.Token);
				if (string.IsNullOrEmpty(appleUserId))
					throw new ArfBlocksValidationException("iTunes token doğrulanamadı");
				break;

			case "native":
				// Native için token doğrulaması yapılmaz, bu yüzden burası boş
				break;

			default:
				throw new ArfBlocksValidationException("Bilinmeyen giriş sağlayıcısı");
		}
	}
}


public class RequestModel_Validator : AbstractValidator<RequestModel>
{
	public RequestModel_Validator()
	{
		RuleFor(x => x.Provider)
			.NotEmpty().WithMessage("Giriş sağlayıcısı gereklidir");

		When(x => x.Provider.ToLower() == "native", () =>
		{
			RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adı zorunludur");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre zorunludur");
		});

		When(x => x.Provider.ToLower() == "google" || x.Provider.ToLower() == "itunes", () =>
		{
			RuleFor(x => x.Token).NotEmpty().WithMessage("Token zorunludur");
		});
	}
}
