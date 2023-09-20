using EPES.Web.Models;
using EPES.Web.Services.IServices;
using EPES.Web.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace EPES.Web.Controllers
{
    public class UserMangementController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ITokenProvider _tokenProvider;
        public UserMangementController(IEmployeeService employeeService, ITokenProvider tokenProvider)
        {
            _employeeService = employeeService;
            _tokenProvider = tokenProvider;
        }


        public async Task<IActionResult> EmployeeIndex()
        {
            List<EmployeeDto>? list = new();

            ResponseDto? response = await _employeeService.GetAllEmployeesAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EmployeeDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }
        public async Task<IActionResult> EmployeeDetails(int id)
        {
            EmployeeDto employee = new EmployeeDto(); // Initialize to null or an appropriate default value

            ResponseDto response = await _employeeService.GetEmployeeByIdAsync(id);

            if (response != null && response.IsSuccess)
            {
                employee = JsonConvert.DeserializeObject<EmployeeDto>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
                /* return RedirectToAction("EmployeeIndex"); */// Redirect to the employee list if there's an error
                return RedirectToAction("EmployeeDetails");
            }

            return View(employee);
        }

        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDto model)
        {
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _employeeService.CreateEmployeeAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Employee created successfully";
                    return RedirectToAction(nameof(EmployeeIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }

            }
            return View(model);
        }

        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            ResponseDto? response = await _employeeService.GetEmployeeByIdAsync(Id);

            if (response != null && response.IsSuccess)
            {
                EmployeeDto? model = JsonConvert.DeserializeObject<EmployeeDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(EmployeeDto employeeDto)
        {
            ResponseDto? response = await _employeeService.DeleteEmployeeAsync(employeeDto.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Employee deleted successfully";
                return RedirectToAction(nameof(EmployeeIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(employeeDto);
        }
        private async Task SignInUser(EmployeeLoginResponseDto model)
        {


            var handler = new JwtSecurityTokenHandler();

            var jwt = handler.ReadJwtToken(model.Token);

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Sub).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Name).Value));


            identity.AddClaim(new Claim(ClaimTypes.Name,
                jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value));
            identity.AddClaim(new Claim(ClaimTypes.Role,
                jwt.Claims.FirstOrDefault(u => u.Type == "role").Value));


            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
        [HttpGet]
        public IActionResult Login()
        {

            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDto = await _employeeService.LoginAsync(obj);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto =
                    JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                // await SignInUser(loginResponseDto);
                //_tokenProvider.SetToken(loginResponseDto.Token);
                return RedirectToAction("Privacy", "Home");
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View(obj);

            }


        }


    
    /* [HttpGet]
     public IActionResult Login()
     {

         LoginRequestDto loginRequestDto = new();
         return View(loginRequestDto);
     }
     [HttpPost]
     public async Task<IActionResult> Login(LoginRequestDto obj)
     {
         ResponseDto responseDto = await _employeeService.LoginAsync(obj);

         if (responseDto != null && responseDto.IsSuccess)
         {
             EmployeeLoginResponseDto employeeLoginResponseDto =
                 JsonConvert.DeserializeObject<EmployeeLoginResponseDto>(Convert.ToString(responseDto.Result));

             await SignInUser(employeeLoginResponseDto);
             _tokenProvider.SetToken(employeeLoginResponseDto.Token);
             return RedirectToAction("Index", "Home");
         }
         else
         {
             TempData["error"] = responseDto.Message;
             return View(obj);

         }


     }
     public async Task<IActionResult> Logout()
     {
         await HttpContext.SignOutAsync();
         _tokenProvider.ClearToken();

         return RedirectToAction("Index", "Home");

     }*/
}

}