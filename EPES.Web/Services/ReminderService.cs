using EPES.Services.NotificationsAndAlertsAPI.Services.IService;
//using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using Newtonsoft.Json;

namespace EPES.Services.NotificationsAndAlertsAPI.Services
{
    public class ReminderService : BackgroundService, IReminderService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<ReminderService> _logger;
        private readonly EmailService _emailService;
        public ReminderService(IServiceProvider serviceProvider, ILogger<ReminderService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();

                        // Implement your reminder logic here
                        // Query external microservices or data sources for upcoming deadlines and send reminders

                        // Sleep for some time (e.g., 1 hour) before checking again
                        await Task.Delay(TimeSpan.FromHours(1), stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while sending reminders.");
                }
            }
        }


        public async Task SendReminderEmailsAsync()
        {
            /*try
            {
                // Fetch necessary data from external sources or services
                var employeesWithUpcomingDeadlines = FetchEmployeesWithUpcomingDeadlines();

                // Iterate through the data and send reminder emails
                foreach (var employee in employeesWithUpcomingDeadlines)
                {
                    // Calculate the time until the deadline and decide whether to send a reminder
                    var timeUntilDeadline = employee.Deadline - DateTime.UtcNow;

                    // Send a reminder email if the deadline is approaching (e.g., within 24 hours)
                    if (timeUntilDeadline <= TimeSpan.FromHours(24))
                    {
                        var subject = "Reminder: Self-Evaluation Deadline";
                        var body = $"Dear {employee.Name},\n\nThis is a friendly reminder that your self-evaluation is due in {timeUntilDeadline.TotalHours} hours. Please submit it before the deadline.\n\nSincerely,\nYour Company";

                        await _emailService.SendEmailAsync(employee.Email, subject, body);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the reminder email sending process
                // You can log the error or take appropriate actions
            }*/

        }

       /* private async Task<List<EmployeeDto>> FetchEmployeesWithUpcomingDeadlines()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://selfevaluation-api/employees/upcoming-deadlines");

                if (response.IsSuccessStatusCode)
                {


                    var content = await response.Content.ReadAsStringAsync();
                    var employees = JsonConvert.DeserializeObject<List<EmployeeDto>>(content);

                    return employees;
                }

                // Handle the case when the HTTP request fails or returns an error
                return new List<EmployeeDto>(); // Return an empty list or handle the error as needed
            }
        }*/


        /*private async Task<List<SelfEvaluationDto>> FetchEmployeesWithUpcomingDeadlines()
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync("https://selfevaluation-api/employees/upcoming-deadlines");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var employees = JsonConvert.DeserializeObject<List<SelfEvaluationDto>>(content);

                    return employees;
                }

                return new List<SelfEvaluationDto>();
            }
        }*/

        /*private List<Employee> FetchEmployeesWithUpcomingDeadlines()
        {
            // Fetch data from external sources or services (e.g., Self-Evaluation microservice)
            // Return a list of employees with upcoming deadlines
            // This method should retrieve the necessary data for sending reminders
            // You may use HTTP requests or other communication methods to obtain this data
            // If the data is available through APIs, consider using HttpClient to make requests
            // Example:
            // var response = httpClient.GetAsync("https://selfevaluation-api/employees/upcoming-deadlines").Result;
            // var employees = response.Content.ReadAsAsync<List<Employee>>().Result;
            // return employees;

            // For demonstration purposes, you can return a sample list
            return new List<Employee>
            {
                new Employee { Name = "John Doe", Email = "john@example.com", Deadline = DateTime.UtcNow.AddHours(48) },
                new Employee { Name = "Jane Smith", Email = "jane@example.com", Deadline = DateTime.UtcNow.AddHours(12) }
            };
        }*/
    }
}
