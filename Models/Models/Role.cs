using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectModels.Models
{
    public class Role 
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
