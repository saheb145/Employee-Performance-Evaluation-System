using Microsoft.AspNetCore.Mvc;
using EPES.Services.PerformanceEvaluationAPI.Data;
using EPES.Services.PerformanceEvaluationAPI.Models;
using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

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
                _response.Message = "Already Done for this Employee";
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

                obj.EmployeeEmail = managerEvaluationDto.EmployeeEmail;
                obj.Remarks = managerEvaluationDto.Remarks;
                obj.Score = managerEvaluationDto.Score;

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


        [HttpDelete("{employeeEmail}")]
        [Authorize(Roles = "MANAGER")]
        public ResponseDto Delete(string employeeEmail)
        {
            try
            {

                ManagerEvaluation obj = _db.ManagerEvaluations.SingleOrDefault(e => e.EmployeeEmail == employeeEmail);

                if (obj == null)
                {

                    _response.IsSuccess = false;
                    _response.Message = "SelfEvaluation record not found for the provided email.";
                    return _response;
                }


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
