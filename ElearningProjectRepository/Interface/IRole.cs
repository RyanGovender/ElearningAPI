using ElearningProjectModels.Models;
using ElearningProjectModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectRepository.Interface
{
    public interface IRole 
    {
        Task<int> AddAsync(Role model); // soon to convert irepository to Task<int>
        Task<int> UpdateAsync(Role model);
        Task<IQueryable<Role>> GetAllAsync();
        Task<int> AssignUserRole(UserRole userRole);
        Task<int> UpdateUserRole(UserRole userRole);
        Task<IQueryable<UserRoleViewModel>> GetUserRoles(string email);
    }
}
