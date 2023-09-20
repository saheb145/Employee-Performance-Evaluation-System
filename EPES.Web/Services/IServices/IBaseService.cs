
using EPES.Web.Models;

namespace EPES.Web.Services.IServices
{
    public interface IBaseService
    {
        Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true);
        Task<ResponseDto?> SendAsync(EmployeeRequestDto employeeRequestDto, bool withBearer = true);

    }
}
