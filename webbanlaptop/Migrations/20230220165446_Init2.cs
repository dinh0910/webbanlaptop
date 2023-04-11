using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webbanlaptop.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    KhuyenMaiID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.KhuyenMaiID);
                    table.ForeignKey(
                        name: "FK_KhuyenMai_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mau",
                columns: table => new
                {
                    MauID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mau", x => x.MauID);
                    table.ForeignKey(
                        name: "FK_Mau_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTin",
                columns: table => new
                {
                    ThongTinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamID = table.Column<int>(type: "int", nullable: true),
                    TrongHop = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoHanhPin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaoHanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTin", x => x.ThongTinID);
                    table.ForeignKey(
                        name: "FK_ThongTin_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMai_SanPhamID",
                table: "KhuyenMai",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_Mau_SanPhamID",
                table: "Mau",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTin_SanPhamID",
                table: "ThongTin",
                column: "SanPhamID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mau");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "ThongTin");
        }
    }
}
