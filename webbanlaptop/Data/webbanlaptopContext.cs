﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webbanlaptop.Models;

namespace webbanlaptop.Data
{
    public class webbanlaptopContext : DbContext
    {
        public webbanlaptopContext (DbContextOptions<webbanlaptopContext> options)
            : base(options)
        {
        }

        public DbSet<webbanlaptop.Models.Banner> Banner { get; set; }

        public DbSet<webbanlaptop.Models.DanhMuc> DanhMuc { get; set; }

        public DbSet<webbanlaptop.Models.DonDatHang> DonDatHang { get; set; }

        public DbSet<webbanlaptop.Models.ChiTietDatHang> ChiTietDatHang { get; set; }

        public DbSet<webbanlaptop.Models.HinhAnh> HinhAnh { get; set; }

        public DbSet<webbanlaptop.Models.Quyen> Quyen { get; set; }

        public DbSet<webbanlaptop.Models.SanPham> SanPham { get; set; }

        public DbSet<webbanlaptop.Models.TaiKhoan> TaiKhoan { get; set; }

        public DbSet<webbanlaptop.Models.ThongSo> ThongSo { get; set; }

        public DbSet<webbanlaptop.Models.ThuongHieu> ThuongHieu { get; set; }

        public DbSet<webbanlaptop.Models.KhuyenMai> KhuyenMai { get; set; }

        public DbSet<webbanlaptop.Models.Mau> Mau { get; set; }

        public DbSet<webbanlaptop.Models.ThongTin> ThongTin { get; set; }

        public DbSet<webbanlaptop.Models.DonViTinh> DonViTinh { get; set; }

        public DbSet<webbanlaptop.Models.NhaCungCap> NhaCungCap { get; set; }

        public DbSet<webbanlaptop.Models.NhapHang> NhapHang { get; set; }

        public DbSet<webbanlaptop.Models.ChiTietNhapHang> ChiTietNhapHang { get; set; }
    }
}
