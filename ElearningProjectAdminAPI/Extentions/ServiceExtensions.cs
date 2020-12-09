using ElasticSearch_Libary.Interface;
using ElasticSearch_Libary.Logic;
using ElearningProjectBusiness.Implementation;
using ElearningProjectBusiness.Interface;
using ElearningProjectRepository.Implementation;
using ElearningProjectRepository.Interface;
using ElearningProjectServices.Interface;
using ElearningProjectServices.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectAdminAPI.Extentions
{
    public static class ServiceExtensions
    {
        public static readonly string webAddress = "http://localhost:44355";
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        public static void AddJwtBeare(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = webAddress,
                       ValidAudience = webAddress,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
               };
               });
        }

        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<ILearningPath, LearningPathRepository>();
            services.AddTransient<IDapperBase, DapperBaseRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWorkRepository>();
            services.AddTransient<ILearningPathService, LearningPathService>();
            services.AddTransient<IUsers, UserRepository>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUnitOfWorkService, UnitOfWorkService>();
            services.AddTransient<IAccountBusiness, AccountBusiness>();
            services.AddTransient<IUnitOfWorkBusiness, UnitOfWorkBusiness>();
            services.AddTransient<IEncryptionBusiness, EncryptionBusiness>();
            services.AddTransient<ILoginBusiness, AccountBusiness>();
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IToken, TokenBusiness>();
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IRole, RoleRepository>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IRoleBusiness, RoleBusiness>();
            services.AddTransient<ICourse, CourseRepository>();
            services.AddTransient<ICourseService, CourseService>();
        }

        
    }
}
