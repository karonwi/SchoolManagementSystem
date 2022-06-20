using SchoolManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interfaces
{
    public interface IStudentService
    {
        public Task<Response<string>> CreateStudentAsync(StudentRequestDTO staffRequestDTO);
        public Task<Response<bool>> UpdateStudentAsync(StudentRequestDTO staffRequestDTO, string studentId);
        public Task<Response<List<GetStudentResponseDTO>>> GetAllStudentsAsync();
        public Task<Response<GetStudentResponseDTO>> GetStudentByIdAsync(string studentId);
        public Task<Response<IEnumerable<PaymentSlipDTO>>> GetStudentSchoolFeesSlip(SearchRequest<string> searchRequest, string staffId);
    }
}
