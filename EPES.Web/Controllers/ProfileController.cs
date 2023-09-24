using EPES.Web.Models;
using EPES.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;

namespace EPES.Web.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
     
		public async Task<IActionResult> ProfileIndex() 
        {
			string email = User.Identity.Name;

			List<UserDto>? list = new();
            
            ResponseDto? response = await _profileService.GetProfileByEmail(email);


			if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<UserDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

    }
}
