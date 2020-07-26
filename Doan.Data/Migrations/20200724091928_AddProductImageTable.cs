using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doan.Data.Migrations
{
    public partial class AddProductImageTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(maxLength: 300, nullable: false),
                    Caption = table.Column<string>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: "001",
                column: "ConcurrencyStamp",
                value: "a93188ae-3b0b-48fa-9c9a-c140259570f9");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: "002",
                column: "ConcurrencyStamp",
                value: "d020e918-5fe6-4e3e-98a5-c880c89d920f");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "0001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5454c5f0-3f3c-4e22-aa53-41bcad47b48e", "AQAAAAEAACcQAAAAEIqXE7x6N3h2RqVXwL/GqXPjq5ptfVSBmAUgIdxAphFu9PaOzyXEpZ6N02yLo+le2Q==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "K001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3d55c408-71ef-439d-973d-b27da61d2476", "AQAAAAEAACcQAAAAEBl/tiRkUntB0IMHPLepMc5KYZS6xCObj962kIOo7237bDrESt+hX3kkFh4zjYio5g==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "NC01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "362fdc02-097b-4b9c-9de3-f9c9527ddd35", "AQAAAAEAACcQAAAAECFcFjs9BpRbkjrXsmLeMFjUVHrtDfPCSYyI95vui1KQQ36WjoCj3DvfwUVnT3Tldw==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: "T001",
                column: "BillDate",
                value: new DateTime(2020, 7, 24, 16, 19, 27, 934, DateTimeKind.Local).AddTicks(4171));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateContract", "Discount" },
                values: new object[] { new DateTime(2020, 7, 24, 16, 19, 27, 932, DateTimeKind.Local).AddTicks(7584), 10m });

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: "N001",
                column: "DateAdd",
                value: new DateTime(2020, 7, 24, 16, 19, 27, 935, DateTimeKind.Local).AddTicks(1085));

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: "001",
                column: "ConcurrencyStamp",
                value: "dbe9ac60-3819-4da7-be57-6f2e3c74b903");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: "002",
                column: "ConcurrencyStamp",
                value: "96229159-489f-44e3-992e-ec65849d4827");

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "0001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b5dbc8fc-3572-4047-a273-7f4d47e2a81e", "AQAAAAEAACcQAAAAEEi0yD2+kd9cSw+goKcOiolOw5uDwK/FfqanqkC4P83qZOapxx2K+zsmoI5ZKO2QeA==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "K001",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "91dd88d0-9e22-48d3-9bcc-6e617e987046", "AQAAAAEAACcQAAAAEPkTpWx18n019XI1EyFXduvJ6pDLxt+frxRCg0pFYn3lTH5Lc8cN4cA7SEZ2iairow==" });

            migrationBuilder.UpdateData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "NC01",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6d986d33-a467-4652-9a17-1f79eee87af2", "AQAAAAEAACcQAAAAEOJgeYW+vkIYnnpBt9sdvQXI8pa5sdaBLqW9ZIY2hdgJKRaJ1V6wxss7huj77+1+QQ==" });

            migrationBuilder.UpdateData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: "T001",
                column: "BillDate",
                value: new DateTime(2020, 7, 24, 11, 21, 35, 683, DateTimeKind.Local).AddTicks(7942));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateContract", "Discount" },
                values: new object[] { new DateTime(2020, 7, 24, 11, 21, 35, 682, DateTimeKind.Local).AddTicks(793), 10m });

            migrationBuilder.UpdateData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: "N001",
                column: "DateAdd",
                value: new DateTime(2020, 7, 24, 11, 21, 35, 684, DateTimeKind.Local).AddTicks(4875));
        }
    }
}
