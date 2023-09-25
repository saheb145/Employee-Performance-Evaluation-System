using EPES.Web.Services.IServices;
using EPES.Web.Models;
using EPES.Web.Utility;

namespace EPES.Web.Services
{
	public class ManagerEvaluationService : IManagerEvaluationService
	{
		private readonly IBaseService _baseService;
		public ManagerEvaluationService(IBaseService baseService)
		{
			_baseService = baseService;
		}
		public async Task<ResponseDto?> CreateManagerEvaluationAsync(ManagerEvaluationDto managerEvaluationDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = managerEvaluationDto,
				Url = SD.ManagerEvaluationAPIBase + "/api/managerevaluation"
			});
		}

		public async Task<ResponseDto?> GetAllManagerEvaluationsAsync()
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.ManagerEvaluationAPIBase + "/api/managerevaluation"
			});

		}
		public async Task<ResponseDto?> GetManagerEvaluationByIdAsync(int id)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.ManagerEvaluationAPIBase + "/api/managerevaluation"+id
			});

		}
	}
}
