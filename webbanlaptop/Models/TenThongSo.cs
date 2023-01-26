namespace webbanlaptop.Models
{
    public class TenThongSo
    {
        public int TenThongSoID { get; set; }
        public int LoaiThongSoID { get; set; }
        public string? Ten { get; set; }
        public LoaiThongSo? LoaiThongSos { get; set; }
    }
}
