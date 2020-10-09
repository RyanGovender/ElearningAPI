using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ElearningProjectModels.ViewModels
{
   public class UserRoleViewModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
