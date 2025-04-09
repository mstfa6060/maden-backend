
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Jobs.RelationalDB.MigrationJob;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var environment = args.Length > 0 ? args[0] : "development";
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.staging.json", false, false)
            .AddJsonFile($"appsettings.{environment}.json", true, false)
            .AddEnvironmentVariables()
            .Build();

        var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

        var connectionString = configuration
                    .GetConnectionString("SqlConnectionString");

        dbContextOptionsBuilder.UseSqlServer(connectionString, x => x.MigrationsAssembly("Jobs.RelationalDB.MigrationJob"));

        return new ApplicationDbContext(dbContextOptionsBuilder.Options);
    }
}