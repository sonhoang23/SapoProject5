using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class ProductCreate
    {
        public int Id { set; get; }
        [Required]
        public String ProductName { set; get; }
        [Required]
        public String Price { set; get; }
        [Required]
        public String OriginalPrice { set; get; }
        [Required]
        public String ShortDescription { set; get; }
        [Required]
        public String EntireDescription { set; get; }
        [Required]
        //    public Dept? Department { set; get; } 
        public IFormFile Photo { set; get; }


    }
}
