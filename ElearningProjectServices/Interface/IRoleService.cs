using ElearningProjectModels.Models;
using ElearningProjectModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectServices.Interface
{
   public interface IRoleService
    {
        Task<Status> Add(Role model);
        Task<Status> Update(Role model);
        Task<IQueryable<Role>> GetAll();
        Task<Status> AssignUserRole(UserRole userRole);
        Task<Status> UpdateUserRole(UserRole userRole);
       // Task<IQueryable<UserRoleViewModel>> GetUserRoles(string email);//CAN BE REMOVED
       // List<Claim> GetUserClaimsInfomation(IQueryable<UserRoleViewModel> user); // CAN BE REMOVED
        List<Claim> GetClaimsForJWT(string email);
    }
}
