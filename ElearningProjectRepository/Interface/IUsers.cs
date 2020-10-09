using ElearningProjectModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectRepository.Interface
{
   public interface IUsers : IRepository<User>
    {
        Task<User>GetUserByUsername(string email);
    }
}
