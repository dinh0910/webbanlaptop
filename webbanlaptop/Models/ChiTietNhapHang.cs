using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class ChiTietNhapHang
    {
        public int ChiTietNhapHangID { get; set; }

        [Display(Name = "Mã phiếu nhập")]
        public int NhapHangID { get; set; }
        public NhapHang? NhapHangs { get; set; }

        [Display(Name = "Sản phẩm")]
        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; }

        [Display(Name = "Đơn vị tính")]
        public int DonViTinhID { get; set; }
        public DonViTinh? DonViTinhs { get; set; }

        [Display(Name = "Đơn giá")]
        public int DonGia { get; set; }

        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

       [Display(Name = "Thành tiền")]
        public int ThanhTien { get; set; }
    }
}
