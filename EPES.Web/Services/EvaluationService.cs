using EPES.Web.Models;
using EPES.Web.Services.IServices;
using EPES.Web.Utility;

namespace EPES.Web.Services
{
    public class EvaluationService :IEvaluationService
    {
        private readonly IBaseService _baseService;
        public EvaluationService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateEvaluationAsync(FeedbackDto feedbackDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = feedbackDto,
                Url = SD.SelfEvaluationAPIBase + "/api/selfevaluation"
            });
        }

        public async Task<ResponseDto?> GetAllEvaluationsAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SelfEvaluationAPIBase + "/api/selfevaluation"
            });
        }

        public async Task<ResponseDto?> GetEvaluationByEmialAsync(string email)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.SelfEvaluationAPIBase + "/api/selfevaluation/"+email
			});

     
        }
    }
}

