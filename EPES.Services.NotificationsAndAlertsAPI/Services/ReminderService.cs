using EPES.Services.NotificationsAndAlertsAPI.Data;
using EPES.Services.NotificationsAndAlertsAPI.Services.IService;
using EPES.Services.PerformanceEvaluationAPI.Models;
using Microsoft.EntityFrameworkCore;


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
            _emailService = serviceProvider.GetRequiredService<EmailService>(); // Initialize _emailService
        }


        public ReminderService()
        {

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
            try
            {
                // Calculate the current date
                var currentDate = DateTime.UtcNow;

                // Calculate the deadline date based on the current date
                DateTime deadlineDate;
                
                 if (currentDate.Month == 9 && currentDate.Day >= 24 && currentDate.Day <= 30)
                {
                    // Current date is in the last week of September, set deadline to October 1st of the current year
                    deadlineDate = new DateTime(currentDate.Year , 10, 1);
                }
                else if ((currentDate.Month >= 7 && currentDate.Month <= 12) || (currentDate.Month == 1 && currentDate.Day == 1))
                {
                    // Current date is between July 2nd and December 31st, or it's January 1st, set deadline to January 1st of the next year
                    deadlineDate = new DateTime(currentDate.Year + 1, 1, 1);
                }
                else
                {
                    // Current date is between January 2nd and June 31st, set deadline to July 1st of the current year
                    deadlineDate = new DateTime(currentDate.Year, 7, 1);
                }

                // Calculate the reminder date, which is three days before the deadline
                var reminderDate = deadlineDate.AddDays(-7);

                // Check if the current date is equal to or after the reminder date but before the deadline
                if (currentDate.Date >= reminderDate.Date && currentDate.Date <= deadlineDate.Date)
                {
                    // Fetch all employees from the database
                    List<User> employees = null;
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                        employees = await FetchEmployeesFromDatabaseAsync(dbContext);
                    }

                    // Iterate through the employees and send reminder emails
                    if (employees != null)
                    {
                        foreach (var employee in employees)
                        {
                            var subject = "Reminder: Self-Evaluation Deadline";
                            var body = $"Dear {employee.Name},\n\nThis is a friendly reminder that your self-evaluation is due on {deadlineDate:MMMM dd}. Please submit it before the deadline.Kindly Ignore if already done. :)\n\nSincerely,\nYour Company";

                            await _emailService.SendEmailAsync(employee.Email, subject, body);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that occur during the reminder email sending process
                // You can log the error or take appropriate actions
            }
        }




        public async Task<List<User>> FetchEmployeesFromDatabaseAsync(AppDbContext dbContext)
        {
            try
            {
                // Assuming you have a DbSet<User> in your DbContext named Users
                // Fetch all users from the database
                var users = await dbContext.Users.ToListAsync();

                return users;
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the database retrieval
                // You can log the error or take appropriate actions
                // For now, return an empty list
                return new List<User>();
            }
        }










    }
}