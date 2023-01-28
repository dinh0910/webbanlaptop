using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class HinhAnh
    {
        public int HinhAnhID { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? Anh { get; set; }

        [Display(Name = "Sản phẩm")]
        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; }
    }
}
