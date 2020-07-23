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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name")]
        public String userAccount { set; get; }
        [Required]
        public String userPassWord { set; get; }

    }
}
