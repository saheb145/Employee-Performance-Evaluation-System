using System.ComponentModel.DataAnnotations;

namespace EPES.Web.Models
{
    public class EmployeeLoginRequestDto
    {
     
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
