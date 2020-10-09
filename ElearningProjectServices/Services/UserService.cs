using ElearningProjectBusiness.Interface;
using ElearningProjectModels.Models;
using ElearningProjectRepository.Implementation;
using ElearningProjectServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectServices.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IUnitOfWorkBusiness _unitOfWorkBusiness;
        public UserService(IUnitOfWork unitOfWork, IUnitOfWorkBusiness unitOfWorkBusiness)
        {
            _unitOfWork = unitOfWork;
            _unitOfWorkBusiness = unitOfWorkBusiness;
        }
        public async Task<bool> Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<IQueryable<User>> GetAll()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User> GetUserByUsername(string username)
        {
            return await _unitOfWork.UserRepository.GetUserByUsername(username);
        }

        public async Task<bool> Inset(User data)
        {
            data.Id = _unitOfWorkBusiness.AccountBusiness.CreateGuid();
            data.PasswordHash = _unitOfWorkBusiness.EncryptionBusiness.PlainTextEncryption(data.PasswordHash,data.Id);
            return await _unitOfWork.UserRepository.AddAsync(data);
        }

        public async Task<bool> Update(User data)
        {
            return await _unitOfWork.UserRepository.UpdateAsync(data);
        }

    }
}
