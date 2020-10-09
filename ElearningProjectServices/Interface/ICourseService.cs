using ElearningProjectModels.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static ElearningProjectModels.Enum.Enum;

namespace ElearningProjectServices.Interface
{
    public interface ICourseService
    {
        Task<Status> Insert(Course course);
    }
}
