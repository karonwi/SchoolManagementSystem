using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using SchoolManagement.Core.Utilities;
using System;
using System.Text;

namespace SchoolManagement.Configuration
{
    public static class AuthenticationAndAuthorizeConfiguration
    {
        public static void ConfigureAuthentication(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidAudience = configuration["JWTSettings:Audience"],
                    ValidIssuer = configuration["JWTSettings:Issuer"],
                    IssuerSigningKey =
                        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTSettings:SecretKey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            service.AddAuthorization(options => options.AddPolicy("RequireAdminOnly", policy => policy.RequireRole(Constants.Role.Admin)))
                .AddAuthorization(options => options.AddPolicy("RequireStaffOnly", policy => policy.RequireRole(Constants.Role.Staff)))
                .AddAuthorization(options => options.AddPolicy("RequireStudentsOnly", policy => policy.RequireRole(Constants.Role.Student)))
                .AddAuthorization(options => options.AddPolicy("RequireStaffAndStudent", policy => policy.RequireRole(Constants.Role.Staff, Constants.Role.Student)));
            
        }
    }
}
