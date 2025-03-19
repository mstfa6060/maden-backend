
namespace BaseModules.IAM.Application.Configuration;

public class ProjectConfigurations : IConfigurationClass
{
	public RelationalDbConfiguration RelationalDbConfiguration { get; set; }
	public EnvironmentConfiguration EnvironmentConfiguration { get; set; }
	// 	public DocumentDbOptions DocumentDbOptions { get; set; }
	// 	public OpenLdapClientOptions OpenLdapClientOptions { get; set; }
	// 	public MerkezBirligiClientOptions MerkezBirligiClientOptions { get; set; }
	// 	public OpenLogoJhrOptions OpenLogoJhrOptions { get; set; }
	// 	public MailConnectorOptions MailConnectorOptions { get; set; }
	// 	public SmsConnectorOptions SmsConnectorOptions { get; set; }
	// 	public FileConnectorOptions FileConnectorOptions { get; set; }
	// 	public NotificationConnectorOptions NotificationConnectorOptions { get; set; }
	// 	public KoopCardClientOptions KoopCardClientOptions { get; set; }
}