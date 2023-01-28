using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class GiaoHang
    {
        public int GiaoHangID { get; set; }

        [Display(Name = "Mã đơn")]
        public int DonDatHangID { get; set; }
        public DonDatHang? DonDatHangs { get; set; }

        [Display(Name = "Họ tên")]
        public string? HoTen { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? SoDienThoai { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }
    }
}
