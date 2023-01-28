using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class TenThongSo
    {
        public int TenThongSoID { get; set; }

        [Display(Name = "Loại thông số")]
        public int LoaiThongSoID { get; set; }
        public LoaiThongSo? LoaiThongSos { get; set; }

        [Display(Name = "Tên thông số")]
        public string? Ten { get; set; }
    }
}
