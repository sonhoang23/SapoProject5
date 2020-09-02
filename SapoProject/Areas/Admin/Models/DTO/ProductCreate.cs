using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class ProductCreate
    {
        public int Id { set; get; }

        [DisplayName("Tên Sản Phẩm")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String ProductName { set; get; }
        [DisplayName("Giá Bán")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String Price { set; get; }
        [DisplayName("Giá Gốc")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String OriginalPrice { set; get; }
        [DisplayName("Thông Tin Vắn Tắt")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String ShortDescription { set; get; }
        [DisplayName("Thông Tin Chi Tiết")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String EntireDescription { set; get; }
        [DisplayName("Danh Mục Sản Phẩm")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String CategoryName { get; set; }
        [DisplayName("Link ảnh")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public IFormFile Photo { set; get; }


    }
}
