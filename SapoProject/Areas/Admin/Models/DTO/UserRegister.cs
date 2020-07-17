using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class UserRegister
    {
        public int id { set; get; }
        public String userName { set; get; }
        public String phoneNumber { set; get; }
        public String address { set; get; }
        public int age { set; get; }
        public String email { set; get; }
        public String emailReset { set; get; }
        public String userAccount { set; get; }
        public String userPassWord { set; get; }
        public String userPassWordAgain { set; get; }
    }
}
