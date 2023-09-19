using Azure;
using EPES.Services.AuthAPI.Data;
using EPES.Services.AuthAPI.Models;
using EPES.Services.AuthAPI.Models.Dto;
using EPES.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EPES.Services.AuthAPI.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;

		public UserService(AppDbContext db)
        {

            _db = db;
           

		}
        public async Task<IEnumerable<EmployeeDto>> GetAllUsers()
        {
			// Implement logic to retrieve all users from your data store (e.g., database)

			
            var obj=_db.ApplicationUsers.ToList();
			// Map the retrieved data to UserDto objects and return
			return obj.Select(u => new EmployeeDto
			{
                ID = u.Id,
                Email = u.Email,
                Name = u.Name,
                Password=u.PasswordHash,
                PhoneNumber=u.PhoneNumber
                // Include other user properties as needed
            });
         
        }

		
	}
}
