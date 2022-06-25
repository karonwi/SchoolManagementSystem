using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Utilities
{
    public static class Helpers
    {
        public static string GetIdentityErrors(this IdentityResult result)
        {
            return result.Errors.Aggregate(string.Empty, (current, error) => current + (error.Description + Environment.NewLine));
        }
        public static int GenerateOrderToken()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            int random = rand.Next(101256811,999999999);
            return random;
        }
    }
}
