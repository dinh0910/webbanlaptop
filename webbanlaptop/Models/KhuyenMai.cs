using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class KhuyenMai
    {
        public int KhuyenMaiID { get; set; }

        [Display(Name = "Nội dung")]
        public string? NoiDung { get; set; }
    }
}
