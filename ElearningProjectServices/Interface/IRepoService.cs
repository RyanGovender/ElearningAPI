using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectServices.Interface
{
    public interface IRepoService<T>
    {
        Task<IQueryable<T>> GetAll();
        Task<Status> Inset(T data);
        Task<Status> Update(T data);
        //Task<bool> Delete(int? id);
    }
}
