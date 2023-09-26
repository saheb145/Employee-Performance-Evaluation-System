﻿using EPES.Services.AuthAPI.Data;
using EPES.Services.AuthAPI.Models.Dto;
using EPES.Services.AuthAPI.Models;
using EPES.Services.AuthAPI.Service.IService;
using Microsoft.AspNetCore.Identity;

namespace EPES.Services.AuthAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthService(AppDbContext db,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IJwtTokenGenerator jwtTokenGenerator)
        {
            _db = db;
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
            _roleManager = roleManager;
        }
      
        public async Task<bool> AssignRole(string email, string roleName)
        {
           
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                   
                    _roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await _userManager.AddToRoleAsync(user, roleName);
                return true;
            }
            return false;

        }
        public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
        {
            var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (user == null || isValid == false)
            {
                return new LoginResponseDto() { User = null, Token = "" };
            }

            //if user was found , Generate JWT Token
            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtTokenGenerator.GenerateToken(user, roles);

            UserDto userDTO = new()
            {
                Email = user.Email,
                ID = user.Id,
                Name = user.Name,
                PhoneNumber = user.PhoneNumber
            };

            LoginResponseDto loginResponseDto = new LoginResponseDto()
            {
                User = userDTO,
                Token = token
                
            };

            return loginResponseDto;
        }
        /* public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
         {
             var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

             bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

             if (user == null || isValid == false)
             {
                 return new LoginResponseDto() { User = null, Token = "" };
             }

             bool isManager = await _userManager.IsInRoleAsync(user, "MANAGER");

             if (!isManager)
             {
                 return new LoginResponseDto() { User = null, Token = "" };
             }
             //if user was found , Generate JWT Token
             var roles = await _userManager.GetRolesAsync(user);
             var token = _jwtTokenGenerator.GenerateToken(user, roles);

             UserDto userDTO = new()
             {
                 Email = user.Email,
                 ID = user.Id,
                 Name = user.Name,
                 PhoneNumber = user.PhoneNumber
             };

             LoginResponseDto loginResponseDto = new LoginResponseDto()
             {
                 User = userDTO,
                 Token = token
                 // Token=""
             };

             return loginResponseDto;
         }*/
        /* public async Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto)
         {
             var user = _db.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDto.UserName.ToLower());

             if (user == null)
             {
                 return new LoginResponseDto() { User = null, Token = "" };
             }

             bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDto.Password);

             if (isValid)
             {
                 // Check if the user has the "Manager" role
                 bool isManager = await _userManager.IsInRoleAsync(user, "MANAGER");

                 if (isManager)
                 {
                     // Generate JWT Token
                     var roles = await _userManager.GetRolesAsync(user);
                     var token = _jwtTokenGenerator.GenerateToken(user, roles);

                     UserDto userDTO = new()
                     {
                         Email = user.Email,
                         ID = user.Id,
                         Name = user.Name,
                         PhoneNumber = user.PhoneNumber
                     };

                     LoginResponseDto loginResponseDto = new LoginResponseDto()
                     {
                         User = userDTO,
                         Token = token
                     };

                     return loginResponseDto;
                 }
             }

             // If user was not found, password is invalid, or the user is not a Manager, return an appropriate response.
             return new LoginResponseDto() { User = null, Token = "" };
         }
        */


        public async Task<string> Register(RegistrationRequestDto registrationRequestDto)
        {

            ApplicationUser user = new()
            {
                UserName = registrationRequestDto.Email,
                Email = registrationRequestDto.Email,
                NormalizedEmail = registrationRequestDto.Email.ToUpper(),
                Name = registrationRequestDto.Name,
                PhoneNumber = registrationRequestDto.PhoneNumber
            };
            try
            {
                var result = await _userManager.CreateAsync(user, registrationRequestDto.Password);
                if (result.Succeeded)
                {
                    var userToReturn = _db.ApplicationUsers.First(u => u.UserName == registrationRequestDto.Email);

                    UserDto userDto = new()
                    {
                        Email = userToReturn.Email,
                        ID = userToReturn.Id,
                        Name = userToReturn.Name,
                        PhoneNumber = userToReturn.PhoneNumber
                    };

                    return "";
                }

                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }

            }
            catch (Exception ex)
            {

            }
            return "Error Encountered";
        }


    }
}
