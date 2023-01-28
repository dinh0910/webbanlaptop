using System.ComponentModel.DataAnnotations;

namespace webbanlaptop.Models
{
    public class DonDatHang
    {
        public int DonDatHangID { get; set; }

        [Display(Name = "Ngày lập")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayLap { get; set; }

        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        [Display(Name = "Tiền ship")]
        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int TienShip { get; set; }

        [Display(Name = "Tổng tiền")]
        [DisplayFormat(DataFormatString = "{0:#,##0} đ")]
        public int TongTien { get; set; }

        [Display(Name = "Duyệt đơn")]
        public int DuyetDon { get; set; }

        [Display(Name = "Địa chỉ")]
        public int HuyDon { get; set; } = 0;

        [Display(Name = "Hình thức")]
        public int HinhThucThanhToanID { get; set; }
        public HinhThucThanhToan? HinhThucThanhToans { get; set; }
    }
}
