using Common.Definitions.Base.Entity;

namespace Common.Definitions.Domain.Entities;

public class Resource : BaseEntity
{
	public string Name { get; set; }
	public string Namespace { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public bool IsSystemAdminPermitted { get; set; }
	public bool IsEndUserPermitted { get; set; }

	// varligini sorulayalim.
	public bool IsEveryoneAllowed { get; set; }

	public Guid ModuleId { get; set; }
	public Module Module { get; set; }


	// TODO: will be deleted
	public bool IsCompanyAdminPermitted { get; set; }
	public bool IsModuleAdminPermitted { get; set; }

}