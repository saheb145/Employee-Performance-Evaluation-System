namespace EPES.Services.NotificationsAndAlertsAPI.Models
{
    public class EmailRequest
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendTime { get; set; }
    }
}
