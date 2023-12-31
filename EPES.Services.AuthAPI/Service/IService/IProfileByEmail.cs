﻿using EPES.Services.AuthAPI.Models.Dto;

namespace EPES.Services.AuthAPI.Service.IService
{
	public interface IProfileByEmail
	{
		List<UserDto> FetchUserDataByUserId(string userId);
	}
}
