using AutoMapper;
using EPES.Services.FeedbackAndCommentAPI.Data;
using EPES.Services.FeedbackAndCommentAPI.Models;
using EPES.Services.FeedbackAndCommentAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EPES.Services.FeedbackAndCommentAPI.Controllers
{
	public class FeedbackAndComment : Controller
	{
		private readonly AppDbContext _db;
		private ResponseDto _response;
		private IMapper _mapper;

		public FeedbackAndComment(AppDbContext db, IMapper mapper)
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
	//	[Authorize(Roles = "EMPLOYEE")]
		public ResponseDto Post([FromBody] FeedbackDto feedbackDto)
		{
			try
			{
				Feedback existingEvaluation = _db.Feedbacks.FirstOrDefault(e => e.EmployeeEmail == feedbackDto.EmployeeEmail);

				if (existingEvaluation != null)
				{
					DateTime curretntDate = (DateTime)feedbackDto.CreatedDate;
					// Check if SubmissionDate is more than six months ago
					if (existingEvaluation.CreatedDate.AddMonths(6) <= curretntDate)
					{
						_db.Feedbacks.Remove(existingEvaluation);

						_db.SaveChanges();
					}
					else
					{
						// If SubmissionDate is less than six months ago, return from the function
						_response.IsSuccess = false;
						_response.Message = "An evaluation record already exists within six months.";
						return _response;
					}
				}

				// Create a new SelfEvaluation from the DTO
				Feedback feedback = _mapper.Map<Feedback>(feedbackDto);
				_db.Feedbacks.Add(feedback);
				_db.SaveChanges();

				_response.Result = _mapper.Map<FeedbackDto>(feedback);
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
