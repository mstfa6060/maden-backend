using System.ComponentModel.DataAnnotations.Schema;
using Common.Definitions.Base.Entity;



namespace Common.Definitions.Domain.Entities;

public class User : BaseEntity, ITenantEntity
{
    public Guid GetTenantId() => this.CompanyId;
    public string GetTenantPropertyName() => "CompanyId";
    public object GetTenantEntity() => null;

    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public Guid CompanyId { get; set; }

    // Üye tipi (İşçi mi? İşveren mi?)
    public UserType UserType { get; set; }

    // Kimlik doğrulama için eklenen alanlar
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    public bool EmailConfirmed { get; set; }
    public string EmailConfirmationToken { get; set; }
    public string PasswordResetToken { get; set; }
    public DateTime? PasswordResetTokenExpiry { get; set; }

    // OAuth sağlayıcıları desteği
    public string AuthProvider { get; set; }
    public string ProviderKey { get; set; }
    public string AuthAccessToken { get; set; }
    public string AuthRefreshToken { get; set; }

    // Kullanıcının tercihleri
    public string Language { get; set; }

    // En son bilinen lokasyon
    public double? LastKnownLatitude { get; set; }
    public double? LastKnownLongitude { get; set; }
    public DateTime? LastLocationUpdate { get; set; }

    public UserSources UserSource { get; set; }


    public DateTime? BirthDate { get; set; }
    public string? City { get; set; }
    public string? District { get; set; }
    public bool IsAvailable { get; set; }
    public string PhoneNumber { get; set; }

}

public enum UserType
{
    Worker = 1,     // İşçi (Çalışan)
    Employer = 2    // İşveren (İşçi Arayan)
}

public enum UserSources
{
    Manual = 0,   // Kullanıcı adı & şifre ile kayıt olanlar
    Google = 1,   // Google ile giriş yapanlar
    Apple = 2     // Apple ile giriş yapanlar
}
