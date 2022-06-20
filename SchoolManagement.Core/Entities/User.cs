using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Entities
{
    public class User :IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid RefreshToken { get; set; }
        public DateTime RefreshTokenCreatedAt { get; set; }
        public DateTime RefreshTokenExpiredAt { get; set; }
        public string DisplayPicture { get; set; }
        public virtual Address Address { get; set; }
    }
}
