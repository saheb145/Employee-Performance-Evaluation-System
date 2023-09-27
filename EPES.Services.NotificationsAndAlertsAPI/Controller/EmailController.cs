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

			try
			{
				// Replace with the actual URL of the API that provides employee data
				string apiUrl = "https://localhost:7002/api/user";

				// Make an HTTP GET request to the API
				using (var httpClient = new HttpClient())
				{
					// Send the GET request to the API to fetch employee data
					HttpResponseMessage response = await httpClient.GetAsync(apiUrl);

					// Check if the request was successful
					if (response.IsSuccessStatusCode)
					{
						// Deserialize the response content to a list of employees
						var employees = await response.Content.ReadAsAsync<ApiResponseDto>();

						// For this example, let's assume the API returns a list of EmployeeDto objects
						var result = employees.Result;
						// Now, you can send emails to all employees or perform any other operations you need
						foreach (var employee in result)
						{
							var emailRequest = new EmailRequest
							{
								To = employee.Email,
								Subject = "Remainder For SelfEvaluation",
								Body = "Hii folks, Manager of EPES this side . Your deadline is about to over .Please Re-SelfEvaluate your self befor deadline  Thanks and Regards  Manager EPES"
								

							};

							// Send the email using your _emailService
							await _emailService.SendEmailAsync(emailRequest.To, emailRequest.Subject, emailRequest.Body);
						}

						return Ok("Test emails sent successfully to all employees");
					}
					else
					{
						// Handle the API error response here if needed
						return StatusCode((int)response.StatusCode, "Failed to fetch employee data from the API");
					}
				}
			}
			catch (Exception ex)
			{
				// Handle exceptions that may occur during the API request or email sending process
				return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred: {ex.Message}");
			}
		
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
