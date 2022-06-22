using SchoolManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interfaces
{
    public interface IFindAppUser
    {
        public Task<Staff> GetStaffByUserIdAsync(string userId);
        public Task<AdminUser> GetAdminByUserIdAsync(string userId);
        public Task<Student> GetStudentByUserIdAsync(string userId);
    }
}
