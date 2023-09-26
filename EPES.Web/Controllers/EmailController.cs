/*
using EPES.Services.NotificationsAndAlertsAPI.Models;
using EPES.Services.NotificationsAndAlertsAPI.Models.Dto;
using EPES.Services.NotificationsAndAlertsAPI.Services.IService;
using EPES.Web.Models;
using EPES.Web.Services;
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
        private readonly EmployeeService _employeeService;
        private readonly IEmailService _emailService;

        public EmailController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("schedule")]
        public IActionResult ScheduleEmail([FromBody] EmailRequestDto request)
        {
            // Schedule the email using Hangfire
            BackgroundJob.Schedule(() => _emailService.SendEmailAsync(request.To, request.Subject, request.Body), request.SendTime);
            return Ok("Email scheduled successfully");
        }



        [HttpPost]
        public async Task<ActionResult> SendSampleEmail()
        {
            // Retrieve all employees from the external API asynchronously
            var response = await _employeeService.GetAllEmployeesAsync();

            if (response != null && response.IsSuccess)
            {
                var employees = response.Result as IEnumerable<EmployeeDto>;

                if (employees != null)
                {
                    // Loop through the employees and send a sample email to each one
                    foreach (var employee in employees)
                    {
                        // Construct and send the sample email using your email service
                        var emailRequest = new EmailRequestDto
                        {
                            To = employee.Email,
                            Subject = "Sample Email Subject",
                            Body = "This is a sample email body.",
                        };

                        await _emailService.SendEmailAsync(emailRequest.To, emailRequest.Subject, emailRequest.Body);
                    }
                }
            }

            // Redirect back to the SendEmail page after sending emails
            return RedirectToAction("SendEmail");
        }




        [HttpPost("send-test-email")]
        public async Task<IActionResult> SendTestEmail()
        {
            // Hardcode a sample employee's email address (replace with your email)
            string toEmail = "jimteshjimu4444@gmail.com";

            // Create a sample employee
            var sampleEmployee = new EmployeeDto
            {
                Id = 1,
                Email = toEmail,
                Name = "Sample Employee",
                PhoneNumber = "123-456-7890"
            };

            // Construct a sample email request
            var emailRequest = new EmailRequestDto
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
*/