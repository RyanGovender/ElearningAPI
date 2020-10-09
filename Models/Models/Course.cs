using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectModels.Models
{
    public class Course : BaseModel
    {
        public string CourseName { get; set; }
        public string ShortDescription { get; set; }
        public string UserId { get; set; }
        public int LearningPathId { get; set; }

    }
}
