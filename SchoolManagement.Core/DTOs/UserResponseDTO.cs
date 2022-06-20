﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.DTOs
{
    public class UserResponseDTO
    {
        public string Id { get; set; }
        public string Token { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}