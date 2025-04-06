namespace BaseModules.IAM.Application.RequestHandlers.Users.Commands.Create;

public class ResponseModel : IResponseModel
{
	public Guid Id { get; set; }
	public string UserName { get; set; }
	public string Email { get; set; }
	public string FirstName { get; set; }
	public string Surname { get; set; }
	public bool IsActive { get; set; }
	public UserType UserType { get; set; }
}



public class RequestModel : IRequestModel
{
	public string UserName { get; set; }
	public string FirstName { get; set; }
	public string Surname { get; set; }
	public string Email { get; set; }
	public string Password { get; set; } // Sadece Manual kayıtlar için zorunlu
	public string ProviderId { get; set; } // Google veya Apple ID'si
	public UserType UserType { get; set; }
	public Guid CompanyId { get; set; }
	public UserSources UserSource { get; set; } // RegistrationType yerine geçiyor
	public string? Description { get; set; } // 🆕 Ek örnek alan

}


