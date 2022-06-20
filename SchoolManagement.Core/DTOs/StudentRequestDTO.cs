using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.DTOs
{
    public class StudentRequestDTO
    {
        [Required]
        public Guid StudentId { get; set; }

        [Required]
        public UserRegistrationRequestDTO user { get; set; }
    }
}
