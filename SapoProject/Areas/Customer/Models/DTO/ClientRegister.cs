using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Customer.Models.DTO
{
    public class ClientRegister
    {
        public int id { set; get; }
        [Required]
        public String userName { set; get; }
        [Required]
        public String phoneNumber { set; get; }
    
        [Required]
        public int age { set; get; }
        [Required]
        public String sex { set; get; }
        [Required]
        public String address { set; get; }
        [Required]
        public String district { set; get; }
        [Required]
        public String city { set; get; }
        [Required]
        public String country { set; get; }

        [Required]
        public String email { set; get; }
        [Required]
        public String emailReset { set; get; }
        [Required]
        public String userAccount { set; get; }
        [Required]
        public String userPassWord { set; get; }
        [Required]
        public String userPassWordAgain { set; get; }
    }
}
