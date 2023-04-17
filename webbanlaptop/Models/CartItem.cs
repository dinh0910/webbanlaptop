namespace webbanlaptop.Models
{
    public class CartItem
    {
        public int SanPhamID { get; set; }
        public SanPham SanPham { get; set; }
        public int SoLuong { get; set; }
    }

    public class CartLove
    {
        public SanPham SanPhams { get; set; }

    }
}
