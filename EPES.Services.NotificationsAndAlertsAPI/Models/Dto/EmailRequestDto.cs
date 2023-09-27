namespace EPES.Services.NotificationsAndAlertsAPI.Models.Dto
{
    public class EmailRequestDto
    {
        
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime SendTime { get; set; }
    }

}
