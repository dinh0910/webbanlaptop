namespace webbanlaptop.Models
{
    public class ThongTinSanPham
    {
        public int ThongTinSanPhamID { get; set; }
        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; }
        public int ThongTinID { get; set; }
        public ThongTin? ThongTins { get; set; }
    }
}
