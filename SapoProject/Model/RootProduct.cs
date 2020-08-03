using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Models.Entities
{
    public class RootProduct
    {
        public int Id { set; get; }
        public String ProductName { set; get; }
        public String Price { set; get; }
        public String OriginalPrice { set; get; }
        public String ShortDescription { set; get; }
        public String EntireDescription { set; get; }
        public String FilePath { set; get; }
        public int ViewCount { set; get; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { set; get; }
        public DateTime FixedDate { set; get; }
       

    }
}
