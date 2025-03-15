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
}

public enum UserType
{
    Worker = 1,     // İşçi (Çalışan)
    Employer = 2    // İşveren (İşçi Arayan)
}
