using EPES.Services.PerformanceEvaluationAPI.Models;

namespace EPES.Services.PerformanceEvaluationAPI.Service.IService
{
    public interface ISelfEvaluationService
    {
        //Task<SelfEvaluation> CreateSelfEvaluation(SelfEvaluation selfEvaluation);
        Task<SelfEvaluation> CreateSelfEvaluation(SelfEvaluation selfEvaluation);
    }
}
