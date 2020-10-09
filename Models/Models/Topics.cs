using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectModels.Models
{
   public class Topics : BaseModel
    {
        public string TopicTitle { get; set; }
        public int? TopicOrder { get; set; }
        public int CourseId { get; set; }

    }
}
