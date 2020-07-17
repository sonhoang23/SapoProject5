using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.Entities
{
    public class Product
    {
        public int id { set; get; }
        public String productName { set; get; }
        public String Price { set; get; }
        public String OriginalPrice { set; get; }
        public String shortDescription { set; get; }
        public String entireDescription { set; get; }
        public int ViewCount { set; get; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime DateCreated { set; get; }
    }
}
