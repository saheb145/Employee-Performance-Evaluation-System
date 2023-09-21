using EPES.Web.Models;
using EPES.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EPES.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService )
        {
            _userService= userService;
        }
        public async  Task<IActionResult> UserIndex()
        {
            List<ApplicationUserDto>? list = new();

            ResponseDto? response = await _userService.GetAllUserAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ApplicationUserDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }
    }
}
