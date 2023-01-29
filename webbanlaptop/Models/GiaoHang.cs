using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class GiaoHang
    {
        public int GiaoHangID { get; set; }

        [Display(Name = "Mã đơn")]
        public int DonDatHangID { get; set; }
        public DonDatHang? DonDatHangs { get; set; }

        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }
    }
}
