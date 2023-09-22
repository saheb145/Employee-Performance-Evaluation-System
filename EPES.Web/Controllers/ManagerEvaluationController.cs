using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EPES.Web.Models;
using EPES.Web.Services.IServices;
using Newtonsoft.Json;
using EPES.Web.Services;

namespace EPES.Web.Controllers

{
	public class ManagerEvaluationController : Controller
	{
		private readonly IManagerEvaluationService _managerevaluationService;
		public ManagerEvaluationController(IManagerEvaluationService managerevaluationService)
		{
			_managerevaluationService = managerevaluationService;
		}
		// GET: ManagerEvaluationController
		public ActionResult Index()
		{
			return View();
		}
		public async Task<IActionResult> ManagerEvaluationIndex()
		{
			List<ManagerEvaluationDto>? list = new();

			ResponseDto? response = await _managerevaluationService.GetAllManagerEvaluationsAsync();

			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<ManagerEvaluationDto>>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return View(list);
		}
        public async Task<IActionResult> CreateManagerEvaluation()
        {
            return View();
        }
        [HttpPost]
		public async Task<IActionResult> CreateManagerEvaluation(ManagerEvaluationDto model)
		{
			if (ModelState.IsValid)
			{
				ResponseDto? response = await _managerevaluationService.CreateManagerEvaluationAsync(model);

				if (response != null && response.IsSuccess)
				{
					TempData["success"] = "ManagerEvaluation created successfully";
					return RedirectToAction(nameof(ManagerEvaluationIndex));
				}
				else
				{
					TempData["error"] = response?.Message;
				}

			}
			return View(model);
		}

		// GET: ManagerEvaluationController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ManagerEvaluationController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ManagerEvaluationController/Create
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

		// GET: ManagerEvaluationController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ManagerEvaluationController/Edit/5
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

		// GET: ManagerEvaluationController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ManagerEvaluationController/Delete/5
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
