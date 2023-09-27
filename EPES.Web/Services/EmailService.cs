using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using EPES.Services.NotificationsAndAlertsAPI.Services.IService;
using EPES.Web.Models;

namespace EPES.Services.NotificationsAndAlertsAPI.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettingsDto _emailSettings;

        public EmailService(IOptions<EmailSettingsDto> emailSettings)
        {
            _emailSettings = emailSettings.Value;
        }

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_emailSettings.FromEmail));
            email.To.Add(MailboxAddress.Parse(toEmail));
            email.Subject = subject;

            var builder = new BodyBuilder();
            builder.TextBody = body;
            email.Body = builder.ToMessageBody();

            using var smtpClient = new SmtpClient();
            await smtpClient.ConnectAsync(_emailSettings.SmtpServer, _emailSettings.SmtpPort, false);
            await smtpClient.AuthenticateAsync(_emailSettings.SmtpUsername, _emailSettings.SmtpPassword);
            await smtpClient.SendAsync(email);
            await smtpClient.DisconnectAsync(true);
        }
    }
}
