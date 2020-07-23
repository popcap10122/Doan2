using Microsoft.EntityFrameworkCore.Migrations;

namespace QuanlyKH.Migrations
{
    public partial class _1300 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuThu_KhachHang_KhachhangMsKH",
                table: "PhieuThu");

            migrationBuilder.DropColumn(
                name: "Test",
                table: "KhachHang");

            migrationBuilder.AlterColumn<string>(
                name: "KhachhangMsKH",
                table: "PhieuThu",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuThu_KhachHang_KhachhangMsKH",
                table: "PhieuThu",
                column: "KhachhangMsKH",
                principalTable: "KhachHang",
                principalColumn: "MsKH",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhieuThu_KhachHang_KhachhangMsKH",
                table: "PhieuThu");

            migrationBuilder.AlterColumn<string>(
                name: "KhachhangMsKH",
                table: "PhieuThu",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Test",
                table: "KhachHang",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PhieuThu_KhachHang_KhachhangMsKH",
                table: "PhieuThu",
                column: "KhachhangMsKH",
                principalTable: "KhachHang",
                principalColumn: "MsKH",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
