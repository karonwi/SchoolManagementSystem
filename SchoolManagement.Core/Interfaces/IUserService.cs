using SchoolManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interfaces
{
    public interface IUserService
    {
        Task<UserResponseDTO> RegisterAsync(UserRegistrationRequestDTO registerationRequest);
        Task<EditUserResponseDTO> EditUserAsync(string userId, EditUserDTO editUser);
    }
}
