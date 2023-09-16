
using EPES.Web.Models;

namespace EPES.Web.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto);
      /*  Task<ResponseDto?> SendAsync(EmployeeDto employeeDto);*/
    }
}
