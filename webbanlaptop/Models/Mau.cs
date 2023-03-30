using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class Mau
    {
        public int MauID { get; set; }

        [Display(Name = "Màu sắc")]
        public string? Ten { get; set; }
    }
}
