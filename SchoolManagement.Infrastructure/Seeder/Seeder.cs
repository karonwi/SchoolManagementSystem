using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using SchoolManagement.Core.Entities;

namespace SchoolManagement.Infrastructure.Seeder
{
    public class Seeder
    {
       public async static Task Seed(RoleManager<IdentityRole> roleManager , UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            await dbContext.Database.EnsureCreatedAsync();
            await SeedRoles(roleManager, dbContext);
            await SeedUser(userManager, dbContext);
            await SeedAdminUser(userManager, dbContext);
            await SeedStaff(userManager, dbContext);
            await SeedStudent(userManager, dbContext);
        }

        private static async Task SeedStudent(UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            if (!dbContext.Students.Any())
            {
                var students = SeederHelper<Student>.GetData("Student.json");
                await dbContext.Students.AddRangeAsync(students);
                await dbContext.SaveChangesAsync();
                foreach (var student in students)
                {
                    var studentUser = await userManager.FindByIdAsync(student.Id.ToString());
                    await userManager.AddToRoleAsync(studentUser, "Student");
                }
            }
        }

        private static async Task SeedStaff(UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            if (!dbContext.Staffs.Any())
            {
                var staffs = SeederHelper<Staff>.GetData("Staff.json");
                await dbContext.Staffs.AddRangeAsync(staffs);
                await dbContext.SaveChangesAsync();
                foreach (var staff in staffs)
                {
                    var staffUser = await userManager.FindByIdAsync(staff.Id.ToString());
                    await userManager.AddToRoleAsync(staffUser, "Staff");
                }
            }
        }

        private static async Task SeedAdminUser(UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            if (!dbContext.AdminUsers.Any())
            {
                var adminUsers = SeederHelper<AdminUser>.GetData("AdminUser.json");
                await dbContext.AdminUsers.AddRangeAsync(adminUsers);
                await dbContext.SaveChangesAsync();

                foreach (var adminUser in adminUsers)
                {
                    var user = await userManager.FindByIdAsync(adminUser.Id.ToString());
                    await userManager.AddToRoleAsync(user, "AdminUser");
                }
            }
        }

        private static async Task SeedUser(UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var users = SeederHelper<User>.GetData("User.json");
                foreach (var user in users)
                {
                    user.EmailConfirmed = true;
                    await userManager.CreateAsync(user,"S@muel7413");
                }
            }
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager, ApplicationDbContext dbContext)
        {
            if (!dbContext.Roles.Any())
            {
                var roles = SeederHelper<string>.GetData("Roles.json");
                foreach (var role in roles)
                {
                   await roleManager.CreateAsync( new IdentityRole { Name = role});
                }
            }
        }
    }
}
