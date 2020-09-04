using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class CategoryCreate
    {
        public int Id { set; get; }
        [DisplayName("Tên Danh Mục")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String CategoryName { set; get; }
        [DisplayName("Thông Tin Vắn Tắt")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public string ShortDescription { set; get; }
        [DisplayName("Danh Mục Cha")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public string ParentCategoryName { set; get; }
        [DisplayName("Link Ảnh")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public IFormFile Photo { set; get; }

    }
}
