using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectServices.Interface
{
    public interface IRepositoryService <T>
    {
        Task<IQueryable<T>> GetAll();
        Task<bool> Inset(T data);
        Task<bool> Update(T data);
        Task<bool> Delete(int?id);

    }
}
