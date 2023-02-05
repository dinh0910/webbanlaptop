using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class ThongTinSanPham
    {
        public int ThongTinSanPhamID { get; set; }

        [Display(Name = "Sản phẩm")]
        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; }

        [Display(Name = "Nội dung")]
        public int ThongTinID { get; set; }
        public ThongTin? ThongTins { get; set; }
    }
}
