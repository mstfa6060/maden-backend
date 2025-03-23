namespace BaseModules.IAM.Application.Handlers.Auth.Commands.Login;

public class ResponseModel : IResponseModel
{
	public string Jwt { get; set; }
	public DateTime SessionExpirationDate { get; set; }
	public UserResponse User { get; set; }

	public class UserResponse
	{
		public Guid Id { get; set; }
		public string Username { get; set; }
		public string DisplayName { get; set; }
		public string Email { get; set; }
		public Guid CompanyId { get; set; }
		public bool IsCompanyHolding { get; set; }
		public string CompanyName { get; set; }
	}
}

public class RequestModel : IRequestModel
{
	public string Provider { get; set; } // "native" | "google" | "itunes"
	public string UserName { get; set; } // Sadece native için gerekli
	public string Password { get; set; } // Sadece native için gerekli
	public string Token { get; set; }    // Google veya iTunes için gerekli
	public ClientPlatforms Platform { get; set; }

}
