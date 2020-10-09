using ElearningProjectBusiness.Interface;
using ElearningProjectModels.Models;
using ElearningProjectModels.ViewModels;
using ElearningProjectRepository.Implementation;
using ElearningProjectRepository.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningProjectBusiness.Implementation
{
    public class FileUploadBusiness : IFileUpload
    {
        private IDapperBase _dapperBase;
        public FileUploadBusiness(IDapperBase dapperRepository)
        {
            _dapperBase = dapperRepository;
        }

        public async Task<bool> FileUpload(List<IFormFile> files)
        {
            if(files.Any())
            {
                foreach(var file in files)
                {
                    var fileExtention = Path.GetExtension(GetFileName(file));
                  
                    var parameters = new
                    {
                        @FileName = GetNewFileName(fileExtention),
                        @File = ProcessFile(file),
                        @FileType = fileExtention,
                        @CreatedDate = DateTime.Now
                    };

                    return await AddFile(parameters);

                }
            }

            return false;

        }

        private string GetFileName(IFormFile file)
        {
            return Path.GetFileName(file.FileName);
        }

        private string GetNewFileName(string fileExtention)
        {
            return string.Concat(Convert.ToString(Guid.NewGuid()), fileExtention);
        }

        private async Task<byte[]> ProcessFile(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                await file.CopyToAsync(target);
                return target.ToArray();
            }
        }
      
        private async Task<bool> AddFile(object parameters)
        {
            return await _dapperBase.ExecuteQuery("sp_UploadFile", parameters);
        }
    }
}
