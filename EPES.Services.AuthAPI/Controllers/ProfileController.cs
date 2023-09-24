using AutoMapper;
using EPES.Services.AuthAPI.Data;
using EPES.Services.AuthAPI.Models;
using EPES.Services.AuthAPI.Models.Dto;
using EPES.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EPES.Services.AuthAPI.Controllers
{
	[Route("api/profile")]
	[ApiController]
	public class ProfileController : ControllerBase
	{
		private readonly AppDbContext _db;
		private ResponseDto _response;
		private readonly IProfileByEmail _profileByEmail;
        public ProfileController(IProfileByEmail profileByEmail, AppDbContext db)

		{
			_profileByEmail = profileByEmail;
			
			_db = db;
		}

        [HttpGet("FetchUserData")]
		public IActionResult FetchUserDataByUserId(string userId)
		{
			try
			{
				List<UserDto> profiles = _profileByEmail.FetchUserDataByUserId(userId);



				if (profiles != null && profiles.Count > 0)
				{
					return Ok(profiles);
				}
				else
				{
					return NotFound($"User with ID {userId} not found.");
				}
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"Internal server error: {ex.Message}");
			}
		}
	}
}