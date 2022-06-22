using SchoolManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interfaces
{
    public interface IConfirmationMailService
    {
        public Task SendConfirmationEmail(UserResponseDTO userResponse);
        public Task SendConfirmationEmailForResetPassword(UserResponseDTO userResponse);
        public Task SendComfirmEmailToken(string userId);
        public Task<Response<string>> SendRemainderEmail(string userId);
    }
}
