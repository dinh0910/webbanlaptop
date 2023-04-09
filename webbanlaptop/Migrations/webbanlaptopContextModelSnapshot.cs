﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webbanlaptop.Data;

#nullable disable

namespace webbanlaptop.Migrations
{
    [DbContext(typeof(webbanlaptopContext))]
    partial class webbanlaptopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("webbanlaptop.Models.Banner", b =>
                {
                    b.Property<int>("BannerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BannerID"), 1L, 1);

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BannerID");

                    b.ToTable("Banner");
                });

            modelBuilder.Entity("webbanlaptop.Models.ChiTietDatHang", b =>
                {
                    b.Property<int>("ChiTietDatHangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietDatHangID"), 1L, 1);

                    b.Property<int>("DonDatHangID")
                        .HasColumnType("int");

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("ThanhTien")
                        .HasColumnType("int");

                    b.HasKey("ChiTietDatHangID");

                    b.HasIndex("DonDatHangID");

                    b.HasIndex("SanPhamID");

                    b.ToTable("ChiTietDatHang");
                });

            modelBuilder.Entity("webbanlaptop.Models.ChiTietNhapHang", b =>
                {
                    b.Property<int>("ChiTietNhapHangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietNhapHangID"), 1L, 1);

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<int>("DonViTinhID")
                        .HasColumnType("int");

                    b.Property<int>("NhapHangID")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<int>("ThanhTien")
                        .HasColumnType("int");

                    b.HasKey("ChiTietNhapHangID");

                    b.HasIndex("DonViTinhID");

                    b.HasIndex("NhapHangID");

                    b.HasIndex("SanPhamID");

                    b.ToTable("ChiTietNhapHang");
                });

            modelBuilder.Entity("webbanlaptop.Models.DanhMuc", b =>
                {
                    b.Property<int>("DanhMucID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DanhMucID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DanhMucID");

                    b.ToTable("DanhMuc");
                });

            modelBuilder.Entity("webbanlaptop.Models.DonDatHang", b =>
                {
                    b.Property<int>("DonDatHangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonDatHangID"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DuyetDon")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GhiChu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("NgayLap")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TienShip")
                        .HasColumnType("int");

                    b.Property<int>("TongTien")
                        .HasColumnType("int");

                    b.HasKey("DonDatHangID");

                    b.ToTable("DonDatHang");
                });

            modelBuilder.Entity("webbanlaptop.Models.DonViTinh", b =>
                {
                    b.Property<int>("DonViTinhID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonViTinhID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonViTinhID");

                    b.ToTable("DonViTinh");
                });

            modelBuilder.Entity("webbanlaptop.Models.HinhAnh", b =>
                {
                    b.Property<int>("HinhAnhID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HinhAnhID"), 1L, 1);

                    b.Property<string>("Anh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.HasKey("HinhAnhID");

                    b.HasIndex("SanPhamID");

                    b.ToTable("HinhAnh");
                });

            modelBuilder.Entity("webbanlaptop.Models.KhuyenMai", b =>
                {
                    b.Property<int>("KhuyenMaiID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhuyenMaiID"), 1L, 1);

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KhuyenMaiID");

                    b.ToTable("KhuyenMai");
                });

            modelBuilder.Entity("webbanlaptop.Models.KhuyenMaiSanPham", b =>
                {
                    b.Property<int>("KhuyenMaiSanPhamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KhuyenMaiSanPhamID"), 1L, 1);

                    b.Property<int>("KhuyenMaiID")
                        .HasColumnType("int");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.HasKey("KhuyenMaiSanPhamID");

                    b.HasIndex("KhuyenMaiID");

                    b.HasIndex("SanPhamID");

                    b.ToTable("KhuyenMaiSanPham");
                });

            modelBuilder.Entity("webbanlaptop.Models.LoaiThongSo", b =>
                {
                    b.Property<int>("LoaiThongSoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LoaiThongSoID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoaiThongSoID");

                    b.ToTable("LoaiThongSo");
                });

            modelBuilder.Entity("webbanlaptop.Models.Mau", b =>
                {
                    b.Property<int>("MauID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MauID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MauID");

                    b.ToTable("Mau");
                });

            modelBuilder.Entity("webbanlaptop.Models.NhaCungCap", b =>
                {
                    b.Property<int>("NhaCungCapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NhaCungCapID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("NhaCungCapID");

                    b.ToTable("NhaCungCap");
                });

            modelBuilder.Entity("webbanlaptop.Models.NhapHang", b =>
                {
                    b.Property<int>("NhapHangID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NhapHangID"), 1L, 1);

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<int>("NhaCungCapID")
                        .HasColumnType("int");

                    b.Property<int>("TaiKhoanID")
                        .HasColumnType("int");

                    b.Property<int>("TongTien")
                        .HasColumnType("int");

                    b.HasKey("NhapHangID");

                    b.HasIndex("NhaCungCapID");

                    b.HasIndex("TaiKhoanID");

                    b.ToTable("NhapHang");
                });

            modelBuilder.Entity("webbanlaptop.Models.Quyen", b =>
                {
                    b.Property<int>("QuyenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("QuyenID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("QuyenID");

                    b.ToTable("Quyen");
                });

            modelBuilder.Entity("webbanlaptop.Models.SanPham", b =>
                {
                    b.Property<int>("SanPhamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SanPhamID"), 1L, 1);

                    b.Property<int>("DanhMucID")
                        .HasColumnType("int");

                    b.Property<int>("DonGia")
                        .HasColumnType("int");

                    b.Property<int>("GiamGia")
                        .HasColumnType("int");

                    b.Property<string>("HinhAnh")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SoLuong")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ThanhTien")
                        .HasColumnType("int");

                    b.Property<int>("ThuongHieuID")
                        .HasColumnType("int");

                    b.HasKey("SanPhamID");

                    b.HasIndex("DanhMucID");

                    b.HasIndex("ThuongHieuID");

                    b.ToTable("SanPham");
                });

            modelBuilder.Entity("webbanlaptop.Models.TaiKhoan", b =>
                {
                    b.Property<int>("TaiKhoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaiKhoanID"), 1L, 1);

                    b.Property<string>("DiaChi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HoTen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatKhau")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuyenID")
                        .HasColumnType("int");

                    b.Property<string>("SoDienThoai")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenTaiKhoan")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TaiKhoanID");

                    b.HasIndex("QuyenID");

                    b.ToTable("TaiKhoan");
                });

            modelBuilder.Entity("webbanlaptop.Models.TenThongSo", b =>
                {
                    b.Property<int>("TenThongSoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TenThongSoID"), 1L, 1);

                    b.Property<int>("LoaiThongSoID")
                        .HasColumnType("int");

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TenThongSoID");

                    b.HasIndex("LoaiThongSoID");

                    b.ToTable("TenThongSo");
                });

            modelBuilder.Entity("webbanlaptop.Models.ThongSo", b =>
                {
                    b.Property<int>("ThongSoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThongSoID"), 1L, 1);

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.Property<int>("TenThongSoID")
                        .HasColumnType("int");

                    b.HasKey("ThongSoID");

                    b.HasIndex("SanPhamID");

                    b.HasIndex("TenThongSoID");

                    b.ToTable("ThongSo");
                });

            modelBuilder.Entity("webbanlaptop.Models.ThongTin", b =>
                {
                    b.Property<int>("ThongTinID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThongTinID"), 1L, 1);

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThongTinID");

                    b.ToTable("ThongTin");
                });

            modelBuilder.Entity("webbanlaptop.Models.ThongTinSanPham", b =>
                {
                    b.Property<int>("ThongTinSanPhamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThongTinSanPhamID"), 1L, 1);

                    b.Property<int>("SanPhamID")
                        .HasColumnType("int");

                    b.Property<int>("ThongTinID")
                        .HasColumnType("int");

                    b.HasKey("ThongTinSanPhamID");

                    b.HasIndex("SanPhamID");

                    b.HasIndex("ThongTinID");

                    b.ToTable("ThongTinSanPham");
                });

            modelBuilder.Entity("webbanlaptop.Models.ThuongHieu", b =>
                {
                    b.Property<int>("ThuongHieuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ThuongHieuID"), 1L, 1);

                    b.Property<string>("Ten")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ThuongHieuID");

                    b.ToTable("ThuongHieu");
                });

            modelBuilder.Entity("webbanlaptop.Models.ChiTietDatHang", b =>
                {
                    b.HasOne("webbanlaptop.Models.DonDatHang", "DonDatHangs")
                        .WithMany("ChiTietDatHangs")
                        .HasForeignKey("DonDatHangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbanlaptop.Models.SanPham", "SanPhams")
                        .WithMany()
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonDatHangs");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("webbanlaptop.Models.ChiTietNhapHang", b =>
                {
                    b.HasOne("webbanlaptop.Models.DonViTinh", "DonViTinhs")
                        .WithMany()
                        .HasForeignKey("DonViTinhID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbanlaptop.Models.NhapHang", "NhapHangs")
                        .WithMany("ChiTietNhapHangs")
                        .HasForeignKey("NhapHangID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbanlaptop.Models.SanPham", "SanPhams")
                        .WithMany()
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DonViTinhs");

                    b.Navigation("NhapHangs");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("webbanlaptop.Models.HinhAnh", b =>
                {
                    b.HasOne("webbanlaptop.Models.SanPham", "SanPhams")
                        .WithMany()
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("webbanlaptop.Models.KhuyenMaiSanPham", b =>
                {
                    b.HasOne("webbanlaptop.Models.KhuyenMai", "KhuyenMais")
                        .WithMany()
                        .HasForeignKey("KhuyenMaiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbanlaptop.Models.SanPham", "SanPhams")
                        .WithMany()
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KhuyenMais");

                    b.Navigation("SanPhams");
                });

            modelBuilder.Entity("webbanlaptop.Models.NhapHang", b =>
                {
                    b.HasOne("webbanlaptop.Models.NhaCungCap", "NhaCungCaps")
                        .WithMany()
                        .HasForeignKey("NhaCungCapID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbanlaptop.Models.TaiKhoan", "TaiKhoans")
                        .WithMany()
                        .HasForeignKey("TaiKhoanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NhaCungCaps");

                    b.Navigation("TaiKhoans");
                });

            modelBuilder.Entity("webbanlaptop.Models.SanPham", b =>
                {
                    b.HasOne("webbanlaptop.Models.DanhMuc", "DanhMucs")
                        .WithMany()
                        .HasForeignKey("DanhMucID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbanlaptop.Models.ThuongHieu", "ThuongHieus")
                        .WithMany()
                        .HasForeignKey("ThuongHieuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DanhMucs");

                    b.Navigation("ThuongHieus");
                });

            modelBuilder.Entity("webbanlaptop.Models.TaiKhoan", b =>
                {
                    b.HasOne("webbanlaptop.Models.Quyen", "Quyens")
                        .WithMany()
                        .HasForeignKey("QuyenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quyens");
                });

            modelBuilder.Entity("webbanlaptop.Models.TenThongSo", b =>
                {
                    b.HasOne("webbanlaptop.Models.LoaiThongSo", "LoaiThongSos")
                        .WithMany()
                        .HasForeignKey("LoaiThongSoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiThongSos");
                });

            modelBuilder.Entity("webbanlaptop.Models.ThongSo", b =>
                {
                    b.HasOne("webbanlaptop.Models.SanPham", "SanPhams")
                        .WithMany()
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbanlaptop.Models.TenThongSo", "TenThongSos")
                        .WithMany()
                        .HasForeignKey("TenThongSoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPhams");

                    b.Navigation("TenThongSos");
                });

            modelBuilder.Entity("webbanlaptop.Models.ThongTinSanPham", b =>
                {
                    b.HasOne("webbanlaptop.Models.SanPham", "SanPhams")
                        .WithMany()
                        .HasForeignKey("SanPhamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webbanlaptop.Models.ThongTin", "ThongTins")
                        .WithMany()
                        .HasForeignKey("ThongTinID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SanPhams");

                    b.Navigation("ThongTins");
                });

            modelBuilder.Entity("webbanlaptop.Models.DonDatHang", b =>
                {
                    b.Navigation("ChiTietDatHangs");
                });

            modelBuilder.Entity("webbanlaptop.Models.NhapHang", b =>
                {
                    b.Navigation("ChiTietNhapHangs");
                });
#pragma warning restore 612, 618
        }
    }
}
