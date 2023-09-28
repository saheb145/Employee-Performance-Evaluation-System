/*using EPES.Web.Models;
using EPES.Web.Services.IServices;
using EPES.Web.Utility;

namespace EPES.Web.Services
{
	public class FeedbackService:IFeedbackService
	{
		private readonly IBaseService _baseService;
		public FeedbackService(IBaseService baseService)
		{
			_baseService = baseService;
		}

		public async Task<ResponseDto?> CreateFeedbackAsync(FeedbackDto feedbackDto)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.POST,
				Data = feedbackDto,
				Url = SD.FeedbackAPIBase + "/api/feedback"
			});
		}

		public async Task<ResponseDto?> GetAllFeedbackAsync()
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.FeedbackAPIBase + "/api/feedback"
			});
		}

		public async Task<ResponseDto?> GetFeedbackByEmailAsync(string email)
		{
			return await _baseService.SendAsync(new RequestDto()
			{
				ApiType = SD.ApiType.GET,
				Url = SD.SelfEvaluationAPIBase + "/api/feedback/" + email
			});


		}
	}
}
*/