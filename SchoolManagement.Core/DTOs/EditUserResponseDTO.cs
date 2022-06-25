using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.DTOs
{
    public class EditUserResponseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }
        public AddressRequestDTO Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
