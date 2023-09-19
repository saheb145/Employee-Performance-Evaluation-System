
    using EPES.Web.Models;

namespace EPES.Web.Services.IServices
{
    public interface IEvaluationService
    {
        Task<ResponseDto?> CreateEvaluationAsync(SelfEvaluationDto selfEvaluationDto);
    }
}
