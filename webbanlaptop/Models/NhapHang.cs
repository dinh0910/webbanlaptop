using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class NhapHang
    {
        public int NhapHangID { get; set; }

        public int TaiKhoanID { get; set; }
        public TaiKhoan? TaiKhoans { get; set; }

        [Display(Name = "Nhà cung cấp")]
        public int NhaCungCapID { get; set; }
        public NhaCungCap? NhaCungCaps { get; set; }

        [Display(Name = "Ngày nhập")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayNhap {  get; set; }

        public ICollection<ChiTietNhapHang>? ChiTietNhapHangs { get; set; }
    }
}
