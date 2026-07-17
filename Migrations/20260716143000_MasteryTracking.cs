using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814

namespace E_Word_Api.Migrations
{
    public partial class MasteryTracking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "6e91d299-467a-4ccb-872a-8e1bf298a69b", "829846ff-0e26-4b58-a86b-6353555d6307" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6e91d299-467a-4ccb-872a-8e1bf298a69b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b94644b7-02a2-4f60-991b-37c1a460a7df");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "829846ff-0e26-4b58-a86b-6353555d6307");

            migrationBuilder.AddColumn<int>(
                name: "CorrectStreak",
                table: "UserSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAttempts",
                table: "UserSessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Attempts",
                table: "UserWords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "MasteredAt",
                table: "UserWords",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c2f3a4b5-6d7e-8f90-a1b2-c3d4e5f60708", null, "Admin", "ADMIN" },
                    { "d3e4f5a6-b7c8-9d0e-f1a2-b3c4d5e6f708", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e4f5a6b7-c8d9-0e1f-a2b3-c4d5e6f70809", 0, null, "北京市", "f1a2b3c4-d5e6-7890-abcd-ef0123456789", new DateTime(2026, 7, 16, 14, 30, 0, 0, DateTimeKind.Utc), "admin@eword.com", false, true, null, "Admin", "ADMIN@EWORD.COM", "ADMIN@EWORD.COM", "AQAAAAIAAYagAAAAEAFhZUlYfANGojITF8q8MC8JzeaKmfauORFv1x/yjwck8qluY0IFRC9qSGxa6YYz3Q==", "17323895436", false, "a1b2c3d4-e5f6-7890-abcd-ef0123456789", false, "admin@eword.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c2f3a4b5-6d7e-8f90-a1b2-c3d4e5f60708", "e4f5a6b7-c8d9-0e1f-a2b3-c4d5e6f70809" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c2f3a4b5-6d7e-8f90-a1b2-c3d4e5f60708", "e4f5a6b7-c8d9-0e1f-a2b3-c4d5e6f70809" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2f3a4b5-6d7e-8f90-a1b2-c3d4e5f60708");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3e4f5a6-b7c8-9d0e-f1a2-b3c4d5e6f708");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4f5a6b7-c8d9-0e1f-a2b3-c4d5e6f70809");

            migrationBuilder.DropColumn(
                name: "CorrectStreak",
                table: "UserSessions");

            migrationBuilder.DropColumn(
                name: "TotalAttempts",
                table: "UserSessions");

            migrationBuilder.DropColumn(
                name: "Attempts",
                table: "UserWords");

            migrationBuilder.DropColumn(
                name: "MasteredAt",
                table: "UserWords");

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
    }
}
