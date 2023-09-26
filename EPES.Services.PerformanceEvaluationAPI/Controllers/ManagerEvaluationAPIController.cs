using Microsoft.AspNetCore.Mvc;
using EPES.Services.PerformanceEvaluationAPI.Data;
using EPES.Services.PerformanceEvaluationAPI.Models;
using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPES.Services.PerformanceEvaluationAPI.Controllers
{
    [Route("api/managerevaluation")]
    [ApiController]
	[Authorize]
	public class ManagerEvaluationAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;

        public ManagerEvaluationAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
            _response = new ResponseDto();
        }
        // GET: api/<ManagerEvaluationAPIController>
        [HttpGet]
		[Authorize(Roles = "MANAGER")]
		public ResponseDto Get()
        {
            try
            {
                IEnumerable<ManagerEvaluation> objList = _db.ManagerEvaluations.ToList();
                _response.Result = _mapper.Map<IEnumerable<ManagerEvaluationDto>>(objList);
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
				ManagerEvaluation obj = _db.ManagerEvaluations.First(u => u.EmployeeEmail == employeeEmail); // we will get the selfEvaluation data by EmployeeId
				_response.Result = _mapper.Map<ManagerEvaluationDto>(obj);
			}
			catch (Exception ex)
			{
				_response.IsSuccess = false;
				_response.Message = ex.Message;
			}
			return _response;
		}
		// POST api/<ManagerEvaluationAPIController>
		[HttpPost]
		[Authorize(Roles = "MANAGER")]
		public ResponseDto Post(ManagerEvaluationDto managerEvaluationDto)
        {   
            try
            {
                ManagerEvaluation evaluation = _mapper.Map<ManagerEvaluation>(managerEvaluationDto);
                _db.ManagerEvaluations.Add(evaluation);
                _db.SaveChanges();
				_response.Result = _mapper.Map<ManagerEvaluationDto>(evaluation);
			}
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

		[HttpPut("{employeeEmail}")]
		[Authorize(Roles = "MANAGER")]
		public ResponseDto Put(string employeeEmail, [FromBody] ManagerEvaluationDto managerEvaluationDto)
		{
			try
			{

				ManagerEvaluation obj = _db.ManagerEvaluations.SingleOrDefault(e => e.EmployeeEmail == employeeEmail);

				if (obj == null)
				{

					_response.IsSuccess = false;
					_response.Message = "ManagerEvaluation record not found for the provided email.";
					return _response;
				}

				// Update the properties of the found SelfEvaluation record
				// You can map and update the properties here as needed
				obj.EmployeeEmail = managerEvaluationDto.EmployeeEmail;
				obj.Remarks = managerEvaluationDto.Remarks;
				obj.Score = managerEvaluationDto.Score;
				

				// ... continue updating other properties

				_db.ManagerEvaluations.Update(obj);
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

		// DELETE api/<ManagerEvaluationAPIController>/5
		[HttpDelete("{employeeEmail}")]
		[Authorize(Roles = "MANAGER")]
		public ResponseDto Delete(string employeeEmail)
		{
			try
			{
				// Find the SelfEvaluation record by email
				ManagerEvaluation obj = _db.ManagerEvaluations.SingleOrDefault(e => e.EmployeeEmail == employeeEmail);

				if (obj == null)
				{

					_response.IsSuccess = false;
					_response.Message = "SelfEvaluation record not found for the provided email.";
					return _response;
				}

				// Remove the found SelfEvaluation record
				_db.ManagerEvaluations.Remove(obj);
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
