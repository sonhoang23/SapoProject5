using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Model.Entities
{
    public class WebInfor
    {
        public int id { set; get; }
        public String InforName { set; get; }
        public String shortDescription { set; get; }
        public String entireDescription { set; get; }
        public String phoneNumber { set; get; }
        public String address { set; get; }
        public String email { set; get; }
        public int ViewCount { set; get; }
        public DateTime DateCreated { set; get; }
    }
}
