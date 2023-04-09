namespace webbanlaptop.Models
{
    public class ImportItem
    {
        public int SanPhamID { get; set; }
        public SanPham SanPham { get; set; }

        public int DonViTinhID { get; set; }
        public DonViTinh DonViTinh { get; set; }

        public int SoLuong { get; set; }
    }
}
