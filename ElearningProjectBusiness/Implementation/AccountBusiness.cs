
using ElearningProjectBusiness.Interface;
using ElearningProjectRepository.Interface;
using System;
using System.Threading.Tasks;

namespace ElearningProjectBusiness.Implementation
{
    public class AccountBusiness : IAccountBusiness, ILoginBusiness
    {
        private IDapperBase _dapperBase;
        public AccountBusiness(IDapperBase dapperBase)
        {
            _dapperBase = dapperBase;
        }
        public string CreateGuid()
        {
           return Guid.NewGuid().ToString();
        }

        public async Task<int> Login(string email, string password)
        {
            var parameters = new { @Email = email, @PasswordHash = password };
            return await _dapperBase.Excute("sp_UserLogin",parameters);
        }
    }
}
