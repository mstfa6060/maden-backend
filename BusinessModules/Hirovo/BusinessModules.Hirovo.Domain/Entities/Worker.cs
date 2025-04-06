
namespace BusinessModules.Hirovo.Domain.Entities
{
    public class Worker : BaseEntity, ITenantEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public object GetTenantEntity()
        {
            throw new NotImplementedException();
        }

        public Guid GetTenantId()
        {
            throw new NotImplementedException();
        }

        public string GetTenantPropertyName()
        {
            throw new NotImplementedException();
        }
    }
}