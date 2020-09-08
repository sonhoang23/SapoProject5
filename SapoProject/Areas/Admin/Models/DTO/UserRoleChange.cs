using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class UserRoleChange
    {
        public string UserId { set; get; }
        public string UserName { set; get; }
        public bool IsSelected { set; get; }
    }
}
