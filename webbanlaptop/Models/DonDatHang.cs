using System.ComponentModel.DataAnnotations;

namespace webbanlaptop.Models
{
    public class DonDatHang
    {
        public int DonDatHangID { get; set; }
        public DateTime NgayLap { get; set; }
        public string? DiaChi { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? GhiChu { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int TienShip { get; set; }

        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int TongTien { get; set; }
        public int DaVanChuyen { get; set; } = 0;
        public int HuyDon { get; set; } = 0;
        public int HinhThucThanhToanID { get; set; }
        public HinhThucThanhToan? HinhThucThanhToans { get; set; }
    }
}
