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
					/* RedirectToAction(nameof(Index));*/
				}
                else
                {
                    TempData["error"] = response?.Message;
                }

            }
            return View(model);
        }

		/*[HttpGet("{email}")]*/

		public async Task<IActionResult> SelfEvaluationByEmail(string email)
		{
			/*string email = User.Identity.Name;*/

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
		// GET: SelfEvaluationController1/Details/5
		public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SelfEvaluationController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SelfEvaluationController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: SelfEvaluationController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
        // POST: SelfEvaluationController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
