using EPES.Services.AuthAPI.Models.Dto;

namespace EPES.Services.AuthAPI.Service.IService
{
    public interface IUserService
    {
        Task<IEnumerable<EmployeeDto>> GetAllUsers();
    }
}
