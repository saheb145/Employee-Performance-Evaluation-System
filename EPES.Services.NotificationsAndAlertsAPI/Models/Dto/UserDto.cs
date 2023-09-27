using System.ComponentModel.DataAnnotations;

namespace EPES.Services.NotificationsAndAlertsAPI.Models.Dto
{
    public class UserDto
    {

        public string ID { get; set; }
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

    }
}
