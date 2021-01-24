using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Heikal.Lubricant.Core.Interfaces.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task SaveAsync();
        void Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(string include = null);
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> predicate, string include = null);
    }
}
