using AutoMapper;
using EPES.Services.AuthAPI.Data;
using EPES.Services.AuthAPI.Models;
using EPES.Services.AuthAPI.Models.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EPES.Services.AuthAPI.Controllers
{
    [Route("api/profile")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        [HttpGet]
        // Use the [Authorize] attribute to ensure only authenticated users can access this endpoint
        public async Task<ActionResult<ResponseDto>> Get()
        {
            try
            {
                // Get the current user's email
                string userEmail = User.FindFirst(ClaimTypes.Email)?.Value;

                if (string.IsNullOrEmpty(userEmail))
                {
                    _response.IsSuccess = false;
                    _response.Message = "Email not found for the current user.";
                    return BadRequest(_response);
                }

                // Find the user by email
                var user = await _userManager.FindByEmailAsync(userEmail);

                if (user == null)
                {
                    _response.IsSuccess = false;
                    _response.Message = "User not found.";
                    return NotFound(_response);
                }

                // You can now use the 'user' object to access the user's profile or other properties

                var userDto = _mapper.Map<UserDto>(user);
                _response.Result = userDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }

            return _response;
        }
    }
}
