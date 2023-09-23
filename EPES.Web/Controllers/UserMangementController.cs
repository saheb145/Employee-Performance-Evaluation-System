using EPES.Web.Models;
using EPES.Web.Services.IServices;
using EPES.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace EPES.Web.Controllers
{
    public class UserMangementController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public UserMangementController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
		public string GenerateUniqueEmployeeId()
		{
			// Generate a new unique GUID
			Guid uniqueGuid = Guid.NewGuid();

			// Convert the GUID to a string representation
			string uniqueEmployeeId = uniqueGuid.ToString();

			// You may want to remove hyphens or other characters from the generated ID
			uniqueEmployeeId = uniqueEmployeeId.Replace("-", "");

			// Ensure the ID is of a specific length or format, if needed
			// For example, you can pad it to a certain length
			uniqueEmployeeId = uniqueEmployeeId.Substring(0, 10).PadLeft(10, '0'); // Adjust the length as needed

			return uniqueEmployeeId;
		}

		public async Task<IActionResult> EmployeeIndex()
        {
            List<EmployeeDto>? list = new();

            ResponseDto? response = await _employeeService.GetAllEmployeesAsync();

            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<EmployeeDto>>(Convert.ToString(response.Result));
            }
            else
            {
                TempData["error"] = response?.Message;
            }

            return View(list);
        }

        public async Task<IActionResult> CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDto model)
        {
			string uniqueEmployeeId = GenerateUniqueEmployeeId();

			// Populate the EmployeeId property with the generated ID
			model.UniqueEID = uniqueEmployeeId;
			if (ModelState.IsValid)
            {
				ResponseDto? response = await _employeeService.CreateEmployeeAsync(model);

                if (response != null && response.IsSuccess)
                {
                    TempData["success"] = "Employee created successfully";
                    return RedirectToAction(nameof(EmployeeIndex));
                }
                else
                {
                    TempData["error"] = response?.Message;
                }
				
			}
            return View(model);
        }

        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            ResponseDto? response = await _employeeService.GetEmployeeByIdAsync(Id);

            if (response != null && response.IsSuccess)
            {
                EmployeeDto? model = JsonConvert.DeserializeObject<EmployeeDto>(Convert.ToString(response.Result));
                return View(model);
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(EmployeeDto employeeDto)
        {
            ResponseDto? response = await _employeeService.DeleteEmployeeAsync(employeeDto.Id);

            if (response != null && response.IsSuccess)
            {
                TempData["success"] = "Employee deleted successfully";
                return RedirectToAction(nameof(EmployeeIndex));
            }
            else
            {
                TempData["error"] = response?.Message;
            }
            return View(employeeDto);
        }

    }
}

