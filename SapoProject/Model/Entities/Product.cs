using System;
using System.ComponentModel.DataAnnotations;


namespace SapoProject.Model.Entities
{
    public class Product
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

        public int Status { set; get; }
        public int CategoryId { get; set; }
        public Category Category { set; get; }
        public OrderDetail OrderDetail { set; get; }
    }
}
