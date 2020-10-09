using ElearningProjectBusiness.Interface;
using ElearningProjectServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectServices.Services
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        public ILearningPathService LearningPathService { get; set; }
        public IUserService UserService { get; set; }
        public IAccountService AccountService { get; set; }
        public ITokenService TokenService { get; set; }
        public IRoleService RoleService { get; set; }
        public ICourseService CourseService { get; set; }

        public UnitOfWorkService(ILearningPathService learningPathService,
                                 IUserService userService,
                                 IAccountService accountService,
                                 ITokenService tokenService,
                                 IRoleService roleService,
                                 ICourseService courseService
            )
        {
            UserService = userService;
            LearningPathService = learningPathService;
            AccountService = accountService;
            TokenService = tokenService;
            RoleService = roleService;
            CourseService = courseService;
        }
    }
}
