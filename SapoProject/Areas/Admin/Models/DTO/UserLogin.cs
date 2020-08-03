using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class UserLogin
    {
        public int Id { set; get; }
        [Display(Name = "User Account")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name!")]
        [StringLength(50, MinimumLength = 1)]
        public String userAccount { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your Pass Word!")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "User Pass Word")]
        public String userPassWord { set; get; }
        public bool rememberPassWord { set; get; }

    }
}
