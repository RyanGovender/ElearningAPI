using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectModels.Models
{
    public class TopicContent : BaseModel
    {
        public string TopicTitle { get; set; }
        public string Topic_Content { get; set; }
        public int? Views { get; set; }
        public bool? Active { get; set; }
        public int? ContentOrder { get; set; }
        public int TopicId { get; set; }
    }
}
