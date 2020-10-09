using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectRepository.Interface
{
    public interface IRepository<T>
    {
        Task<bool> AddAsync(T model);
        Task<IQueryable<T>> GetAllAsync();
        Task<bool> DeleteAsync(int? id);
        Task<bool> UpdateAsync(T model);
    }
}
