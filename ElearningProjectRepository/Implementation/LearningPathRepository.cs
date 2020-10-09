using Dapper;
using ElearningProjectDAL.DAL;
using ElearningProjectModels.Models;
using ElearningProjectRepository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectRepository.Implementation
{
    public class LearningPathRepository : ILearningPath
    {
        private IDapperBase _dapperBaseRepository;
        public LearningPathRepository(IDapperBase dapperbase)
        {
            _dapperBaseRepository = dapperbase;
        }

        public async Task<bool> AddAsync(LearningPath model)
        {
                var parameters = new { 
                    model.Name,
                    model.Slug,
                    model.TotalCourses,
                    model.PathIcon,
                    model.LearningPathDescription,
                   @CreateDate = DateTime.Now,
                   @ModifiedDate = DateTime.Now };

            var result = await _dapperBaseRepository.ExecuteQuery("sp_AddLearningPath",parameters);

            return result;

        }

        public async Task<bool> DeleteAsync(int? id)
        {
            var parameters = new { @Id = id };

            var result = await _dapperBaseRepository.ExecuteQuery("sp_DeleteLearningPath", parameters);

            return result;
        }

        public async Task<IQueryable<LearningPath>> GetAllAsync()
        {
            var result = await _dapperBaseRepository.Query<LearningPath>("sp_GetAllLearningPath", null);

            return result;
        }

        public async Task<bool> UpdateAsync(LearningPath model)
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

            var result = await _dapperBaseRepository.ExecuteQuery("sp_UpdateLearningPath", parameters);

            return result;

        }
    }
}
