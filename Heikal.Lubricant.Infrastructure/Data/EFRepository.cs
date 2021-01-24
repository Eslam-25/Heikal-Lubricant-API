
using Heikal.Lubricant.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Heikal.Lubricant.Infrastructure.Data
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private readonly LubricantContext _context;
        public EFRepository(LubricantContext context)
        {
            _context = context;
        }

        public void Add(T entity)
            => _context.Entry(entity).State = EntityState.Added;

        public async Task<IEnumerable<T>> GetAllAsync(string include = null)
        {
            if (include != null)
                return await _context.Set<T>().Include(include).ToListAsync();
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
            => await _context.Set<T>().FindAsync(id);

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> predicate, string include = null)
        {
            DbSet<T> entity = _context.Set<T>();
            if(include != null)
                return await entity.Include(include).Where(predicate).ToListAsync(); 

            return await entity.Where(predicate).ToListAsync();
        }

        public void Remove(T entity)
            => _context.Set<T>().Remove(entity);

        public Task SaveAsync()
            => _context.SaveChangesAsync();

        public void Update(T entity)
            => _context.Entry(entity).State = EntityState.Modified;
    }
}
