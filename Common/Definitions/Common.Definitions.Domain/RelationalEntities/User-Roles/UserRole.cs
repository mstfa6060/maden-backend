using System.ComponentModel.DataAnnotations.Schema;
using Common.Definitions.Base.Entity;



namespace Common.Definitions.Domain.Entities;

public class UserRole : BaseEntity, ITenantEntity
{
    public Guid UserId { get; set; }
    public Guid RoleId { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }

    [ForeignKey("RoleId")]
    public Role Role { get; set; }

    // ITenantEntity için zorunlu property
    public Guid TenantId { get; set; }

    public Guid GetTenantId() => TenantId;
    public string GetTenantPropertyName() => nameof(TenantId);

    public object GetTenantEntity()
    {
        return null;
    }
}



public class Role : BaseEntity
{
    public string Name { get; set; } // "Admin", "Employer", "Worker" vb.

    public bool IsSystemRole { get; set; } = false; // True: Sistem tarafından tanımlı rol

    public List<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
}
