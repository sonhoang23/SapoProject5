using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Model.Entities
{
    public class Color
    {
        public int Id { set; get; }
        public String ColorName { set; get; }
        public List<ProductColor> ProductColors { get; set; }
    }
}
