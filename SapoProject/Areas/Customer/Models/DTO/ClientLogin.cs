using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.Models.DTO
{
    public class ClientLogin
    {
        public int Id { set; get; }
        [Display(Name = "User Account")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the name!")]
        [StringLength(50, MinimumLength = 1)]
        public String clientAccount { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your Pass Word!")]
        [StringLength(50, MinimumLength = 1)]
        [Display(Name = "User Pass Word")]
        public String clientPassWord { set; get; }
        public bool rememberPassWord { set; get; }

    }
}
