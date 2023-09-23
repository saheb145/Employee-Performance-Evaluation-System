using EPES.Web.Utility;

namespace EPES.Web.Models
{
    public class EmployeeDto
    {
      
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string? Role { get; set; }
		public string? UniqueEID { get; set; }


	}
}
