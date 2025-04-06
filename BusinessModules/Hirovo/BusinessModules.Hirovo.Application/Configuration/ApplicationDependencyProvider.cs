using BusinessModules.Hirovo.Application.Configuration;
// using BusinessModules.Management.Infrastructure.RelationalDB;
// using BusinessModules.Management.Infrastructure.Services;

namespace BusinessModules.Worker.Application.Configuration;

public class ApplicationDependencyProvider : ArfBlocksDependencyProvider
{
    public ApplicationDependencyProvider(IHttpContextAccessor httpContextAccessor, ProjectConfigurations projectConfigurations)
    {
        // Instances
        base.Add<ArfBlocksDependencyProvider>(this);
        base.Add<RelationalDbConfiguration>(projectConfigurations.RelationalDbConfiguration);
        base.Add<EnvironmentConfiguration>(projectConfigurations.EnvironmentConfiguration);
        base.Add<IHttpContextAccessor>(httpContextAccessor);
        base.Add<CurrentUserModel>(new CurrentUserModel());

        // Types
        base.Add<CurrentUserService>();
        base.Add<EnvironmentService>();

        // Data
        base.Add<DefinitionDbContextOptions>();
        base.Add<DefinitionDbContext>();
        base.Add<HirovoDbContextOptions>();
        base.Add<HirovoModuleDbContext>();
        // base.Add<HirovoModuleDbValidationService>();
        // base.Add<HirovoModuleDbVerificationService>();
        // base.Add<ManagementDbContextOptions>();
        // base.Add<ManagementDbContext>();
        // base.Add<ManagementDbValidationService>();
        // base.Add<ManagementDbVerificationService>();
        // // Connectors
        // base.Add<DomainEventSaverService>();
        // base.Add<HirovoDomainEventSaverService>();

        // base.Add<FileApproveConnector>();

        // base.Add<ActivityLogConnector>();
        // base.Add<HirovoActivityLogConnector>();

        // base.Add<MailConnector>();
        // base.Add<HirovoEmailConnector>();

        // Communication
        base.Add<ArfBlocksCommunicator>();

        // For Authorization Operations
        base.Add<AuthorizationService>();
        base.Add<DbContext, HirovoModuleDbContext>();








        
    }
}