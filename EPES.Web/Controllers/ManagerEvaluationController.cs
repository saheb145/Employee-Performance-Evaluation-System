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
					return RedirectToAction("Index","Home");
				}
				else
				{
					TempData["error"] = response?.Message;
				}

			}
			return View(model);
		}
		[HttpGet]

		public async Task<IActionResult> ManagerEvaluationByEmail()
		{
            string email = User.Identity.Name;
            ResponseDto? response = await _managerevaluationService.GetManagerEvaluationByIdAsync(email);

			ManagerEvaluationDto obj = new ManagerEvaluationDto();		
			if (response != null && response.IsSuccess)
			{
				obj = JsonConvert.DeserializeObject<ManagerEvaluationDto>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return View(obj);
		}
		
	}
}
