using Arfware.ArfBlocks.Core;

namespace BaseModules.IAM.Application.Configuration;

public class ApplicationDependencyProvider : ArfBlocksDependencyProvider
{
	public ApplicationDependencyProvider(IHttpContextAccessor httpContextAccessor, ProjectConfigurations projectConfigurations)
	{
		// Instances
		base.Add<ArfBlocksDependencyProvider>(this);
		base.Add<RelationalDbConfiguration>(projectConfigurations.RelationalDbConfiguration);
		base.Add<EnvironmentConfiguration>(projectConfigurations.EnvironmentConfiguration);
		// base.Add<DocumentDbOptions>(projectConfigurations.DocumentDbOptions);
		// base.Add<OpenLdapClientOptions>(projectConfigurations.OpenLdapClientOptions);
		// base.Add<MerkezBirligiClientOptions>(projectConfigurations.MerkezBirligiClientOptions);
		// base.Add<OpenLogoJhrOptions>(projectConfigurations.OpenLogoJhrOptions);
		// base.Add<MailConnectorOptions>(projectConfigurations.MailConnectorOptions);
		// base.Add<SmsConnectorOptions>(projectConfigurations.SmsConnectorOptions);
		// base.Add<NotificationConnectorOptions>(projectConfigurations.NotificationConnectorOptions);
		// base.Add<FileConnectorOptions>(projectConfigurations.FileConnectorOptions);
		// base.Add<KoopCardClientOptions>(projectConfigurations.KoopCardClientOptions);
		base.Add<IHttpContextAccessor>(httpContextAccessor);
		base.Add<CurrentUserModel>(new CurrentUserModel());
		// base.Add<AuditLogService>();

		// // Types
		base.Add<EnvironmentService>();
		base.Add<HttpService>();
		base.Add<CurrentUserService>();
		base.Add<DefinitionDbContextOptions>();
		base.Add<DefinitionDbContext>();
		base.Add<IamDbContextOptions>();
		base.Add<IamDbContext>();
		// base.Add<IamDocumentDbContext>();
		base.Add<IamDbValidationService>();
		base.Add<IamDbVerificationService>();

		// base.Add<IOpenLdapClient, OpenLdapClient>();
		// base.Add<IMerkezBirligiClient, MerkezBirligiClient>();
		// base.Add<IOpenLogoJhr, OpenLogoJhr>();
		// base.Add<KoopCardClient>();
		// base.Add<MailConnector>();
		// base.Add<IamEmailConnector>();
		// base.Add<SmsConnector>();
		// base.Add<IamSmsConnector>();
		// base.Add<NotificationConnector>();
		// base.Add<IamNotificationConnector>();
		// base.Add<FileConnector>();
		// base.Add<IamFileConnector>();
		base.Add<IJwtService, JwtService>();
		// base.Add<IUserLoginRecordService, UserLoginRecordService>();

		// // For Authorization Operations
		base.Add<AuthorizationService>();
		base.Add<DbContext, IamDbContext>();

		// Communication
		base.Add<ArfBlocksCommunicator>();

	}
}