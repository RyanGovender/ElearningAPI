using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectBusiness.Interface
{
    public interface IFileUpload 
    {
        Task<bool> FileUpload(List<IFormFile> files);
    }
}
