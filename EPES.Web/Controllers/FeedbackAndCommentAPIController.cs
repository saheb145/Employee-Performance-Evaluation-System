/*using EPES.Web.Models;
using EPES.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EPES.Web.Controllers
{
	public class FeedbackAndCommentAPIController : Controller
	{
		private readonly IFeedbackService _feedbackService;
		private readonly IProfileService _profileService;
		private ResponseDto _response;
		public FeedbackAndCommentAPIController(IFeedbackService feedbackService, IProfileService profileService)
		{
			_feedbackService = feedbackService;
			_profileService = profileService;
			_response = new ResponseDto();

		}


		public ActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> FeedbackIndex()
		{
			List<FeedbackDto>? list = new();

			ResponseDto? response = await _feedbackService.GetAllFeedbackAsync();

			if (response != null && response.IsSuccess)
			{
				list = JsonConvert.DeserializeObject<List<FeedbackDto>>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return View(list);
		}

		public async Task<IActionResult> CreateFeedback()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateFeedback(FeedbackDto model)
		{

			if (ModelState.IsValid)
			{
				ResponseDto? response = await _feedbackService.CreateFeedbackAsync(model);

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



		public async Task<IActionResult> FeedbackByEmail()
		{
			string email = User.Identity.Name;


			FeedbackDto obj = new();

			ResponseDto? response = await _feedbackService.GetFeedbackByEmailAsync(email);



			if (response != null && response.IsSuccess)
			{
				obj = JsonConvert.DeserializeObject<FeedbackDto>(Convert.ToString(response.Result));
			}
			else
			{
				TempData["error"] = response?.Message;
			}

			return View(obj);
		}



	}
}

*/