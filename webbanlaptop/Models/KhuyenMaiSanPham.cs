namespace webbanlaptop.Models
{
    public class KhuyenMaiSanPham
    {
        public int KhuyenMaiSanPhamID { get; set; }
        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; } 
    }
}
