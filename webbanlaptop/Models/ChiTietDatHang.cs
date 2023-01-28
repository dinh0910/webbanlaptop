using System.ComponentModel.DataAnnotations;

namespace webbanlaptop.Models
{
    public class ChiTietDatHang
    {
        public int ChiTietDatHangID { get; set; }

        [Display(Name = "Mã đơn")]
        public int DonDatHangID { get; set; }
        public DonDatHang? DonDatHangs { get; set; }

        [Display(Name = "Sản phẩm")]
        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; }

        [Display(Name = "Đơn giá")]
        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int DonGia { get; set; }

        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Display(Name = "Thành tiền")]
        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int ThanhTien { get; set; }

    }
}
