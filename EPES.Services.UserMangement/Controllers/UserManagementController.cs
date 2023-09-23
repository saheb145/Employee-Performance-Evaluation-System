using AutoMapper;
using Azure;
using EPES.Services.UserMangement.Data;
using EPES.Services.UserMangement.Model;
using EPES.Services.UserMangement.Model.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Stripe;
using Token = NuGet.Common.Token;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EPES.Services.UserMangement.Controllers
{
    [Route("api/employee")]
    [ApiController]
   //  [Authorize]
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
       // [Authorize(Roles = "MANAGER")]
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
    //   [Authorize(Roles = "MANAGER")]
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
       // [Authorize(Roles = "MANAGER")]
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

      // 
        // PUT api/<UserManagementController>/5
        [HttpPut("{id:int}")]
      //  [Authorize(Roles = "MANAGER")]
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
     //   [Authorize(Roles = "MANAGER")]
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





        [HttpPost]
        public async Task<IActionResult> login(LoginRequestDto loginDto)
        {
            try
            {
                var Employee = await _db.Employees.SingleOrDefaultAsync(u => u.UserName == loginDto.UserName);

                if (Employee == null)
                {
                    return StatusCode(404, "Employee Not Found");
                }

                // Perform password validation (compare plain text password with stored hashed password)
                if (loginDto.Password != Employee.Password)
                {
                    return StatusCode(404, "Employee Not Found");
                }

             //   var xyz = new EmployeeDto(Name = Employee.Name, ID = Employee.Id)

                LoginResponseDto loginResponseDto = new LoginResponseDto()
                {
                    Employee = EmployeeDto;
                    token = Token;
                    // Token=""
                };

            return Ok(loginResponseDto);
        }
          


            
}
		/*[HttpPost("login")]
     //  [Authorize(Roles = "EMPLOYEE")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginDto)
		{
            

            if (!ModelState.IsValid)
            {
                return BadRequest(new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Invalid input data",
                    Result = ModelState
                });
            }

            // Find the user by username (or email, depending on your system)
            var Employee = await _db.Employees.SingleOrDefaultAsync(u => u.UserName == loginDto.UserName);

            if (Employee == null)
            {
                return NotFound(new ResponseDto
                {
                    IsSuccess = false,
                    Message = "User not found",
                    Result = null
                });
            }

            // Perform password validation (compare plain text password with stored hashed password)
            if (loginDto.Password != Employee.Password)
            {
                return Unauthorized(new ResponseDto
                {
                    IsSuccess = false,
                    Message = "Invalid credentials",
                    Result = null
                });
            }

            // TODO: Generate and return a JWT token for authentication

            return Ok(new ResponseDto
            {
                IsSuccess = true,
                Message = "Login successful",
                Result = Employee // You can include additional data here if needed
            });
        }*/

        
    }
}
