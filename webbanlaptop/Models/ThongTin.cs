using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class ThongTin
    {
        public int ThongTinID { get; set; }

        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; }

        public string? TrongHop { get; set; }

        public string? BaoHanhPin { get; set; }

        public string? BaoHanh { get; set; }
    }
}
