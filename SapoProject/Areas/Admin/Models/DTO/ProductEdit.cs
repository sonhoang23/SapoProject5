using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class ProductEdit
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
        public string CategoryName { set; get; }
        [DisplayName("Danh Mục Sản Phẩm Muốn Thay Thế")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public string CategoryNameEdit { set; get; }
        [DisplayName("Đường Link Ảnh")]
        public String FilePath { set; get; }
        [DisplayName("Lượt Xem")]
        public int ViewCount { set; get; }
        [Display(Name = "Ngày Tạo Sản Phẩm")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { set; get; }
        [DisplayName("Ngày Cuối Cùng Sửa Thông Tin Sản Phẩm")]
        public DateTime FixedDate { set; get; }
        [DisplayName("Link Ảnh Thay Thế")]
        public IFormFile Photo { set; get; }
        [DisplayName("Tinh Trạng")]
        public int Status { set; get; }
    }
}
