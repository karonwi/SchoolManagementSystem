using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.DTOs
{
    public class EditUserDTO
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        public AddressRequestDTO Address { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
