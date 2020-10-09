using ElearningProjectModels.Models;
using ElearningProjectRepository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectRepository.Implementation
{
    public class CourseRepository : ICourse
    {
        private IDapperBase _dapperBase;
        public CourseRepository(IDapperBase dapperBase)
        {
            _dapperBase = dapperBase;
        }
        public Task<IQueryable<Course>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<int> Insert(Course model)
        {
            var parameters = new { model.ShortDescription,@Email = model.UserId,model.CourseName,model.LearningPathId,model.CreatedDate }; //UserId takes the email and the finds the userid from the users table in the database.
            return await _dapperBase.Excute("sp_AddCourse", parameters);
        }

        public Task<int> Update(Course model)
        {
            throw new NotImplementedException();
        }
    }
}
