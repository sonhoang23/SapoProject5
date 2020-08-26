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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter!")]
        [Display(Name = "Required")]
        public String ProductName { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter!")]
        [Display(Name = "Required")]
        public String Price { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter!")]
        [Display(Name = "Required")]
        public String OriginalPrice { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter!")]
        [Display(Name = "Required")]
        public String ShortDescription { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter!")]
        [Display(Name = "Required")]
        public String EntireDescription { set; get; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter!")]
        [Display(Name = "Required")]
        public String CategoryName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter!")]
        [Display(Name = "Required")]
        public IFormFile Photo { set; get; }


    }
}
