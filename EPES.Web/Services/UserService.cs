using EPES.Web.Models;
using EPES.Web.Services.IServices;
using EPES.Web.Utility;

namespace EPES.Web.Services
{
    public class UserService : IUserService
    {
        private readonly IBaseService _baseService;
        public UserService(IBaseService baseService)
        {
			_baseService=baseService;

		}
        public async Task<ResponseDto?> GetAllUserAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = SD.ApiType.GET,
                Url = SD.UserAPIBase + "/api/user"
            });
        }
    }
}
