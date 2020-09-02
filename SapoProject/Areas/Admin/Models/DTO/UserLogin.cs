using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class UserLogin
    {
        public int Id { set; get; }
        [DisplayName("Tài Khoản")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mời Nhập Tên Tài Khoản!")]
        [StringLength(50, MinimumLength = 1)]
        public String userAccount { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mời Nhập Mật Khẩu Tài Khoản!")]
        [StringLength(50, MinimumLength = 1)]
        [DisplayName("Mật Khẩu")]
        public String userPassWord { set; get; }
        public bool rememberPassWord { set; get; }

    }
}
