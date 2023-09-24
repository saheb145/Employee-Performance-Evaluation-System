using EPES.Web.Models;
using EPES.Web.Services.IServices;
using EPES.Web.Utility;

namespace EPES.Web.Services
{
    public class ProfileService:IProfileService
    {
        private readonly IBaseService _baseService;
        public ProfileService(IBaseService baseService)
        {
            _baseService = baseService;

        }

        public async Task<ResponseDto?> GetProfileByEmail()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.ProfileAPIBase + "/api/user"
            });
        }

       
    }
}
