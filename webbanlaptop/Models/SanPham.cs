using System.ComponentModel.DataAnnotations;

namespace webbanlaptop.Models
{
    public class SanPham
    {
        public int SanPhamID { get; set; }

        [Display(Name = "Danh mục")]
        public int DanhMucConID { get; set; }
        public DanhMucCon? DanhMucCons { get; set; }

        [Display(Name = "Loại sản phẩm")]
        public int LoaiSanPhamID { get; set; }
        public LoaiSanPham? LoaiSanPhams { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string? Ten { get; set; }

        [Display(Name = "Hình ảnh")]
        public string? HinhAnh { get; set; }

        [Display(Name = "Đơn giá")]
        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int DonGia { get; set; }

        [Display(Name = "Thương hiệu")]
        public int ThuongHieuID { get; set; }
        public ThuongHieu? ThuongHieus { get; set; }
       
    }
}
