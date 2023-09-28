using AutoMapper;
using EPES.Services.FeedbackAndCommentAPI.Models;
using EPES.Services.FeedbackAndCommentAPI.Models.Dto;

namespace EPES.Services.FeedbackAndCommentAPI
{
	public class MappingConfig
	{
		public static MapperConfiguration RegisterMaps()
		{
			var mappingConfig = new MapperConfiguration(config =>
			{
				config.CreateMap<FeedbackDto, Feedback>().ReverseMap();
				
			});
			return mappingConfig;
		}
	}
}
