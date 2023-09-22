
    using EPES.Web.Models;

namespace EPES.Web.Services.IServices
{
    public interface IEvaluationService
    {
        Task<ResponseDto?> CreateEvaluationAsync(SelfEvaluationDto selfEvaluationDto);
        Task<ResponseDto?> GetAllEvaluationsAsync( );
        Task<ResponseDto?> GetEvaluationByEmialAsync( string email);


    }
}
