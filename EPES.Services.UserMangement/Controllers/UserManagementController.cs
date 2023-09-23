using AutoMapper;
using Azure;
using EPES.Services.UserMangement.Data;
using EPES.Services.UserMangement.Model;
using EPES.Services.UserMangement.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Stripe;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPES.Services.UserMangement.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class UserManagementController : ControllerBase

    {
        private readonly AppDbContext _db;
        private ResponseDto _response;
        private IMapper _mapper;
        public UserManagementController(AppDbContext appDbContext, IMapper mapper)
        {
            _db = appDbContext;
            _mapper = mapper;
            _response = new ResponseDto();
        }
		
		// GET: api/<UserManagementController>
		[HttpGet]
        public ResponseDto Get()
        {
            try
            {
                IEnumerable<Employee> objList = _db.Employees.ToList();
                _response.Result = _mapper.Map<IEnumerable<EmployeeDto>>(objList);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // GET api/<UserManagementController>/5
        [HttpGet("{id:int}")]
        public ResponseDto Get(int id)
        {
            try
            {
                Employee obj = _db.Employees.First(u => u.Id == id);
                _response.Result = _mapper.Map<EmployeeDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // POST api/<UserManagementController>
        [HttpPost]
        public ResponseDto Post([FromBody] EmployeeDto employeeDto)
        {
			
			try
            {
				
				Employee obj = _mapper.Map<Employee>(employeeDto);
                _db.Employees.Add(obj);
                _db.SaveChanges();

                 _response.Result = _mapper.Map<EmployeeDto>(obj);
              
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
       
        }


        // PUT api/<UserManagementController>/5
        [HttpPut("{id:int}")]
        public ResponseDto Put([FromBody] EmployeeDto employeeDto)
        {
            try
            {
                Employee obj = _mapper.Map<Employee>(employeeDto);
                _db.Employees.Update(obj);
                _db.SaveChanges();

                _response.Result = _mapper.Map<EmployeeDto>(obj);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        // DELETE api/<UserManagementController>/5
        [HttpDelete("{id:int}")]
        public ResponseDto Delete(int id)
        {
            try
            {
                Employee obj = _db.Employees.First(u => u.Id == id);
                _db.Employees.Remove(obj);
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
