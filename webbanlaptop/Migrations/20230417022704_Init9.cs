using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webbanlaptop.Migrations
{
    public partial class Init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DacTrung",
                table: "SanPham",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DacTrung",
                table: "SanPham");
        }
    }
}
