 

namespace BusinessModules.Hirovo.Infrastructure.RelationalDB;

public class HirovoModuleDbContext : DefinitionDbContext, IHirovoModuleDbContext
{
	public HirovoModuleDbContext(HirovoDbContextOptions customDbContextOptions) : base(customDbContextOptions.DefinitionDbContextOptions)
	{ }


	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		HirovoModelBuilder.Build(modelBuilder);
	}

}


public class HirovoDbContextOptions
{
	public readonly DbContextOptions<HirovoModuleDbContext> DbContextOptions;
	public readonly DbContextOptions<DefinitionDbContext> DefinitionDbContextOptions;
	public HirovoDbContextOptions(RelationalDbConfiguration configuration, EnvironmentService environmentService, DefinitionDbContextOptions definitionDbContextOptions
	)
	{
		this.DefinitionDbContextOptions = definitionDbContextOptions.DbContextOptions;

		///////////////////////////////////////////////////////////////////////////////////

		var dbContextOptionsBuilder = new DbContextOptionsBuilder<HirovoModuleDbContext>();

		if (environmentService.Environment == CustomEnvironments.Test)
			dbContextOptionsBuilder.UseInMemoryDatabase("inmemory-db");
		else
			dbContextOptionsBuilder.UseSqlServer(configuration.ConnectionString);

		this.DbContextOptions = dbContextOptionsBuilder.Options;
	}
}