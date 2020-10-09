using ElearningProjectModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectServices.Interface
{
    public interface IUserService :IRepositoryService<User>
    {
        Task<User> GetUserByUsername(string username);
    }
}
