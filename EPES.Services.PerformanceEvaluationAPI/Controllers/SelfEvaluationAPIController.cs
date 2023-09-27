using Microsoft.AspNetCore.Mvc;
using EPES.Services.PerformanceEvaluationAPI.Data;
using EPES.Services.PerformanceEvaluationAPI.Models;
using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;


namespace EPES.Services.PerformanceEvaluationAPI.Controllers
{
   [Route("api/selfevaluation")]
   [ApiController]
   [Authorize]
   
    public class SelfEvaluationAPIController : ControllerBase
    {

        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
	
		public SelfEvaluationAPIController(AppDbContext db, IMapper mapper)
		{ 
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
			
        }
        [HttpGet]
        [Authorize(Roles = "MANAGER")]
        public ResponseDto Get()
        {

            try
            {
                IEnumerable<SelfEvaluation> objList = _db.SelfEvaluations.ToList();
                _response.Result = _mapper.Map<IEnumerable<SelfEvaluationDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("{employeeEmail}")]
        [Authorize(Roles = "EMPLOYEE")]
        public ResponseDto Get(string employeeEmail)
        {
            try
            {
                SelfEvaluation obj = _db.SelfEvaluations.First(u => u.EmployeeEmail== employeeEmail); 
                _response.Result = _mapper.Map<SelfEvaluationDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
		[HttpPost]
		[Authorize(Roles = "EMPLOYEE")]
		public ResponseDto Post([FromBody] SelfEvaluationDto selfEvaluationDto)
		{
			try
			{
				SelfEvaluation existingEvaluation = _db.SelfEvaluations.FirstOrDefault(e => e.EmployeeEmail == selfEvaluationDto.EmployeeEmail);

				if (existingEvaluation != null)
				{
					DateTime curretntDate = (DateTime)selfEvaluationDto.SubmissionDate;
					// Check if SubmissionDate is more than six months ago
					if (existingEvaluation.SubmissionDate.Value.AddMonths(6) <= curretntDate)
					{
						_db.SelfEvaluations.Remove(existingEvaluation);
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
				SelfEvaluation evaluation = _mapper.Map<SelfEvaluation>(selfEvaluationDto);
				_db.SelfEvaluations.Add(evaluation);
				_db.SaveChanges();

				_response.Result = _mapper.Map<SelfEvaluationDto>(evaluation);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}


		[HttpPut("{employeeEmail}")]
		[Authorize(Roles = "EMPLOYEE")]
		public ResponseDto Put(string employeeEmail, [FromBody] SelfEvaluationDto selfEvaluationDto)
		{
			try
			{
				
				SelfEvaluation obj = _db.SelfEvaluations.SingleOrDefault(e => e.EmployeeEmail == employeeEmail);

				if (obj == null)
				{
					
					_response.IsSuccess = false;
					_response.Message = "SelfEvaluation record not found for the provided email.";
					return _response;
				}
				obj.SubmissionDate = selfEvaluationDto.SubmissionDate;
				obj.TaskCompleted = selfEvaluationDto.TaskCompleted;
				obj.EmployeeEmail = selfEvaluationDto.EmployeeEmail;
				obj.Technical = selfEvaluationDto.Technical;
				obj.Communication = selfEvaluationDto.Communication;
				obj.Adaptability = selfEvaluationDto.Adaptability;
				obj.TimeManagement = selfEvaluationDto.TimeManagement;
				obj.GoalAchievement = selfEvaluationDto.GoalAchievement;

				_db.SelfEvaluations.Update(obj);
				_db.SaveChanges();

				_response.Result = _mapper.Map<SelfEvaluationDto>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}

		[HttpDelete("{employeeEmail}")]
		[Authorize(Roles = "EMPLOYEE")]
		public ResponseDto Delete(string employeeEmail)
		{
			try
			{
				
				SelfEvaluation obj = _db.SelfEvaluations.SingleOrDefault(e => e.EmployeeEmail == employeeEmail);

				if (obj == null)
				{
					
					_response.IsSuccess = false;
					_response.Message = "SelfEvaluation record not found for the provided email.";
					return _response;
				}

				
				_db.SelfEvaluations.Remove(obj);
				_db.SaveChanges();
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
