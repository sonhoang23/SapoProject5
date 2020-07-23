using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.Entities
{
    public class User
    {
        public int Id { set; get; }
        public String UserName { set; get; }
        public String PhoneNumber { set; get; }
        public String Address { set; get; }
        [Range(1, 100, ErrorMessage = "Price must be between 1 and 100")]
        public int Age { set; get; }
        public String Email { set; get; }
        public String EmailReset { set; get; }
        public String UserAccount { set; get; }
        public String UserPassWord { set; get; }
        public int Status { set; get; }
    }
}
