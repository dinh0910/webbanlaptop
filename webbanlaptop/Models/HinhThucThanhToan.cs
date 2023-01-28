using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class HinhThucThanhToan
    {
        public int HinhThucThanhToanID { get; set; }

        [Display(Name = "Tên hình thức")]
        public string? Ten { get; set; }
    }
}
