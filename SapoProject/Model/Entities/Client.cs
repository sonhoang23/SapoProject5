using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace SapoProject.Model.Entities
{
    public class Client
    {
        public int Id { set; get; }
        public String CustomerName { set; get; }
        public String PhoneNumber { set; get; }
        public String Address { set; get; }
        [Range(1, 100, ErrorMessage = "Price must be between 1 and 100")]
        public int Age { set; get; }
        public string Sex { set; get; }
        public String Email { set; get; }
        public String EmailReset { set; get; }
        public String ClientAccount { set; get; }
        public String ClientPassWord { set; get; }
        public int ClientRole { set; get; }
        public int Status { set; get; }
        public List<OrderClient> OrderClient { set; get; }

    }
}
