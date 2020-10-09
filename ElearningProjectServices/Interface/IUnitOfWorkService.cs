using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ElearningProjectServices.Interface
{
    public interface IUnitOfWorkService
    {
        ILearningPathService LearningPathService { get; set; }
        IUserService  UserService { get; set; }
        IAccountService AccountService { get; set; }
        ITokenService TokenService { get; set; }
        IRoleService RoleService { get; set; }
        ICourseService CourseService { get; set; }
    }
}
