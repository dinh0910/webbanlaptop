using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class NhaCungCap
    {
        public int NhaCungCapId { get; set; }

        [Display(Name = "Tên nhà cung cấp")]
        public string? Ten { get; set; }
    }
}
