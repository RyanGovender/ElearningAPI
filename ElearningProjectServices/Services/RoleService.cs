using ElearningProjectBusiness.Interface;
using ElearningProjectModels.Models;
using ElearningProjectModels.ViewModels;
using ElearningProjectRepository.Implementation;
using ElearningProjectServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectServices.Services
{
    public class RoleService : IRoleService
    {
        private IUnitOfWork _unitOfWork;
        private IUnitOfWorkBusiness _unitOfWorkBusiness;
        public RoleService(IUnitOfWork unitOfWork, IUnitOfWorkBusiness unitOfWorkBusiness)
        {
            _unitOfWork = unitOfWork;
            _unitOfWorkBusiness = unitOfWorkBusiness;
        }
        public async Task<Status> Add(Role model)
        {
            model.RoleId = _unitOfWorkBusiness.AccountBusiness.CreateGuid();
            model.CreatedDate = DateTime.Now;
            var result = await _unitOfWork.RoleRepositroy.AddAsync(model);
            return (Status)result;
        }
       
        public async Task<IQueryable<Role>> GetAll()
        {
            return await _unitOfWork.RoleRepositroy.GetAllAsync();
        }

        public async Task<Status> Update(Role model)
        {
            model.ModifiedDate = DateTime.Now;
            var result = await _unitOfWork.RoleRepositroy.UpdateAsync(model);
            return (Status)result;
        }

        public async Task<Status> AssignUserRole(UserRole userRole)
        {
            userRole.CreatedDate = DateTime.Now;
            var result = await _unitOfWork.RoleRepositroy.AssignUserRole(userRole);
            return (Status)result;
        }

        public async Task<Status> UpdateUserRole(UserRole userRole)
        {
            userRole.ModifiedDate = DateTime.Now;
            var result = await _unitOfWork.RoleRepositroy.UpdateUserRole(userRole);
            return (Status)result;
        }

        public List<Claim> GetUserClaimsInfomation(IQueryable<UserRoleViewModel> user)
        {
            return _unitOfWorkBusiness.RoleBusiness.CreateUserClaim(user);
        }

        public async Task<IQueryable<UserRoleViewModel>> GetUserRoles(string email)
        {
            return await _unitOfWork.RoleRepositroy.GetUserRoles(email);
        }

        public List<Claim> GetClaimsForJWT(string email)
        {
            var _userClaimsData =  GetUserRoles(email).Result;
            return GetUserClaimsInfomation(_userClaimsData);

        }
    }
}
