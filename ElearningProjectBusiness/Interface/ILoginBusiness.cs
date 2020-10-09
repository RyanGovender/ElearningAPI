using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectBusiness.Interface
{
    public interface ILoginBusiness
    {
        Task<int> Login(string email,string password);
      //  Task<int> Logout();
    }
}
