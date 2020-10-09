using ElearningProjectModels.Models;
using ElearningProjectModels.ViewModels;
using ElearningProjectRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectRepository.Implementation
{
    public class RoleRepository : IRole
    {
        private IDapperBase _dapperBase;
        public RoleRepository(IDapperBase dapperBase)
        {
            _dapperBase = dapperBase;
        }
        public async Task<int> AddAsync(Role model)
        {
            var parameters = new { model.RoleId,model.RoleName,model.CreatedDate };
            return await _dapperBase.Excute("sp_AddUserRole", parameters);
        }
     
        public Task<bool> DeleteAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<Role>> GetAllAsync()
        {
            var result = await _dapperBase.Query<Role>("sp_GetAllRoles", null);
            return result.AsQueryable();
        }

        public async Task<int> UpdateAsync(Role model)
        {
            var parameters = new { model.RoleId, model.RoleName, model.ModifiedDate };
            return await _dapperBase.Excute("sp_UpdateUserRole", parameters);
        }


        public async Task<int> AssignUserRole(UserRole userRole)
        {
            var parameters = new { userRole.RoleId,@Id= userRole.UserId, userRole.CreatedDate };
            return await _dapperBase.Excute("sp_AssignRoleToUser", parameters);
        }

        public async Task<int> UpdateUserRole(UserRole userRole)
        {
            var parameters = new { userRole.UserRoleId,userRole.RoleId,userRole.UserId,userRole.ModifiedDate };
            return await _dapperBase.Excute("sp_UpdateUserRoles", parameters);
        }

        public async Task<IQueryable<UserRoleViewModel>> GetUserRoles(string email)
        {
            var parameters = new { @Email = email };
            return await _dapperBase.Query<UserRoleViewModel>("sp_GetAUsersRoles", parameters);
        }
    }
}
