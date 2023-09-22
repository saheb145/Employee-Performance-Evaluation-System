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
        public SelfEvaluationController(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }
        // GET: SelfEvaluationController1
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

        public ActionResult SelfEvaluationById()
        {
            return View();
        }
        [HttpGet]
		public async Task<IActionResult> SelfEvaluationById(int id)
        {
			SelfEvaluationDto? evaluation = null;
			ResponseDto? response = await _evaluationService.GetEvaluationByIdAsync(id);

			if (response != null && response.IsSuccess)
			{
				evaluation = JsonConvert.DeserializeObject<SelfEvaluationDto>(Convert.ToString(response.Result));
			} 
			else
			{
				TempData["error"] = response?.Message;
			}
			return View(evaluation);
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
                    return RedirectToAction(nameof(SelfEvaluationIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }

            }
            return View(model);
        }


        // GET: SelfEvaluationController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SelfEvaluationController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SelfEvaluationController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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
