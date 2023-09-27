using EPES.Services.PerformanceEvaluationAPI.Data;
using EPES.Services.PerformanceEvaluationAPI.Models;
using EPES.Services.PerformanceEvaluationAPI.Service.IService;

namespace EPES.Services.PerformanceEvaluationAPI.Service
{
    public class SelfEvaluationService : ISelfEvaluationService
    {
        private readonly AppDbContext _context;

        public SelfEvaluationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SelfEvaluation> CreateSelfEvaluation(SelfEvaluation selfEvaluation)
        {
            if (selfEvaluation == null)
            {
                throw new ArgumentNullException(nameof(selfEvaluation));
            }

            // Set the submission date to the current date and time.
            selfEvaluation.SubmissionDate = DateTime.Now;

            _context.SelfEvaluations.Add(selfEvaluation);
            await _context.SaveChangesAsync();

            return selfEvaluation;
        }

        // You can implement other methods from the ISelfEvaluationService interface here.
    }
}
