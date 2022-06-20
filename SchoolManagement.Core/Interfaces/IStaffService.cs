using SchoolManagement.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interfaces
{
    public interface IStaffService
    {
        public Task<Response<string>> CreateStaffAsync(StaffRequestDTO staffRequestDTO);
        public Task<Response<bool>> UpdateAsync(StaffRequestDTO staffRequestDTO,string staffId);
        public Task<Response<List<GetStaffResponseDTO>>> GetAllStaffsAsync();
        public Task<Response<GetStaffResponseDTO>> GetStaffByIdAsync(string staffId);
        public Task<Response<IEnumerable<PaymentSlipDTO>>> GetStaffSalarySlip(SearchRequest<string> searchRequest, string staffId);
    }
}
