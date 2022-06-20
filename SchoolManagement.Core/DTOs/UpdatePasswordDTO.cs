using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.DTOs
{
    public class UpdatePasswordDTO
    {
        [Required]
        [Compare("ConfirmNewPassword")]
        public string NewPassword { get; set; }
        [Required]
        public string ConfirmNewPassword { get; set; }
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string EmailAddress { get; set; }
    }
}
