using EPES.Web.Models;

namespace EPES.Web.Services.IServices
{
    public interface IProfileService
    {
        Task<ResponseDto?> GetProfileByEmail();
    }
}
