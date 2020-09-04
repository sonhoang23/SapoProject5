using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class OrderClientShow
    {
        public int OrderId { set; get; }

        public String Status { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateCompleted { set; get; }

        //User entity
        public String ClientName { set; get; }
        public String PhoneNumer { set; get; }

    }
}
