using SchoolManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interfaces
{
    public interface IAuthenticationService
    {
        
        public Task<Response<string>> EmailConfirmationAsync(ConfirmEmailRequestDTO emailRequestDTO);
        public Task<Response<UserResponseDTO>> LoginAsync(UserRequestDTO userRequest);
        public Task<Response<string>> UpdatePasswordAsync(UpdatePasswordDTO updatePassword);
        public Task<Response<string>> ForgotPasswordAsync(string email);
        public Task<Response<string>> ResetPasswordAsync(ResetPasswordDTO resetPassword);
    }
}
