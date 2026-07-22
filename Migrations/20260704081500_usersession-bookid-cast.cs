using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Word_Api.Migrations
{
    /// <inheritdoc />
    public partial class usersessionbookidcast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<long>(
                name: "BookId",
                table: "UserSessions",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6e91d299-467a-4ccb-872a-8e1bf298a69b", null, "Admin", "ADMIN" },
                    { "b94644b7-02a2-4f60-991b-37c1a460a7df", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "829846ff-0e26-4b58-a86b-6353555d6307", 0, null, "北京市", "9a957f98-b98a-4152-9adc-0b4ea41e9667", new DateTime(2026, 7, 4, 8, 15, 0, 625, DateTimeKind.Utc).AddTicks(4916), "admin@eword.com", false, true, null, "Admin", "ADMIN@EWORD.COM", "ADMIN@EWORD.COM", "AQAAAAIAAYagAAAAEAFhZUlYfANGojITF8q8MC8JzeaKmfauORFv1x/yjwck8qluY0IFRC9qSGxa6YYz3Q==", "17323895436", false, "6de06a0e-744d-49fa-ba10-75b8799bd779", false, "admin@eword.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "6e91d299-467a-4ccb-872a-8e1bf298a69b", "829846ff-0e26-4b58-a86b-6353555d6307" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b94644b7-02a2-4f60-991b-37c1a460a7df");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6e91d299-467a-4ccb-872a-8e1bf298a69b", "829846ff-0e26-4b58-a86b-6353555d6307" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e91d299-467a-4ccb-872a-8e1bf298a69b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "829846ff-0e26-4b58-a86b-6353555d6307");

            migrationBuilder.AlterColumn<string>(
                name: "BookId",
                table: "UserSessions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

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
    }
}
