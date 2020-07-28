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
        public String ProductName { set; get; }
        public String Price { set; get; }
        public String OriginalPrice { set; get; }
        public String ShortDescription { set; get; }
        public String EntireDescription { set; get; }
    //    public Dept? Department { set; get; }
        public IFormFile Photo { set; get; }

       
    }
}
