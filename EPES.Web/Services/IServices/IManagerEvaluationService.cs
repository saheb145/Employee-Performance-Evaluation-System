using EPES.Web.Models;

namespace EPES.Web.Services.IServices
{
	public interface  IManagerEvaluationService 
	{
		Task<ResponseDto?> CreateManagerEvaluationAsync(ManagerEvaluationDto managerEvaluationDto);
		Task<ResponseDto?> GetAllManagerEvaluationsAsync();
		Task<ResponseDto?> GetManagerEvaluationByIdAsync(int id);
	}
}
