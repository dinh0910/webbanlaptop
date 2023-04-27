using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webbanlaptop.Migrations
{
    public partial class Init11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoiDung",
                table: "ThongSo",
                newName: "NoiDungTS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoiDungTS",
                table: "ThongSo",
                newName: "NoiDung");
        }
    }
}
