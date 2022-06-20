using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.DTOs
{
    public class ConfirmEmailRequestDTO
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Token { get; set; }
    }
}
