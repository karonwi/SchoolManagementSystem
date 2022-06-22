using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Entities;
using SchoolManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Services
{
    public class FindAppUser : IFindAppUser
    {
        private readonly IGenericRepo<Staff> _staffRepo;
        private readonly IGenericRepo<Student> _studentRepo;
        private readonly IGenericRepo<AdminUser> _adminUserRepo;

        public FindAppUser(IGenericRepo<Staff> staffRepo, IGenericRepo<Student> studentRepo, IGenericRepo<AdminUser> adminUserRepo)
        {
            _staffRepo = staffRepo;
            _studentRepo = studentRepo;
            _adminUserRepo = adminUserRepo;
        }
    
        public async Task<AdminUser> GetAdminByUserIdAsync(string userId)
        {
            var admin = await _adminUserRepo.TableNoTracking.Where(x => x.UserId == userId).Include(x => x.User).FirstOrDefaultAsync();
            return admin;
        }

        public async Task<Staff> GetStaffByUserIdAsync(string userId)
        {
            var staff = await _staffRepo.TableNoTracking.Where(x => x.UserId == userId).Include(x => x.User).FirstOrDefaultAsync();
            return staff;
        }

        public async Task<Student> GetStudentByUserIdAsync(string userId)
        {
            var student = await _studentRepo.TableNoTracking.Where(x => x.UserId == userId).Include(x => x.User).FirstOrDefaultAsync();
            return student;
        }
    }
}
