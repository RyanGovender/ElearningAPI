using ElearningProjectModels.Models;
using ElearningProjectRepository.Implementation;
using ElearningProjectRepository.Interface;
using ElearningProjectServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectServices.Services
{
    public class CourseService : ICourseService
    {
        private IUnitOfWork unitOfWork;
        public CourseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<Status> Insert(Course course)
        {
            var result = await  unitOfWork.CourseRepository.Insert(course);
            return (Status)result;
        }
    }
}
