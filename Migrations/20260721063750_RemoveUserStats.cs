using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Word_Api.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUserStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserStats");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "65e5df1d-1f67-46d6-ab0a-1872f7efde07");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "58087e6b-b08f-4fb6-9416-5ed7592ba482", "7d414ef2-95d8-42bf-acc9-e056c590c346" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58087e6b-b08f-4fb6-9416-5ed7592ba482");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d414ef2-95d8-42bf-acc9-e056c590c346");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0092394e-e5ee-4ffd-9531-9fa7dab41200", null, "User", "USER" },
                    { "c763cfd4-15a2-4678-aa11-b15e43d300b6", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dc364c76-e828-4be8-9146-25bb60ea5fce", 0, null, "北京市", "86d3c4d8-399e-4844-b5f7-fc83d394faa8", new DateTime(2026, 7, 21, 6, 37, 49, 677, DateTimeKind.Utc).AddTicks(4980), "admin@eword.com", false, true, null, "Admin", "ADMIN@EWORD.COM", "ADMIN@EWORD.COM", "AQAAAAIAAYagAAAAEMio6sC/yTnj5Lwe269Sil5werED9EsLf3U2BJ2kwbxSojwXFWTHXC9Y7FoXFCu+6A==", "17323895436", false, "7c52c7f7-7f89-4810-8b39-f238acf0125d", false, "admin@eword.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c763cfd4-15a2-4678-aa11-b15e43d300b6", "dc364c76-e828-4be8-9146-25bb60ea5fce" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0092394e-e5ee-4ffd-9531-9fa7dab41200");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c763cfd4-15a2-4678-aa11-b15e43d300b6", "dc364c76-e828-4be8-9146-25bb60ea5fce" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c763cfd4-15a2-4678-aa11-b15e43d300b6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dc364c76-e828-4be8-9146-25bb60ea5fce");

            migrationBuilder.CreateTable(
                name: "UserStats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CorrectCount = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastSessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAnswered = table.Column<int>(type: "int", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    WordsMastered = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStats", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "58087e6b-b08f-4fb6-9416-5ed7592ba482", null, "Admin", "ADMIN" },
                    { "65e5df1d-1f67-46d6-ab0a-1872f7efde07", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d414ef2-95d8-42bf-acc9-e056c590c346", 0, null, "北京市", "3a922393-6d8d-4347-b0df-b6743a8f3b9d", new DateTime(2026, 7, 21, 6, 11, 24, 796, DateTimeKind.Utc).AddTicks(2877), "admin@eword.com", false, true, null, "Admin", "ADMIN@EWORD.COM", "ADMIN@EWORD.COM", "AQAAAAIAAYagAAAAEC4vIAtVo8gbS0GlAvvxCnEgMf7uVMGIUVhWJ5ADXKTrL4TXIE7r0YFhLSc4Vt6HTw==", "17323895436", false, "c63b32e2-2b9e-4fc1-bab0-f78c82dbe642", false, "admin@eword.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "58087e6b-b08f-4fb6-9416-5ed7592ba482", "7d414ef2-95d8-42bf-acc9-e056c590c346" });

            migrationBuilder.CreateIndex(
                name: "IX_UserStats_UserId",
                table: "UserStats",
                column: "UserId",
                unique: true);
        }
    }
}
