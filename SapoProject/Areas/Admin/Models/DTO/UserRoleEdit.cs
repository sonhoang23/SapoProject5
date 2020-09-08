using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class UserRoleEdit
    {
        public UserRoleEdit()
        {
            Users = new List<string>();
        }

        [DisplayName("Id Vai Trò")]
        public string Id { get; set; }
        [DisplayName("Tên Vai Trò")]
        [Required(ErrorMessage = "Tên Vai Trò Là Bắt Buộc")]
        public string RoleName { get; set; }

        public List<string> Users { get; set; }
    }
}
