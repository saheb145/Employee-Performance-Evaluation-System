using Microsoft.AspNetCore.Mvc;
using EPES.Services.PerformanceEvaluationAPI.Data;
using EPES.Services.PerformanceEvaluationAPI.Models;
using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPES.Services.PerformanceEvaluationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        // GET api/<ManagerEvaluationAPIController>/5
        [HttpGet("{id}")]
        public ResponseDto Get(int id)
        {
            try
            {
                ManagerEvaluation obj = _db.ManagerEvaluations.First(u => u.Id == id); // we will get the selfEvaluation data by EmployeeId
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
        public ResponseDto Post(ManagerEvaluationDto ManagerEvaluationDto)
        {
			
			try
            {
				ManagerEvaluation evaluation = _mapper.Map<ManagerEvaluation>(ManagerEvaluationDto);
                _db.ManagerEvaluations.Add(evaluation);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // PUT api/<ManagerEvaluationAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ManagerEvaluationAPIController>/5
        [HttpDelete("{id}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                ManagerEvaluation obj = _db.ManagerEvaluations.First(u => u.Id == id); // will delete by selfEvaluation Id
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
