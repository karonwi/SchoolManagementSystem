﻿using SchoolManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interfaces
{
    public interface ITokenGenerator
    {
        public Task<string> GenerateTokenAsync(User user);
    }
}
