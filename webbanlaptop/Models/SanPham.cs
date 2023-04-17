using System.ComponentModel.DataAnnotations;

namespace webbanlaptop.Models
{
    public class SanPham
    {
        public int SanPhamID { get; set; }

        [Display(Name = "Danh mục")]
        public int DanhMucID { get; set; }
        public DanhMuc? DanhMucs { get; set; }

        [Display(Name = "Thương hiệu")]
        public int ThuongHieuID { get; set; }
        public ThuongHieu? ThuongHieus { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string? Ten { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? HinhAnh { get; set; }

        [Display(Name = "Đơn giá")]
        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int DonGia { get; set; }

        [Display(Name = "Giảm giá")]
        public int GiamGia { get; set; }

        public string? DacTrung { get; set; }

        [Display(Name = "Thành tiền")]
        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int ThanhTien { get; set; }

        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; } = 0;
    }
}
