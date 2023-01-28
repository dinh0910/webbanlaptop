using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class ThuongHieu
    {
        public int ThuongHieuID { get; set; }

        [Display(Name = "Tên")]
        public string? Ten { get; set; }
    }
}
