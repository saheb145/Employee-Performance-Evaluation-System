using EPES.Services.AuthAPI.Models;
using EPES.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace EPES.Services.AuthAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService=userService;
        }
		[HttpGet]
		public async Task<object> Get()
		{
			IEnumerable<ApplicationUser> response = await _userService.GetAllUsers();
            return response;
			
		}
		
    }
}
