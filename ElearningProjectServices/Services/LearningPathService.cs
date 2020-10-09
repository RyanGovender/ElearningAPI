using ElearningProjectModels.Models;
using ElearningProjectRepository.Implementation;
using ElearningProjectServices.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace ElearningProjectServices.Services
{
    public class LearningPathService : ILearningPathService
    {
        private IUnitOfWork _iUnitOfWork;
        public LearningPathService(IUnitOfWork unitOfWork)
        {
            _iUnitOfWork = unitOfWork;
        }
        public async Task<bool> Delete(int? id)
        {
            return await _iUnitOfWork.LearningPathRepository.DeleteAsync(id);
        }

        public async Task<IQueryable<LearningPath>> GetAll()
        {
            return await _iUnitOfWork.LearningPathRepository.GetAllAsync();
        }

        public async Task<bool> Inset(LearningPath data)
        {
            return await _iUnitOfWork.LearningPathRepository.AddAsync(data);
        }

        public async Task<bool> Update(LearningPath data)
        {
            return await _iUnitOfWork.LearningPathRepository.UpdateAsync(data);
        }
    }
}
