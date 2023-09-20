using EPES.Web.Models;

namespace EPES.Web.Services.IServices
{
    public interface IEmployeeService
    {
        
        Task<ResponseDto?> GetAllEmployeesAsync();
        Task<ResponseDto?> GetEmployeeByIdAsync(int id);
        Task<ResponseDto?> CreateEmployeeAsync(EmployeeDto employeeDto);
        Task<ResponseDto?> UpdateEmployeeAsync(EmployeeDto employeeDto);
        Task<ResponseDto?> DeleteEmployeeAsync(int id);
		Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
    

    }
}
