using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectRepository.Interface
{
   public interface IDapperBase
    {
        Task<int> Excute(string storedProcName,object parameters);
        Task<bool> ExecuteQuery(string storeProcName,object parameters);
        Task<IQueryable<T>> Query<T>(string storeProcName, object parameters = null);
    }
}
