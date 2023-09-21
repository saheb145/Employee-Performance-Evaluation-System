using EPES.Services.NotificationsAndAlertsAPI.Models;
using EPES.Services.NotificationsAndAlertsAPI.Models.Dto;
using EPES.Services.NotificationsAndAlertsAPI.Services;
using EPES.Services.NotificationsAndAlertsAPI.Services.IService;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EPES.Services.NotificationsAndAlertsAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("schedule")]
        public IActionResult ScheduleEmail([FromBody] EmailRequest request)
        {
            // Schedule the email using Hangfire
            BackgroundJob.Schedule(() => _emailService.SendEmailAsync(request.To, request.Subject, request.Body), request.SendTime);
            return Ok("Email scheduled successfully");
        }

        [HttpPost("send-test-email")]
        public async Task<IActionResult> SendTestEmail()
        {
            // Hardcode a sample employee's email address (replace with your email)
            string toEmail = "jimteshjimu4444@gmail.com";

            // Create a sample employee
            var sampleEmployee = new EmployeeDto
            {
                ID = "1",
                Email = toEmail,
                Name = "Sample Employee",
                PhoneNumber = "123-456-7890"
            };

            // Construct a sample email request
            var emailRequest = new EmailRequest
            {
                To = sampleEmployee.Email,
                Subject = "Test Email Subject",
                Body = "This is a test email body sent by Bhargav."
            };

            // Send the test email immediately
            await _emailService.SendEmailAsync(emailRequest.To, emailRequest.Subject, emailRequest.Body);

            return Ok("Test email sent successfully");
        }
    }
}
