﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class ThongSo
    {
        public int ThongSoID { get; set; }

        [Display(Name = "Sản phẩm")]
        public int SanPhamID { get; set; }
        public SanPham? SanPhams { get; set; }
        
        public string? TenThongSo { get; set; }

        public string? NoiDung { get; set; }
    }
}
