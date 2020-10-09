using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectServices.Interface
{
    public interface IAccountService
    {
        Task<LoginStatus> Login(string email, string Password);

    }
}
