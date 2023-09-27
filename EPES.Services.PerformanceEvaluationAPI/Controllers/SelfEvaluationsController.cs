using EPES.Services.AuthAPI.Data;
using EPES.Services.PerformanceEvaluationAPI.Models;
using EPES.Services.PerformanceEvaluationAPI.Service.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace EPES.Services.PerformanceEvaluationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelfEvaluationsController : ControllerBase
    {
        private readonly AppDbContext _context; // Your DbContext
        private readonly ISelfEvaluationService _evaluationService;


        public SelfEvaluationsController(AppDbContext context,ISelfEvaluationService evaluationService)
        {
            _context = context;
            _evaluationService = evaluationService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSelfEvaluation([FromBody] SelfEvaluation selfEvaluation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Set the submission date to the current date and time.
            selfEvaluation.SubmissionDate = DateTime.Now;

          var result= await _evaluationService.CreateSelfEvaluation(selfEvaluation);
            if(result==null)
            {
                return NotFound();
            }

            

            return Ok(result); // Return the created self-evaluation.
        }
    }
}
