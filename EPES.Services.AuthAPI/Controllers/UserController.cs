using AutoMapper;
using EPES.Services.AuthAPI.Data;
using EPES.Services.AuthAPI.Models;
using EPES.Services.AuthAPI.Models.Dto;
using EPES.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EPES.Services.AuthAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
	public class UserController : ControllerBase
	{
		private readonly AppDbContext _db;
		private ResponseDto _response;
		private IMapper _mapper;
		private readonly UserManager<ApplicationUser> _userManager;
		public UserController(AppDbContext db, IMapper mapper, UserManager<ApplicationUser> userManager)
		{
			_db = db;
			_response = new ResponseDto();
			_mapper = mapper;
			_userManager = userManager;
		}
		[HttpGet]
		public ResponseDto Get()
		{
			try
			{
				var employees = _userManager.GetUsersInRoleAsync("employee").Result;

				// Map the list of employees to ApplicationUserDto
				var employeeDtos = _mapper.Map<IEnumerable<ApplicationUserDto>>(employees);
				_response.Result = employeeDtos;
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
