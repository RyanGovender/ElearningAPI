using System;
using System.Collections.Generic;
using System.Text;

namespace ElearningProjectModels.Models
{
    public class UserRole 
    {
        public int UserRoleId { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
