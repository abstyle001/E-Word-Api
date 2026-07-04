using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Word_Api.Migrations
{
    /// <inheritdoc />
    public partial class usersession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "UserSessions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserWords",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WordId = table.Column<long>(type: "bigint", nullable: false),
                    OriginBook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWords", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cdb98577-77d8-4eaf-833e-453cc9785dda", null, "User", "USER" },
                    { "f6b37db8-db12-4f66-a0c4-5779c15db619", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d5a09e91-f719-4582-84d3-6226701947c8", 0, null, "北京市", "5a11b733-9d6a-460c-b574-ec5e4703fa9f", new DateTime(2026, 7, 4, 5, 29, 6, 203, DateTimeKind.Utc).AddTicks(6760), "admin@eword.com", false, true, null, "Admin", "ADMIN@EWORD.COM", "ADMIN@EWORD.COM", "AQAAAAIAAYagAAAAEHMvoyT6p+55Wvt/8HfmN++7HP83QLBZudyMWeaT/7CO9LqdHrQ/+9kiem96DnIbSg==", "17323895436", false, "a90ea4d8-2ffa-480e-a637-ea424f11ae1a", false, "admin@eword.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f6b37db8-db12-4f66-a0c4-5779c15db619", "d5a09e91-f719-4582-84d3-6226701947c8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserSessions");

            migrationBuilder.DropTable(
                name: "UserWords");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdb98577-77d8-4eaf-833e-453cc9785dda");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f6b37db8-db12-4f66-a0c4-5779c15db619", "d5a09e91-f719-4582-84d3-6226701947c8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6b37db8-db12-4f66-a0c4-5779c15db619");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d5a09e91-f719-4582-84d3-6226701947c8");

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
    }
}
