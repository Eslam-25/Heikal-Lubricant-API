using Heikal.Lubricant.Core.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heikal.Lubricant.Core.Interfaces
{
    public interface IGenericService<T> where T : BaseDto
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
