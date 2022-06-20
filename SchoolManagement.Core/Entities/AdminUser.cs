﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Entities
{
    public class AdminUser
    {
       [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public Guid Id { get; set; }
       public string UserId { get; set; }
       public virtual User User { get; set; }
       public string SchoolEmail { get; set; }
       public string SchoolPhoneNumber { get; set; }
       public Address Address { get; set; }
    }
}
