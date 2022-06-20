using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;

namespace SchoolManagement.Infrastructure.Repository
{
    public class UnitOfWork<ApplicationDbContext> : IUnitOfwork<ApplicationDbContext>, IDisposable where ApplicationDbContext : DbContext, new()
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;
        private string _errorMessage = string.Empty;
        private DbContextTransaction _objTrans;
        private Dictionary<string, object> _repo;

        public UnitOfWork()
        {
            _context = new ApplicationDbContext();
        }

        public void BeginTransactio()
        {
            _objTrans = _context.Database.BeginTransaction();
        }

        public Task Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Task RollBack()
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
