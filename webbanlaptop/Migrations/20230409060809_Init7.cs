using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webbanlaptop.Migrations
{
    public partial class Init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "TongTien",
            table: "NhapHang",
            type: "int",
            nullable: false,
            defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
