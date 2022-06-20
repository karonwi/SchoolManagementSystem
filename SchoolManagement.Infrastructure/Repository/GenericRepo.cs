using Microsoft.EntityFrameworkCore;
using SchoolManagement.Core.Interfaces;
using SchoolManagement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Core.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private ApplicationDbContext _dbContext { get; set; }
        private DbSet<T> _dbset;
        public GenericRepo(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbset = dbContext.Set<T>();
        }

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_dbset == null)
                    _dbset = _dbContext.Set<T>();
                return _dbset;
            }
        }
        public IQueryable<T> Table
        {
            get
            {
                return Entities;
            }
        }

        public IQueryable<T> TableNoTracking
        {
            get
            {
                return Entities.AsNoTracking();
            }
        }
        public virtual async Task<bool> CreateAsync(T item)
        {
            await _dbset.AddAsync(item);
            return await _dbContext.SaveChangesAsync() > 0;
            
        }

        public virtual async Task DeleteAsync(T item)
        {
             _dbset.Remove(item);
           await Save();
        }

        public virtual async Task DeleteByIdAsync(string id)
        {
            var entityToDelete =await  _dbset.FindAsync(id);
            if (entityToDelete != null)
            {
                await DeleteAsync(entityToDelete);
                return;
            }
            var typeName = typeof(T).Name;
            throw new ArgumentException($"The entity {typeName} with the id{id} does not exist");
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _dbset.FindAsync(id);
        }

        public async Task UpdateAsync(T item)
        {
            /*_dbset.Update(item);
            await _dbContext.SaveChangesAsync();*/

            _dbset.Attach(item);
          _dbContext.Entry(item).State = EntityState.Modified;
            await Save();

        }
        private async Task Save()
        {
             await _dbContext.SaveChangesAsync();
        }
    }
}
