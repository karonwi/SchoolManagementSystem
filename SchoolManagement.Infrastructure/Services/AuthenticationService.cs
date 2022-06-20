using Microsoft.AspNetCore.Identity;
using SchoolManagement.Core.DTOs;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        public AuthenticationService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
    
        public Task<Response<string>> EmailConfirmationAsync(ConfirmEmailRequestDTO emailRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> ForgotPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<UserResponseDTO>> LoginAsync(UserRequestDTO userRequest)
        {
            var findUser = await _userManager.FindByEmailAsync(userRequest.Email);
            if (findUser != null)
            {
                if (await _userManager.CheckPasswordAsync(findUser,userRequest.Password))
                {
                    if (findUser.EmailConfirmed)
                    {
                        return new Response<UserResponseDTO>
                        {
                            Data = new UserResponseDTO
                            {
                                Email = $"The email {userRequest.Email} has been confirmed",
                                FullName = findUser.FirstName + " " + findUser.LastName,
                                Id = findUser.Id,
                                Token = 
                            }
                        }
                    }
                }
                throw new AccessViolationException("Invalid Password");
                
            }
            throw new AccessViolationException("Invalid Credentials");
        }

        public Task<Response<string>> ResetPasswordAsync(ResetPasswordDTO resetPassword)
        {
            throw new NotImplementedException();
        }

        public Task<Response<string>> UpdatePasswordAsync(UpdatePasswordDTO updatePassword)
        {
            throw new NotImplementedException();
        }
    }
}
