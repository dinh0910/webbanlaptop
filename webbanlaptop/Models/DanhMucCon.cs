using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class DanhMucCon
    {
        public int DanhMucConID { get; set; }

        [Display(Name = "Danh mục")]
        public int DanhMucID { get; set; }
        public DanhMuc? DanhMucs { get; set; }

        [Display(Name = "Tên")]
        public string? Ten { get; set; }
    }
}
