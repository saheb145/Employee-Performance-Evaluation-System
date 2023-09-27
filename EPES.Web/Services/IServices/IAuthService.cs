using EPES.Web.Models;

namespace EPES.Web.Services.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegisterAsync(RegistrationRequestDto registrationRequestDto);
         Task<ResponseDto?> AssignRoleAsync(RegistrationRequestDto registrationRequestDto);
       
		
	}
}
