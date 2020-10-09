using ElearningProjectRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectRepository.Implementation
{
   public interface IUnitOfWork
    {
        IDapperBase DapperBaseRepository { get; set; }
        ILearningPath LearningPathRepository { get; set; }
        IUsers UserRepository { get; set; }
        IRole RoleRepositroy { get; set; }
        ICourse CourseRepository { get; set; }

    }
}
