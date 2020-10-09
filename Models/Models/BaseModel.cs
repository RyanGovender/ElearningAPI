using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectModels.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
