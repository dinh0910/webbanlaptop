namespace webbanlaptop.Models
{
    public class HinhAnh
    {
        public int HinhAnhID { get; set; }
        public string? Anh { get; set; }
        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; }
    }
}
