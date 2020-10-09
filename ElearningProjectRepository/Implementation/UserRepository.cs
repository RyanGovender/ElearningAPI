using ElearningProjectModels.Models;
using ElearningProjectRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectRepository.Implementation
{
    public class UserRepository : IUsers
    {
        private IDapperBase _dapperBase;
        public UserRepository(IDapperBase dapperBase)
        {
            _dapperBase = dapperBase;
        }
        public async Task<bool> AddAsync(User model)
        {
            var parameters = new { 
                model.Id,
                model.Email,
                model.PasswordHash,
                model.AvatarUrl,
                model.CreatedDate,
                model.ModifiedDate,
                model.Name,
                model.Surname
            };

            var result = await _dapperBase.ExecuteQuery("sp_AddUsers", parameters);

            return result;
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            var parameters = new { @Id = id };

            var result = await _dapperBase.ExecuteQuery("sp_DeleteUser", parameters);
            return result;
        }

        public async Task<IQueryable<User>> GetAllAsync()
        {
            var result = await _dapperBase.Query<User>("sp_GetAllUsers",null);
            return result;
        }

        public async Task<User> GetUserByUsername(string email)
        {
            var parameters = new { @Email = email };
            var result = await _dapperBase.Query<User>("sp_GetUserByUsername",parameters);
            return result?.FirstOrDefault();
        }

        public async Task<bool> UpdateAsync(User model)
        {
            var parameters = new
            {
                model.Id,
                model.Email,
                model.PasswordHash,
                model.AvatarUrl,
                model.ModifiedDate,
                model.Name,
                model.Surname
            };

            var result = await _dapperBase.ExecuteQuery("sp_UpadteUsers", parameters);

            return result;
        }
        
    }
}
