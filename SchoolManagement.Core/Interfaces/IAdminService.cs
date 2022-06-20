using SchoolManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interfaces
{
    public interface IAdminService
    {
        public Task<Response<string>> DeleteStaffAsync(string staffId);
        public Task<Response<string>> DeleteStudentAsync(string studentId);
    }
}
