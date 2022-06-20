using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.DTOs
{
    public class GetStudentResponseDTO
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentsPhoneNumber { get; set; }
        public string ParentName { get; set; }
        public AddressRequestDTO Address { get; set; }
    }
}
