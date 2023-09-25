using Microsoft.AspNetCore.Mvc;
using EPES.Services.PerformanceEvaluationAPI.Data;
using EPES.Services.PerformanceEvaluationAPI.Models;
using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;



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
        // GET: api/<SelfEvaluationAPIController>
        [HttpGet]
        [Authorize(Roles = "EMPLOYEE")]
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

        // GET api/<SelfEvaluationAPIController>/5
        [HttpGet("{userDtoemail}")]
        [Authorize(Roles = "EMPLOYEE")]
        public ResponseDto Get(string userDtoemail)
        {
            try
            {
                SelfEvaluation obj = _db.SelfEvaluations.First(u => u.EmployeeEmail== userDtoemail); 
                _response.Result = _mapper.Map<SelfEvaluationDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // POST api/<SelfEvaluationAPIController>
        [HttpPost]
       [Authorize(Roles = "EMPLOYEE")]
        public ResponseDto Post([FromBody] SelfEvaluationDto selfEvaluationDto)
        {
     
            
            try
            {
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

        
        [HttpPut("{id:int}")]
        [Authorize(Roles = "EMPLOYEE")]
        public ResponseDto Put([FromBody] SelfEvaluationDto selfEvaluationDto)
        {
            try
            {
                SelfEvaluation obj = _mapper.Map<SelfEvaluation>(selfEvaluationDto);
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

        // DELETE api/<SelfEvaluationAPIController>/5
        [HttpDelete("{id}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                SelfEvaluation obj = _db.SelfEvaluations.First(u => u.Id == id); // will delete by selfEvaluation Id
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
