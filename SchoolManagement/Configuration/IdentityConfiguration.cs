using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Core.Entities;
using SchoolManagement.Infrastructure;

namespace SchoolManagement.Configuration
{
    public static class IdentityConfiguration
    {
        public static void ConfigureIdentity(this IServiceCollection service)
        {
            service.AddIdentity<User, IdentityRole>(x =>
            {
                x.Password.RequireUppercase = true;
                x.Password.RequiredLength = 7;
                x.Password.RequireDigit = false;
                x.SignIn.RequireConfirmedEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }
    }
}
