using ElearningProjectBusiness.Interface;
using ElearningProjectModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectBusiness.Implementation
{
    public class RoleBusiness : IRoleBusiness
    {
        private List<Claim> _userClaimsInformation = new List<Claim>();
        private static int _defaultPosition = 0;
        public List<Claim> CreateUserClaim(IQueryable<UserRoleViewModel> user)
        {
            if (user is null || !user.Any()) return null;
            GetUserClaimInformation(user.ElementAt(_defaultPosition));
            GetUserRoles(user);
            return _userClaimsInformation;
        }

        private void GetUserClaimInformation(UserRoleViewModel user)
        {
            _userClaimsInformation.Add(new Claim(ClaimTypes.Email, user.Email));
            _userClaimsInformation.Add(new Claim(ClaimTypes.Name, user.Name));
            _userClaimsInformation.Add(new Claim(ClaimTypes.Surname, user.Surname));
        }

        private void GetUserRoles(IQueryable<UserRoleViewModel> user)
        {
            user.ToList().ForEach(x => { _userClaimsInformation.Add(new Claim(ClaimTypes.Role,x.RoleName));});
        }
    }
}
