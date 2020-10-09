using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectBusiness.Interface
{
    public interface IUnitOfWorkBusiness
    {
        IAccountBusiness AccountBusiness { get; set; }
        IEncryptionBusiness EncryptionBusiness { get; set; }
        ILoginBusiness LoginBusiness { get; set; }
        IToken Token { get; set; }
        IRoleBusiness RoleBusiness { get; set; }
    }
}
