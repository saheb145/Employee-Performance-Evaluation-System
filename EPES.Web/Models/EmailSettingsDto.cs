namespace EPES.Web.Models
{
    public class EmailSettingsDto
    {
        public string? SmtpServer { get; set; }
        public int SmtpPort { get; set; }
        public string? SmtpUsername { get; set; }
        public string? SmtpPassword { get; set; }
        public string FromEmail { get; set; }
    }
}
