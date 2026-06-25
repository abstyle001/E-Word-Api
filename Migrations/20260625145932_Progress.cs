using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Word_Api.Migrations
{
    /// <inheritdoc />
    public partial class Progress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa97a676-ff29-48dc-9c5f-6d8be12c97d2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "b821b8bf-0525-4d16-8cb6-f0e05d4af2bc", "60d4da50-0e62-4999-8714-758d3ac5e290" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b821b8bf-0525-4d16-8cb6-f0e05d4af2bc");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "60d4da50-0e62-4999-8714-758d3ac5e290");

            migrationBuilder.RenameColumn(
                name: "options",
                table: "Words",
                newName: "Options");

            migrationBuilder.CreateTable(
                name: "Progresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progresses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1ac966b5-0168-4567-803d-8a85cae29110", null, "Admin", "ADMIN" },
                    { "dc6e5ad3-bf94-4f6b-a83a-9a6bd85456ac", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9317879b-924d-45e9-a51f-34f219514892", 0, null, "北京市", "6e0905bc-ed03-4d46-be9f-349647b833ae", new DateTime(2026, 6, 25, 14, 59, 30, 773, DateTimeKind.Utc).AddTicks(1964), "admin@eword.com", false, true, null, "Admin", "ADMIN@EWORD.COM", "ADMIN@EWORD.COM", "AQAAAAIAAYagAAAAEAJyR5/19CNG8745S/OrtPV/U/fupgfqQYqB50T7bz761KSfDtx7t+yLt3FmnEa9fg==", "17323895436", false, "a455ac67-63ec-49d3-b57e-87c3ca107fe1", false, "admin@eword.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1ac966b5-0168-4567-803d-8a85cae29110", "9317879b-924d-45e9-a51f-34f219514892" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CET6Books");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc6e5ad3-bf94-4f6b-a83a-9a6bd85456ac");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1ac966b5-0168-4567-803d-8a85cae29110", "9317879b-924d-45e9-a51f-34f219514892" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1ac966b5-0168-4567-803d-8a85cae29110");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9317879b-924d-45e9-a51f-34f219514892");

            migrationBuilder.RenameColumn(
                name: "Options",
                table: "Words",
                newName: "options");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b821b8bf-0525-4d16-8cb6-f0e05d4af2bc", null, "Admin", "ADMIN" },
                    { "fa97a676-ff29-48dc-9c5f-6d8be12c97d2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "60d4da50-0e62-4999-8714-758d3ac5e290", 0, null, "北京市", "851aad6f-93e9-44cc-814a-1c03d5c73619", new DateTime(2026, 5, 3, 6, 52, 29, 226, DateTimeKind.Utc).AddTicks(360), "admin@eword.com", false, true, null, "Admin", "ADMIN@EWORD.COM", "ADMIN@EWORD.COM", "AQAAAAIAAYagAAAAELJKXkUD5tHmfTNcRJ+F4w8PzVgoP8wL9O8Zyh/g/ZzpvzFPL2yItCvn21UKUmPq/g==", "17323895436", false, "3efa7b6a-a229-4bd8-87e8-0cb01fbdc7b6", false, "admin@eword.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "b821b8bf-0525-4d16-8cb6-f0e05d4af2bc", "60d4da50-0e62-4999-8714-758d3ac5e290" });
        }
    }
}
