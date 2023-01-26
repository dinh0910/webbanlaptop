namespace webbanlaptop.Models
{
    public class ThongSo
    {
        public int ThongSoID { get; set; }
        public int TenThongSoID { get; set; }
        public int SanPhamID { get; set; }
        public string? NoiDung { get; set; }
        public TenThongSo? TenThongSos { get; set; }
        public SanPham? SanPhams { get; set; }
    }
}
