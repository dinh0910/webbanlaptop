using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class ThongSo
    {
        public int ThongSoID { get; set; }

        [Display(Name = "Sản phẩm")]
        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; }

        [Display(Name = "Tên thông số")]
        public int TenThongSoID { get; set; }
        public TenThongSo? TenThongSos { get; set; }

        [Display(Name = "Nội dung")]
        public string? NoiDung { get; set; }
    }
}
