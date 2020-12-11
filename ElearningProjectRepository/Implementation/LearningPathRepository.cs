using Dapper;
using ElearningProjectDAL.DAL;
using ElearningProjectModels.Models;
using ElearningProjectRepository.Implementation.Global;
using ElearningProjectRepository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectRepository.Implementation
{
    public class LearningPathRepository : ILearningPath
    {
        private IDapperBase _dapperBaseRepository;
        public LearningPathRepository(IDapperBase dapperbase)
        {
            _dapperBaseRepository = dapperbase;
        }

        public async Task<int> Insert(LearningPath model)
        {
                var parameters = new { 
                    model.Name,
                    model.Slug,
                    model.TotalCourses,
                    model.PathIcon,
                    model.LearningPathDescription,
                   @CreateDate = DateTime.Now,
                   @ModifiedDate = DateTime.Now };

            var result = await _dapperBaseRepository.Excute("sp_AddLearningPath",parameters);

            return result;

        }

        public async Task<int> DeleteAsync(int? id)
        {
            var parameters = new { @Id = id };

            var result = await _dapperBaseRepository.Excute("sp_DeleteLearningPath", parameters);

            return result;
        }

        public async Task<IQueryable<LearningPath>> GetAll()
        {
            var result = await _dapperBaseRepository.Query<LearningPath>("sp_GetAllLearningPath", null);

            return result;
        }

        public async Task<int> Update(LearningPath model)
        {
            var parameters = new
            {
                model.Id,
                model.Name,
                model.Slug,
                model.PathIcon,
                model.LearningPathDescription,
                @ModifiedDate = DateTime.Now
            };



            //execute find method to get current details  (async dont await) 
            var currentObject = Find(model.Id);
            var result = await _dapperBaseRepository.Excute("sp_UpdateLearningPath", parameters);
            Elastic.LogInformation(await currentObject, model, ((Status)result).ToString(), "UpdateLearingPath");

            //ObjectCompare
            //object compare
            //log here

            return result;

        }

        public async Task<LearningPath> Find(int? id)
        {
            var parameters = new { id };
            var result = await _dapperBaseRepository.Query<LearningPath>("sp_GinericFind", parameters);
            return result.Any() ? result.FirstOrDefault() : null ;
        }
    }
}
