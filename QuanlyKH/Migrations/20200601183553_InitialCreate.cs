using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanlyKH.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MsKH = table.Column<string>(maxLength: 50, nullable: false),
                    TenKH = table.Column<string>(maxLength: 255, nullable: false),
                    Nodau = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MsKH);
                });

            migrationBuilder.CreateTable(
                name: "PhieuThu",
                columns: table => new
                {
                    MsPT = table.Column<string>(maxLength: 50, nullable: false),
                    NgayThu = table.Column<DateTime>(nullable: false),
                    SoTien = table.Column<double>(nullable: false),
                    KhachhangMsKH = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuThu", x => x.MsPT);
                    table.ForeignKey(
                        name: "FK_PhieuThu_KhachHang_KhachhangMsKH",
                        column: x => x.KhachhangMsKH,
                        principalTable: "KhachHang",
                        principalColumn: "MsKH",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhieuThu_KhachhangMsKH",
                table: "PhieuThu",
                column: "KhachhangMsKH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhieuThu");

            migrationBuilder.DropTable(
                name: "KhachHang");
        }
    }
}
