using System.Net.Mail;

namespace FoodManagement_UI.Clients
{
    public class EmailClient : IEmailClient
    {
        private readonly IConfiguration _configuration;
        private readonly SmtpClient _smtpClient;
        private readonly MailMessage _mailMessageConfig;

        public EmailClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var smtpClientSettings = _configuration.GetSection("SmtpClientSettings").Get<SmtpClientSettings>();
            _mailMessageConfig = _configuration.GetSection("MailMessage").Get<MailMessage>();
            var credentials = _configuration.GetSection("SmtpClientSettings:Credentials").Get<Credentials>();
            _smtpClient = new SmtpClient(smtpClientSettings.Host);
            _smtpClient.Port = smtpClientSettings.Port;
            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            _smtpClient.UseDefaultCredentials = false;
            _smtpClient.EnableSsl = true;
            _smtpClient.Credentials = new System.Net.NetworkCredential(credentials.Username, credentials.Password);

        }

        public void Send(MailMessageSettings mailSettingMessage)
        {
            var Email = new MailAddress("zapcomlunch@zapcg.com");
            MailMessage mailMessage = new MailMessage(Email,mailSettingMessage.To);
            mailMessage.Subject = _mailMessageConfig.Subject;
            mailMessage.Body = mailSettingMessage.Body;
            mailMessage.IsBodyHtml = true;
            _smtpClient.Send(mailMessage);
        }
    }
}
