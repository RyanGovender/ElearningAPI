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
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectServices.Services
{
    public class LearningPathService : ILearningPathService
    {
        private IUnitOfWork _iUnitOfWork;
        
        public LearningPathService(IUnitOfWork unitOfWork)
        {
            _iUnitOfWork = unitOfWork;
        }
        //public async Task<bool> Delete(int? id)
        //{
        //    return await _iUnitOfWork.LearningPathRepository.(id);
        //}

        public async Task<IQueryable<LearningPath>> GetAll()
        {
            var result = await _iUnitOfWork.LearningPathRepository.GetAll();
            ////ElasticLogic<LearningPath>.AddToIndex(result.Last(), "learningpath");
            // ElasticLogic<ObjectLogger>.CreateIndex("objectchangelogger");
            //var obj = ObjectCompare.CompareObjects(result.First(), result.Last());
            
            return result;
        }

        public async Task<Status> Inset(LearningPath data)
        {
            var result = await _iUnitOfWork.LearningPathRepository.Insert(data);
            return (Status)result;
        }

        public async Task<Status> Update(LearningPath data)
        {
            var result = await _iUnitOfWork.LearningPathRepository.Update(data);
            return (Status)result;
        }
    }
}
