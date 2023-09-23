﻿using Microsoft.AspNetCore.Mvc;
using EPES.Services.PerformanceEvaluationAPI.Data;
using EPES.Services.PerformanceEvaluationAPI.Models;
using EPES.Services.PerformanceEvaluationAPI.Models.Dto;
using AutoMapper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPES.Services.PerformanceEvaluationAPI.Controllers
{
    [Route("api/selfevaluation")]
    [ApiController]

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
        [HttpGet("{id}")]

        public ResponseDto Get(int id)
        {    
            try
            {
                SelfEvaluation obj = _db.SelfEvaluations.First(u => u.Id == id); // we will get the selfEvaluation data by EmployeeId
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
        public ResponseDto Post(SelfEvaluationDto SelfEvaluationDto)
        {
            try
            {
                SelfEvaluation evaluation = _mapper.Map<SelfEvaluation>(SelfEvaluationDto);
                _db.SelfEvaluations.Add(evaluation);
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // PUT api/<SelfEvaluationAPIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
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
