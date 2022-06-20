using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Interfaces
{
    public interface IUnitOfwork<out ApplicationDbContext> where ApplicationDbContext : DbContext, new()
    {
        public  Task BeginTransactio();
        public Task SaveChanges();
        public Task Commit();
        public Task RollBack();
    }
}
