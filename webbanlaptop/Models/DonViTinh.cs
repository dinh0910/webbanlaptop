using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class DonViTinh
    {
        public int DonViTinhID { get; set; }

        [Display(Name = "Tên")]
        public string? Ten { get; set; }
    }
}
