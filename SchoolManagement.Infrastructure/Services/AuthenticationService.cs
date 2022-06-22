using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SchoolManagement.Core.DTOs;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Interfaces;
using SchoolManagement.Core.Utilities;
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
        private readonly ITokenGenerator _tokenGen;
        private IMapper _mapper;
        public AuthenticationService(UserManager<User> userManager, ITokenGenerator tokenGen, IMapper map)
        {
            _userManager = userManager;
            _tokenGen = tokenGen;
            _mapper = map;
        }
    
        public async Task<Response<string>> EmailConfirmationAsync(ConfirmEmailRequestDTO emailRequestDTO)
        {
            var findUser = await _userManager.FindByEmailAsync(emailRequestDTO.EmailAddress);
            if (findUser != null)
            {
                var decodedToken =TokenConverter.DecodeToken(emailRequestDTO.Token);
                var result =await _userManager.ConfirmEmailAsync(findUser, decodedToken);
                if (await _userManager.IsEmailConfirmedAsync(findUser) || result.Succeeded)
                {
                    return new Response<string>()
                    {
                        Success = true,
                        Message = "Email confirmation was successful"
                    };
                    
                }
                throw new ArgumentException("Your email could not be confirmed");
            }
            throw new ArgumentException($"User with the email {emailRequestDTO.EmailAddress} could not be found");
        }

        public async Task<Response<string>> ForgotPasswordAsync(string email)
        {
            var findUser = await _userManager.FindByEmailAsync(email);
            var userResponse = _mapper.Map<UserResponseDTO>(findUser);
            var response = new Response<string>
            {
                Success = false,
                Message = "A link has been sent to the specified email address"
            };
            if (findUser == null)
            {
                response.Success = false;
                return response;
            }
            userResponse.FullName = $"{findUser.FirstName + " " + findUser.LastName}";
            userResponse.Token = await _userManager.GeneratePasswordResetTokenAsync(findUser);
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
                                Token = await _tokenGen.GenerateTokenAsync(findUser)
                            },
                            Message = "Login successful",
                            Success = true
                        };
                    }
                    throw new AccessViolationException("Kindly verify your email address to login");
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
