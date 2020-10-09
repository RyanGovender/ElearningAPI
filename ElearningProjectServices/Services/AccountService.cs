using ElearningProjectBusiness.Interface;
using ElearningProjectServices.Interface;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectServices.Services
{
    public class AccountService : IAccountService
    {
        private IUnitOfWorkBusiness _unitOfWorkBusiness;
        public AccountService(IUnitOfWorkBusiness unitOfWorkBusiness)
        {
            _unitOfWorkBusiness = unitOfWorkBusiness;
        }

        public async Task<LoginStatus> Login(string email, string password)
        {
            var status = await _unitOfWorkBusiness.LoginBusiness.Login(email,password);
            return (LoginStatus)status;
        }
    }
}
