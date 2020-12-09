using ElasticSearch_Libary.Interface;
using ElasticSearch_Libary.Logic;
using ElearningProjectBusiness.Implementation.Global;
using ElearningProjectModels.Logging;
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
            var result = await _iUnitOfWork.LearningPathRepository.GetAllAsync();
            //ElasticLogic<LearningPath>.AddToIndex(result.Last(), "learningpath");
            //ElasticLogic<ObjectLogger>.CreateIndex("insertupdatelogger");
            var obj = ObjectCompare.CompareObjects(result.First(), result.Last());
            
            return result;
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
