using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Core.DTOs
{
    public class StaffRequestDTO
    {
        [Required]
        public Guid StaffId { get; set; }

        [Required]
        public UserRegistrationRequestDTO user { get; set; }
    }
}
