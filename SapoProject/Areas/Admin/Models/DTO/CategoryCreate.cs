using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace SapoProject.Areas.Admin.Models.DTO
{
    public class CategoryCreate
    {
        public int Id { set; get; }
        public String CategoryName { set; get; }
        public string ShortDescription { set; get; }
        public string ParentCategoryName { set; get; }
        public IFormFile Photo { set; get; }

    }
}
