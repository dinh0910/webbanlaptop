namespace webbanlaptop.Models
{
    public class TaiKhoan
    {
        public int TaiKhoanID { get; set; }
        public string? TenTaiKhoan { get; set; }
        public string? MatKhau { get; set; }
        public string? HoTen { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public int QuyenID { get; set; }
        public Quyen? Quyens { get; set; }
    }
}
