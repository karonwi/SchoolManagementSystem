using SchoolManagement.Core.DTOs;
using SchoolManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Services
{
    public class UserService : IUserService
    {
        public Task<EditUserResponseDTO> EditUserAsync(string userId, EditUserDTO editUser)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponseDTO> RegisterAsync(UserRegistrationRequestDTO registerationRequest)
        {
            throw new NotImplementedException();
        }
    }
}
