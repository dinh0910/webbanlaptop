using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class TaiKhoan
    {
        public int TaiKhoanID { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản!")]
        [Display(Name = "Tên tài khoản")]
        public string? TenTaiKhoan { get; set; }

        [Required]
        [Display(Name = "Mật khẩu")]
        public string MatKhau { get; set; }

        [Display(Name = "Họ tên")]
        public string? HoTen { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? SoDienThoai { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Quyền")]
        public int QuyenID { get; set; } = 3;
        public Quyen? Quyens { get; set; }
    }
}
