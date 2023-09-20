/*using EPES.Services.UserMangement.Data;
using EPES.Services.UserMangement.Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
*/
/*namespace EPES.Services.UserMangement.Controllers
{
	*//*[Route("api/employeelogin")]
	[ApiController]
	public class EmployeeLogInController : ControllerBase
	{

		private readonly AppDbContext _context;
        public EmployeeLogInController(AppDbContext context)
        {
			_context=context;

		}
		[HttpPost("login")]
		public async Task<IActionResult> Login(LoginRequestDto loginDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			// Find the user by email
			var Employee = await _context.Employees.SingleOrDefaultAsync(u => u.UserName == loginDto.UserName);

			if (Employee == null)
			{
				return NotFound("User not found.");
			}

			// Perform password validation (compare plain text password with stored hashed password)
			if (loginDto.Password != Employee.Password)
			{
				return Unauthorized("Invalid credentials.");
			}

			// TODO: Generate and return a JWT token for authentication

			return Ok("Login successful");
		}
		*//*public IActionResult Index()
		{
			return View();
		}*//*
	}*//*
}
*/