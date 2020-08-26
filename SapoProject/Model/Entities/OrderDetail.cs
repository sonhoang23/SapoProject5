using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Model.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { set; get; }
      
        public int Quantity { set; get; }
        public DateTime DateCreated { set; get; }
        public int Status { set; get; }

        //Order
        public int OrderClientId { set; get; }
        public OrderClient OrderClient { set; get; }
        //Product
        public int ProductId { set; get; }
        public Product Product { set; get; }
    }
}
