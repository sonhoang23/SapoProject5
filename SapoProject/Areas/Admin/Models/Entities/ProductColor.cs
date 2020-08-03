using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.Entities
{
    public class ProductColor
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public Product Product { set; get; }
        public int ColorId { set; get; }
        public Color Color { set; get; }
        public String Quantity { set; get; }
      
    }
}
