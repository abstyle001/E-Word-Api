using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Word_Api.Migrations
{
    /// <inheritdoc />
    public partial class userbook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "UserBooks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBooks", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "393d1bac-94ae-4348-ab00-5516a84b7905", null, "User", "USER" },
                    { "881a13d2-e4f1-4daf-a6a9-4f9b089f1bd8", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "96a7ccc3-646b-457e-b3d1-c2a75f1e8983", 0, null, "北京市", "3d9f2b74-f99f-4ab6-97cd-c422aaa0c06e", new DateTime(2026, 7, 4, 6, 33, 28, 623, DateTimeKind.Utc).AddTicks(2909), "admin@eword.com", false, true, null, "Admin", "ADMIN@EWORD.COM", "ADMIN@EWORD.COM", "AQAAAAIAAYagAAAAEB+ck0DF9HuLDVmtVs64MDPeDjVbEykfaCgEuGQMbMee/5Wy8OuGAYBWUgFrZiynfQ==", "17323895436", false, "237d93aa-34d4-4e36-afe4-bc0766181ba2", false, "admin@eword.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "881a13d2-e4f1-4daf-a6a9-4f9b089f1bd8", "96a7ccc3-646b-457e-b3d1-c2a75f1e8983" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBooks");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "393d1bac-94ae-4348-ab00-5516a84b7905");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "881a13d2-e4f1-4daf-a6a9-4f9b089f1bd8", "96a7ccc3-646b-457e-b3d1-c2a75f1e8983" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "881a13d2-e4f1-4daf-a6a9-4f9b089f1bd8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "96a7ccc3-646b-457e-b3d1-c2a75f1e8983");

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
    }
}
