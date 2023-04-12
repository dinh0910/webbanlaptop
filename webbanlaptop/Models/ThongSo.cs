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
        
        public string? LoaiCard { get; set; }

        public string? Ram { get; set; }

        public string? LoaiRam { get; set; }

        public string? SoKheRam { get; set; }

        public string? OCung { get; set; }

        public string? KichThuocManHinh { get; set; }

        public string? CongNgheManHinh { get; set; }

        public string? Pin { get; set; }

        public string? HeDieuHanh { get; set; }

        public string? DoPhanGiai { get; set; }

        public string? CongGiaoTiep { get; set; }

        public string? TinhNangKhac { get; set; }

        public string? CanNang { get; set; }
    }
}
