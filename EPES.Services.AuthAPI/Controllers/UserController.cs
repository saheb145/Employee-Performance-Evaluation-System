using EPES.Services.AuthAPI.Models;
using EPES.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Mvc;

namespace EPES.Services.AuthAPI.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService=userService;
        }
        public async Task<IActionResult> Index()
        {
            var response= await _userService.GetAllUsers();
            return View(response);
        }
    }
}
