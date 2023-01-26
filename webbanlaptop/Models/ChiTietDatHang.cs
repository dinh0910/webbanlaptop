using System.ComponentModel.DataAnnotations;

namespace webbanlaptop.Models
{
    public class ChiTietDatHang
    {
        public int ChiTietDatHangID { get; set; }
        public int DonDatHangID { get; set; }
        public int SanPhamID { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int DonGia { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int SoLuong { get; set; }
        public int ThanhTien { get; set; }
        public DonDatHang? DonDatHangs { get; set; }
        public SanPham? SanPhams { get; set; }
    }
}
