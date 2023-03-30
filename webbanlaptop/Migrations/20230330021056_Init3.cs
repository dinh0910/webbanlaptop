using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webbanlaptop.Migrations
{
    public partial class Init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mau_SanPham_SanPhamID",
                table: "Mau");

            migrationBuilder.DropIndex(
                name: "IX_Mau_SanPhamID",
                table: "Mau");

            migrationBuilder.DropColumn(
                name: "SanPhamID",
                table: "Mau");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
