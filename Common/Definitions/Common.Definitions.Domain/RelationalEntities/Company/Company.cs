using System.ComponentModel.DataAnnotations.Schema;
using Common.Definitions.Base.Entity;



namespace Common.Definitions.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; }
    public string TaxNumber { get; set; } // Vergi Numarası
    public string Address { get; set; }
    public string Phone { get; set; }
}
