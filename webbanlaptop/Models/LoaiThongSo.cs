﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace webbanlaptop.Models
{
    public class LoaiThongSo
    {
        public int LoaiThongSoID { get; set; }

        [Display(Name = "Tên")]
        public string? Ten { get; set; }
    }
}
