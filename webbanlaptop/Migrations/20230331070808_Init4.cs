using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webbanlaptop.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GiamGia",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ThanhTien",
                table: "SanPham",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GiamGia",
                table: "SanPham");

            migrationBuilder.DropColumn(
                name: "ThanhTien",
                table: "SanPham");
        }
    }
}
