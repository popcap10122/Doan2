using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Doan.Data.Migrations
{
    public partial class Seed_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AppUsers",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AppUsers",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "001", "dbe9ac60-3819-4da7-be57-6f2e3c74b903", "Administrator for app", "admin", "admin" },
                    { "002", "96229159-489f-44e3-992e-ec65849d4827", "customer for app", "customer", "customer" }
                });

            migrationBuilder.InsertData(
                table: "AppUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "0001", "001" },
                    { "K001", "002" }
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Debtfirst", "DoB", "Email", "EmailConfirmed", "FirstName", "LastLogin", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NameContact", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0001", 0, null, "b5dbc8fc-3572-4047-a273-7f4d47e2a81e", 0m, new DateTime(2020, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "tieplk@gmail.com", true, "Tiep", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Le", false, null, null, null, "tieplk@gmail.com", "admin", "AQAAAAEAACcQAAAAEEi0yD2+kd9cSw+goKcOiolOw5uDwK/FfqanqkC4P83qZOapxx2K+zsmoI5ZKO2QeA==", null, false, "", false, "admin" },
                    { "K001", 0, null, "91dd88d0-9e22-48d3-9bcc-6e617e987046", 0m, new DateTime(2020, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "customer@gmail.com", true, "Nguyễn Văn", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Minh", false, null, null, null, "customer@gmail.com", "customer", "AQAAAAEAACcQAAAAEPkTpWx18n019XI1EyFXduvJ6pDLxt+frxRCg0pFYn3lTH5Lc8cN4cA7SEZ2iairow==", null, false, "", false, "customer" },
                    { "NC01", 0, "142 Tô Hiến Thành Hà Nội", "6d986d33-a467-4652-9a17-1f79eee87af2", 0m, new DateTime(2020, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "supplier@gmail.com", true, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Công ty Phân phối ABC", "Anh Hải", "supplier@gmail.com", "supplier", "AQAAAAEAACcQAAAAEOJgeYW+vkIYnnpBt9sdvQXI8pa5sdaBLqW9ZIY2hdgJKRaJ1V6wxss7huj77+1+QQ==", null, false, "", false, "supplier" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "AppUserId", "CustomerId", "DateContract", "Discount" },
                values: new object[] { 1, null, "K001", new DateTime(2020, 7, 24, 11, 21, 35, 682, DateTimeKind.Local).AddTicks(793), 10m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DateCreated", "Name", "Unit", "ViewCount" },
                values: new object[,]
                {
                    { "H001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bánh", "Hộp", 0 },
                    { "H002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kẹo", "Lốc", 0 }
                });

            migrationBuilder.InsertData(
                table: "Bills",
                columns: new[] { "Id", "BillDate", "CustomerId", "Price" },
                values: new object[] { "T001", new DateTime(2020, 7, 24, 11, 21, 35, 683, DateTimeKind.Local).AddTicks(7942), "K001", 1000m });

            migrationBuilder.InsertData(
                table: "ProductInvoices",
                columns: new[] { "ProductId", "InvoiceId", "Price", "Quantity" },
                values: new object[] { "H001", 1, 50, 10 });

            migrationBuilder.InsertData(
                table: "Receipts",
                columns: new[] { "Id", "DateAdd", "SupplierId" },
                values: new object[] { "N001", new DateTime(2020, 7, 24, 11, 21, 35, 684, DateTimeKind.Local).AddTicks(4875), "NC01" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: "001");

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: "002");

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0001", "001" });

            migrationBuilder.DeleteData(
                table: "AppUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "K001", "002" });

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "0001");

            migrationBuilder.DeleteData(
                table: "Bills",
                keyColumn: "Id",
                keyValue: "T001");

            migrationBuilder.DeleteData(
                table: "ProductInvoices",
                keyColumns: new[] { "ProductId", "InvoiceId" },
                keyValues: new object[] { "H001", 1 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "H002");

            migrationBuilder.DeleteData(
                table: "Receipts",
                keyColumn: "Id",
                keyValue: "N001");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "K001");

            migrationBuilder.DeleteData(
                table: "AppUsers",
                keyColumn: "Id",
                keyValue: "NC01");

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: "H001");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "AppUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "AppUsers",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
