using ElearningProjectModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectBusiness.Interface
{
    public interface IRoleBusiness
    {
        List<Claim> CreateUserClaim(IQueryable<UserRoleViewModel> user);
    }
}
