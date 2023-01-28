using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class KhuyenMaiSanPham
    {
        public int KhuyenMaiSanPhamID { get; set; }

        [Display(Name = "Khuyến mãi")]
        public int KhuyenMaiID { get; set; }
        public KhuyenMai? KhuyenMais { get; set; }

        [Display(Name = "Sản phẩm")]
        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; } 
    }
}
