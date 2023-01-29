using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class ThongTin
    {
        public int ThongTinID { get; set; }

        [Display(Name = "Nội dung")]
        public string? NoiDung { get; set; }
    }
}
