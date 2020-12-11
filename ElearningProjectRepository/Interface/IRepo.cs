using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectRepository.Interface
{
    public interface IRepo<T>
    {
        Task<int> Insert(T model);
        Task<int> Update(T model);
        Task<IQueryable<T>> GetAll();
        Task<T> Find(int?id);
    }
}
