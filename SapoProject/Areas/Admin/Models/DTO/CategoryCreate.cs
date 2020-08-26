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
        [Required]
        public String CategoryName { set; get; }
        [Required]
        public string ShortDescription { set; get; }
        [Required]
        public string ParentCategoryName { set; get; }
        [Required]
        public IFormFile Photo { set; get; }

    }
}
