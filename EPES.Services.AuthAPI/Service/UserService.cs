using Azure;
using EPES.Services.AuthAPI.Data;
using EPES.Services.AuthAPI.Models;
using EPES.Services.AuthAPI.Models.Dto;
using EPES.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

/*namespace EPES.Services.AuthAPI.Service
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;

		public UserService(AppDbContext db, UserManager<ApplicationUser> userManager)
		{
			_db = db;
			_userManager = userManager;
		}
		public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
			// Implement logic to retrieve all users from your data store (e.g., database)

			var employees = await _userManager.GetUsersInRoleAsync("employee");


            // Map the retrieved data to UserDto objects and return
            *//*return obj.Select(u => new ApplicationUser
			{
                ID = u.Id,
                Email = u.Email,
                Name = u.Name,
                Password=u.PasswordHash,
                PhoneNumber=u.PhoneNumber
                // Include other user properties as needed
            });*//*
            return employees;
        }

		
	}
}
*/