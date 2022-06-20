using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.DTOs
{
    public class ResetPasswordDTO
    {
        [Required]
        public string Token { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(20,MinimumLength =5)]
        [DataType(DataType.Password)]
        public string NewPassword {get;set;}
        [Required]
        [StringLength(20, MinimumLength = 5)]
        [Compare("NewPassword",ErrorMessage ="The password must be the same with the new password")]
        public string ConfirmPassword {get;set;}
    }
}
