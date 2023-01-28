using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class DanhMuc
    {
        public int DanhMucID { get; set; }

        [Display(Name = "Tên danh mục")]
        public string? Ten { get; set; }
    }
}
