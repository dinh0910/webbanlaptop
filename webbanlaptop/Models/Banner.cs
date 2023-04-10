using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class Banner
    {
        public int BannerID { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? HinhAnh { get; set; }

        public string? BiaDau { get; set; }
    }
}
