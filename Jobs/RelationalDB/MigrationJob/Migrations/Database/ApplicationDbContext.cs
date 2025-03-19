using BaseModules.IAM.Infrastructure.RelationalDB;
using Common.Definitions.Domain.Entities;
using Common.Definitions.Infrastructure.RelationalDB;
using Microsoft.EntityFrameworkCore;

namespace Jobs.RelationalDB.MigrationJob;

public class ApplicationDbContext : DbContext, IDefinitionDbContext
{
    public DbSet<User> AppUsers { get; set; }
    public DbSet<Role> AppRoles { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Resource> AppResources { get; set; }
    public DbSet<SystemAdmin> AppSystemAdmins { get; set; }
    public DbSet<RelSystemUserModule> AppRelSystemUserModules { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed data çağrısı buraya eklenmeli
        CommonModelBuilder.Build(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }

}
