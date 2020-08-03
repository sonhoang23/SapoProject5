using System;
using System.Collections.Generic;
using SapoProject.Models.Entities;

namespace SapoProject.Areas.Admin.Models.Entities
{
    public class Product : RootProduct
    {
        public int Status { set; get; }
        //     public int CategoryId { get; set; }
        //  public Category Category { set; get; }
        public List<ProductColor> ProductColors { get; set; }

    }
}
