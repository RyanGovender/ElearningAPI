using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace ElearningProjectModels.ViewModels
{
   public class FileUploadViewModel
    {
        public IFormFile File { get; set; }
        public string Name { get; set; }
    }

    public class LearningPathFileUploadViewModel : FileUploadViewModel
    {
        [Key]
        public int LearningPathId { get; set; }

    }

}
