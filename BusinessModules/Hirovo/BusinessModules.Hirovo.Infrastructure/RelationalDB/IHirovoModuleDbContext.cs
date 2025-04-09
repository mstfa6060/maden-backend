
using BusinessModules.Hirovo.Domain.Entities;

namespace BusinessModules.Hirovo.Infrastructure.RelationalDB;

public interface IHirovoModuleDbContext
{ 
	DbSet<Job> Jobs { get; set; }
    DbSet<JobApplication> JobApplications { get; set; }

}