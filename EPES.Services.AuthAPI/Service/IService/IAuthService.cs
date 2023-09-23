using EPES.Services.AuthAPI.Models.Dto;

namespace EPES.Services.AuthAPI.Service.IService
{
    public interface IAuthService
    {
       Task<string> Register(RegistrationRequestDto registrationRequestDto);
        Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);
       Task<bool> AssignRole(string email, string roleName);
       // Task<bool> AssignRole(string userName, string roleName);

        
         
    }
}
