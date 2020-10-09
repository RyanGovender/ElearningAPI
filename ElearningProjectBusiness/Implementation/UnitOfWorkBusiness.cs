using ElearningProjectBusiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectBusiness.Implementation
{
   public class UnitOfWorkBusiness : IUnitOfWorkBusiness
    {
        public IAccountBusiness AccountBusiness { get; set; }
        public IEncryptionBusiness EncryptionBusiness { get; set; }
        public ILoginBusiness LoginBusiness { get; set; }
        public IToken Token { get; set; }
        public IRoleBusiness RoleBusiness { get; set; }
        public UnitOfWorkBusiness(IAccountBusiness accountBusiness
                                  ,IEncryptionBusiness encryptionBusiness,
                                    ILoginBusiness login,
                                    IToken token,
                                    IRoleBusiness roleBusiness
            )
        {
            AccountBusiness = accountBusiness;
            EncryptionBusiness = encryptionBusiness;
            LoginBusiness = login;
            Token = token;
            RoleBusiness = roleBusiness;
        }
    }
}
