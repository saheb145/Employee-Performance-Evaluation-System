using EPES.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EPES.Web.Services.IServices;
using EPES.Web.Utility;
using EPES.Web.Services;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EPES.Web.Controllers
{
    public class SelfEvaluationController : Controller
    {
        private readonly IEvaluationService _evaluationService;
		private readonly IProfileService _profileService;
		private ResponseDto _response;
		public SelfEvaluationController(IEvaluationService evaluationService, IProfileService profileService)
        {
            _evaluationService = evaluationService;
            _profileService = profileService;
			_response = new ResponseDto();

		}

      
        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SelfEvaluationIndex()
        {
            List<SelfEvaluationDto>? list = new();

            ResponseDto? response = await _evaluationService.GetAllEvaluationsAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<SelfEvaluationDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public async Task<IActionResult> CreateSelfEvaluation()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSelfEvaluation(SelfEvaluationDto model)
        {
            
            if (ModelState.IsValid)
            {
                ResponseDto? response = await _evaluationService.CreateEvaluationAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "SelfEvaluation created successfully";
                    return RedirectToAction("Index", "Home");
					
				}
                else
                {
                    TempData["error"] = response?.Message;
                }

            }
            return View(model);
        }

      
     
        public async Task<IActionResult> SelfEvaluationByEmail()
		{
            string email = User.Identity.Name;


            SelfEvaluationDto obj = new();

			ResponseDto? response = await _evaluationService.GetEvaluationByEmialAsync(email);



            if (response != null && response.IsSuccess)
			{
				obj = JsonConvert.DeserializeObject<SelfEvaluationDto>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return View(obj);
		}
	

        
    }
}
