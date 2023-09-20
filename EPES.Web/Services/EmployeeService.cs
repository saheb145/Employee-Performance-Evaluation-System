using EPES.Web.Models;
using EPES.Web.Services.IServices;
using EPES.Web.Utility;

namespace EPES.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IBaseService _baseService;
        public EmployeeService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDto?> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = employeeDto,
                Url = SD.UserMangementAPIBase + "/api/employee"
            });
        }

        public async Task<ResponseDto?> DeleteEmployeeAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.DELETE,
                Url = SD.UserMangementAPIBase + "/api/employee/" + id
            });
        }

        public async  Task<ResponseDto?> GetAllEmployeesAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserMangementAPIBase + "/api/employee"
            });
        }

        public async Task<ResponseDto?> GetEmployeeByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserMangementAPIBase + "/api/employee/" + id
            });
        }

        public async Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.POST,
                Data = loginRequestDto,
                Url = SD.UserMangementAPIBase + "/api/employee/login"
            }, withBearer: false);
        }

        public  async Task<ResponseDto?> UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.PUT,
                Data = employeeDto,
                Url = SD.UserMangementAPIBase + "/api/employee"
			});
        }
    }
}
