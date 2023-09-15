using AutoMapper;
using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using EPES.Services.PerformanceEvaluationAPI.Models;

namespace EPES.Services.PerformanceEvaluationAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<SelfEvaluationDto, SelfEvaluation>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
