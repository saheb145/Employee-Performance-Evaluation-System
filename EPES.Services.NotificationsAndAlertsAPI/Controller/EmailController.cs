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
        private readonly IReminderService _reminderService;

        public EmailController(IEmailService emailService, IReminderService reminderService)
        {
            _emailService = emailService;
            _reminderService = reminderService;
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
            string toEmail = "bhargxv33@gmail.com";

            // Create a sample employee
            var sampleEmployee = new UserDto
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
        [HttpPost("send-reminder-emails")]
        public async Task<IActionResult> SendReminderEmails()
        {
            try
            {
                // Call the SendReminderEmailsAsync method from the IReminderService
                await _reminderService.SendReminderEmailsAsync();

                return Ok("Reminder emails sent successfully");
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, e.g., log the error
                return StatusCode(500, "An error occurred while sending reminder emails");
            }
        }
    }
}
