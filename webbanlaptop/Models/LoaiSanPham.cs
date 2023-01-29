using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class LoaiSanPham
    {
        public int LoaiSanPhamID { get; set; }

        [Display(Name = "Tên loại")]
        public string? Ten { get; set; }
    }
}
