namespace EPES.Services.NotificationsAndAlertsAPI.Services.IService
{
   
    
        public interface IEmailService
        {
            Task SendEmailAsync(string toEmail, string subject, string body);
        }
 }
