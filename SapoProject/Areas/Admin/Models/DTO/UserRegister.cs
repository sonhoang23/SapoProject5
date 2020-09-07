using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SapoProject.Areas.Admin.Models.DTO
{
    public class UserRegister
    {
        public int id { set; get; }
        [DisplayName("Tên Khách Hàng")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String userName { set; get; }
        [DisplayName("Số Điện Thoại")]
        [DataType(DataType.PhoneNumber)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String phoneNumber { set; get; }
        [DisplayName("Độ Tuổi")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public int age { set; get; }
        [DisplayName("Giới Tính")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String sex { set; get; }
        [DisplayName("Địa Chỉ Hiện Tại")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String address { set; get; }
        [DisplayName("Quận/ Huyện")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String district { set; get; }
        [DisplayName("Tỉnh Thành")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String city { set; get; }
        [DisplayName("Đất Nước")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String country { set; get; }

        [DisplayName("Địa Chỉ Email")]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String email { set; get; }
        [DisplayName("Địa Chỉ Email Xác Nhận")]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String emailReset { set; get; }
        [DisplayName("Tên Tài Khoản")]
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String userAccount { set; get; }
        [DisplayName("Mật Khẩu")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String userPassWord { set; get; }
        [DisplayName("Nhập Lại Mật Khẩu")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Không Được Để Trống!")]
        public String userPassWordAgain { set; get; }
    }
}
