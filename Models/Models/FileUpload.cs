using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElearningProjectModels.Models
{
    public class FileUpload : BaseModel
    {
        [MaxLength]
        public byte [] File { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
    }
}
