using EPES.Web.Models;

namespace EPES.Web.Services.IServices
{
    public interface IUserService
    {
        Task<ResponseDto?> GetAllUserAsync();
    }
}
