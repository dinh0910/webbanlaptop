using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class Quyen
    {
        public int QuyenID { get; set; }

        [Display(Name = "Tên")]
        public string? Ten { get; set; }
    }
}
