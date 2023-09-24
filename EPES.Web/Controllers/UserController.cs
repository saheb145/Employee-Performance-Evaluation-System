using EPES.Web.Models;
using EPES.Web.Services.IServices;
using Microsoft.AspNetCore.Identity;
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
         
            UserDto userDto= new UserDto();

            ResponseDto? response = await _userService.GetAllUserAsync();

            if (response != null && response.IsSuccess)
            {
				userDto = JsonConvert.DeserializeObject<UserDto>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(userDto);
        }

       
    }
}
