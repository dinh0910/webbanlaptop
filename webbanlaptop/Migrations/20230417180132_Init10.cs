using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webbanlaptop.Migrations
{
    public partial class Init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CanNang",
                table: "ThongSo");

            migrationBuilder.DropColumn(
                name: "CongGiaoTiep",
                table: "ThongSo");

            migrationBuilder.DropColumn(
                name: "CongNgheManHinh",
                table: "ThongSo");

            migrationBuilder.DropColumn(
                name: "DoPhanGiai",
                table: "ThongSo");

            migrationBuilder.DropColumn(
                name: "HeDieuHanh",
                table: "ThongSo");

            migrationBuilder.DropColumn(
                name: "KichThuocManHinh",
                table: "ThongSo");

            migrationBuilder.DropColumn(
                name: "LoaiCard",
                table: "ThongSo");

            migrationBuilder.DropColumn(
                name: "LoaiRam",
                table: "ThongSo");

            migrationBuilder.DropColumn(
                name: "OCung",
                table: "ThongSo");

            migrationBuilder.DropColumn(
                name: "Pin",
                table: "ThongSo");

            migrationBuilder.DropColumn(
                name: "Ram",
                table: "ThongSo");

            migrationBuilder.RenameColumn(
                name: "BaoHanhPin",
                table: "ThongTin",
                newName: "ChinhSach");

            migrationBuilder.RenameColumn(
                name: "TinhNangKhac",
                table: "ThongSo",
                newName: "TenThongSo");

            migrationBuilder.RenameColumn(
                name: "SoKheRam",
                table: "ThongSo",
                newName: "NoiDung");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChinhSach",
                table: "ThongTin",
                newName: "BaoHanhPin");

            migrationBuilder.RenameColumn(
                name: "TenThongSo",
                table: "ThongSo",
                newName: "TinhNangKhac");

            migrationBuilder.RenameColumn(
                name: "NoiDung",
                table: "ThongSo",
                newName: "SoKheRam");

            migrationBuilder.AddColumn<string>(
                name: "CanNang",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CongGiaoTiep",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CongNgheManHinh",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DoPhanGiai",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HeDieuHanh",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KichThuocManHinh",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiCard",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LoaiRam",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OCung",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pin",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ram",
                table: "ThongSo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
