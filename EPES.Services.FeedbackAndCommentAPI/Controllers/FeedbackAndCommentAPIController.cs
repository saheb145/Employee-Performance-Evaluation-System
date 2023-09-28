using AutoMapper;
using EPES.Services.FeedbackAndCommentAPI.Data;
using EPES.Services.FeedbackAndCommentAPI.Models;
using EPES.Services.FeedbackAndCommentAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EPES.Services.FeedbackAndCommentAPI.Controllers
{
	[Route("api/feedback")]
	[ApiController]
	public class FeedbackAndCommentAPIController : Controller
	{
		private readonly AppDbContext _db;
		private ResponseDto _response;
		private IMapper _mapper;

		public FeedbackAndCommentAPIController(AppDbContext db, IMapper mapper)
		{
			_db = db;
			_mapper = mapper;
			_response = new ResponseDto();

		}
		[HttpGet]
	//	[Authorize(Roles = "MANAGER")]
		public ResponseDto Get()
		{

			try
			{
				IEnumerable<Feedback> objList = _db.Feedbacks.ToList();
				_response.Result = _mapper.Map<IEnumerable<FeedbackDto>>(objList);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpGet("{employeeEmail}")]
		//[Authorize(Roles = "EMPLOYEE")]
		public ResponseDto Get(string employeeEmail)
		{
			try
			{
				Feedback obj = _db.Feedbacks.First(u => u.EmployeeEmail == employeeEmail);
				_response.Result = _mapper.Map<FeedbackDto>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}
	

		[HttpPost]
		// [Authorize(Roles = "EMPLOYEE")] 
		public ResponseDto Post([FromBody] FeedbackDto feedbackDto)
		{
			try
			{
				// Check if a feedback record already exists for the employee
				Feedback existingEvaluation = _db.Feedbacks.FirstOrDefault(e => e.EmployeeEmail == feedbackDto.EmployeeEmail);

				if (existingEvaluation != null)
				{

					DateTime currentDate = (DateTime)feedbackDto.CreatedDate; // Use UTC to avoid timezone issues
					DateTime sixMonthsAgo = currentDate.AddMonths(-6);

					// Check if the existing record was created more than six months ago
					if (existingEvaluation.CreatedDate <= sixMonthsAgo)
					{
						Feedback feedback = _mapper.Map<Feedback>(feedbackDto);
						_db.Feedbacks.Add(feedback);
						_db.SaveChanges();

						_response.IsSuccess = true;
						_response.Message = "Feedback record created successfully.";
						_response.Result = _mapper.Map<FeedbackDto>(feedback);
					}
					else
					{
						// If a record exists within six months, return an error response
						_response.IsSuccess = false;
						_response.Message = "An evaluation record already exists within six months.";
					}
				}
				else
				{
					// Create a new Feedback record if no previous record exists
					Feedback feedback = _mapper.Map<Feedback>(feedbackDto);
					_db.Feedbacks.Add(feedback);
					_db.SaveChanges();

					_response.IsSuccess = true;
					_response.Message = "Feedback record created successfully.";
					_response.Result = _mapper.Map<FeedbackDto>(feedback);
				}
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

	}
}
