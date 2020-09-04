using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class AdvertisementCreate
    {
        public int Id { set; get; }
        [DisplayName("Tên Quảng Cáo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String AdvertisementName { set; get; }
        [DisplayName("Thông Tin Vắt Tắt")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String AdvertisementShortDescription { set; get; }
        [DisplayName("Thông Tin Chi Tiết")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String AdvertisementLongDescription { set; get; }
        [DisplayName("Link Ảnh")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public IFormFile Photo { set; get; }
        [DisplayName("Đường Dẫn Sản Phẩm Đích")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String AdvertisementDestination { set; get; }
        [DisplayName("Ngày Tạo Chiến Dịch Quảng Cáo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public DateTime DateCreated { set; get; }
        [DisplayName("Ngày Kết Thúc Chiến Dịch Quảng Cáo")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public DateTime CompletedDate { set; get; }
        [DisplayName("Tình Trạng")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public int Status { set; get; }
    }
}
