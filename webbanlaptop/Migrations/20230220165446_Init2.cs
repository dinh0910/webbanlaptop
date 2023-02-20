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
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.KhuyenMaiID);
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
                    NoiDung = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTin", x => x.ThongTinID);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMaiSanPham",
                columns: table => new
                {
                    KhuyenMaiSanPhamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KhuyenMaiID = table.Column<int>(type: "int", nullable: false),
                    SanPhamID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMaiSanPham", x => x.KhuyenMaiSanPhamID);
                    table.ForeignKey(
                        name: "FK_KhuyenMaiSanPham_KhuyenMai_KhuyenMaiID",
                        column: x => x.KhuyenMaiID,
                        principalTable: "KhuyenMai",
                        principalColumn: "KhuyenMaiID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KhuyenMaiSanPham_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ThongTinSanPham",
                columns: table => new
                {
                    ThongTinSanPhamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SanPhamID = table.Column<int>(type: "int", nullable: false),
                    ThongTinID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThongTinSanPham", x => x.ThongTinSanPhamID);
                    table.ForeignKey(
                        name: "FK_ThongTinSanPham_SanPham_SanPhamID",
                        column: x => x.SanPhamID,
                        principalTable: "SanPham",
                        principalColumn: "SanPhamID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThongTinSanPham_ThongTin_ThongTinID",
                        column: x => x.ThongTinID,
                        principalTable: "ThongTin",
                        principalColumn: "ThongTinID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiSanPham_KhuyenMaiID",
                table: "KhuyenMaiSanPham",
                column: "KhuyenMaiID");

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiSanPham_SanPhamID",
                table: "KhuyenMaiSanPham",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_Mau_SanPhamID",
                table: "Mau",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinSanPham_SanPhamID",
                table: "ThongTinSanPham",
                column: "SanPhamID");

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinSanPham_ThongTinID",
                table: "ThongTinSanPham",
                column: "ThongTinID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KhuyenMaiSanPham");

            migrationBuilder.DropTable(
                name: "Mau");

            migrationBuilder.DropTable(
                name: "ThongTinSanPham");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "ThongTin");
        }
    }
}
