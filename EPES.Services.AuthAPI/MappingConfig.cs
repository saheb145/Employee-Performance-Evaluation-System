using AutoMapper;
using EPES.Services.AuthAPI.Models;
using EPES.Services.AuthAPI.Models.Dto;

namespace EPES.Services.AuthAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<UserDto, ApplicationUser>();
				config.CreateMap<ApplicationUser, UserDto>();
			});
			return mappingConfig;
		}
	}
}
