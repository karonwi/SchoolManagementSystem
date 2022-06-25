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
    public class StudentService : IStudentService
    {
        private readonly IGenericRepo<Student> _studentRepo;
        public StudentService(IGenericRepo<Student> studentRepo)
        {
            _studentRepo = studentRepo;
        }
        public Task<Response<string>> CreateStudentAsync(StudentRequestDTO staffRequestDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<GetStudentResponseDTO>>> GetAllStudentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Response<GetStudentResponseDTO>> GetStudentByIdAsync(string studentId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IEnumerable<PaymentSlipDTO>>> GetStudentSchoolFeesSlip(SearchRequest<string> searchRequest, string staffId)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateStudentAsync(StudentRequestDTO staffRequestDTO, string studentId)
        {
            throw new NotImplementedException();
        }
    }
}
