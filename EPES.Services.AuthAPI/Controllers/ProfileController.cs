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
		private IMapper _mapper;

		public ProfileController(IProfileByEmail profileByEmail, AppDbContext db, IMapper mapper)

		{
			_profileByEmail = profileByEmail;
			_response = new ResponseDto();
			_db = db;
			_mapper = mapper;
		}

		
		[HttpGet]
		public ResponseDto FetchUserDataByUserId(string userId)
		{
			try
			{
				List<UserDto> profiles = _profileByEmail.FetchUserDataByUserId(userId);



				if (profiles != null && profiles.Count > 0)
				{
					var employeeDtos = _mapper.Map<IEnumerable<UserDto>>(profiles);
					_response.Result = employeeDtos;
				}
				
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