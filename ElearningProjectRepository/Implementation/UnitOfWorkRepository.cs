using ElearningProjectModels.Models;
using ElearningProjectRepository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectRepository.Implementation
{
    public class UnitOfWorkRepository : IUnitOfWork
    {
        public IDapperBase DapperBaseRepository { get; set; }
        public ILearningPath LearningPathRepository { get ; set; }
        public IUsers UserRepository { get; set; }
        public IRole RoleRepositroy { get; set; }
        public ICourse CourseRepository { get; set; }

        public UnitOfWorkRepository(IDapperBase dapperBaseRepository,
                                    ILearningPath learningPathRepository,
                                    IUsers userRepository,
                                    IRole roleReposiotry,
                                    ICourse courseRepository
            )
        {
            DapperBaseRepository = dapperBaseRepository;
            LearningPathRepository = learningPathRepository;
            UserRepository = userRepository;
            RoleRepositroy = roleReposiotry;
            CourseRepository = courseRepository;
        }
    }
}
