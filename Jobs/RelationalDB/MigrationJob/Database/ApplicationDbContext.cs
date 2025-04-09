using BaseModules.IAM.Infrastructure.RelationalDB;
using BusinessModules.Hirovo.Domain.Entities;
using BusinessModules.Hirovo.Infrastructure.RelationalDB;
using Common.Definitions.Domain.Entities;
using Common.Definitions.Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;

namespace Jobs.RelationalDB.MigrationJob;

public class ApplicationDbContext : DbContext, IDefinitionDbContext, IHirovoModuleDbContext
{
    public DbSet<User> AppUsers { get; set; }
    public DbSet<Role> AppRoles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Resource> AppResources { get; set; }
    public DbSet<SystemAdmin> AppSystemAdmins { get; set; }
    public DbSet<RelSystemUserModule> AppRelSystemUserModules { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Job> Jobs { get; set; }
    public DbSet<JobApplication> JobApplications { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Common seed data (zaten var)
        CommonModelBuilder.Build(modelBuilder);

        // 💡 Tüm foreign key'lerde cascade delete'i kapat
        foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
        {
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
        }

        base.OnModelCreating(modelBuilder);
    }

}
