using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Word_Api.Migrations
{
    /// <inheritdoc />
    public partial class UserStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c075412-e2c8-4e5f-ba24-e895f5f23588");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "98057eff-318c-4137-b05c-ad7c58dd9738", "2334e12d-57f6-4ed6-9899-1d5facd1c00c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98057eff-318c-4137-b05c-ad7c58dd9738");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2334e12d-57f6-4ed6-9899-1d5facd1c00c");

            migrationBuilder.CreateTable(
                name: "UserStats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TotalAnswered = table.Column<int>(type: "int", nullable: false),
                    CorrectCount = table.Column<int>(type: "int", nullable: false),
                    WordsMastered = table.Column<int>(type: "int", nullable: false),
                    LastSessionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "8c075412-e2c8-4e5f-ba24-e895f5f23588", null, "User", "USER" },
                    { "98057eff-318c-4137-b05c-ad7c58dd9738", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2334e12d-57f6-4ed6-9899-1d5facd1c00c", 0, null, "北京市", "472fa3b0-132c-423f-990c-b39c92822831", new DateTime(2026, 7, 17, 3, 56, 30, 652, DateTimeKind.Utc).AddTicks(4327), "admin@eword.com", false, true, null, "Admin", "ADMIN@EWORD.COM", "ADMIN@EWORD.COM", "AQAAAAIAAYagAAAAEIAw1X6tNXtQS2BUPAyjy0jlP9DrN6M/7zwefL52SmcTdvkAbAYJTaPBjOvbfKO1OQ==", "17323895436", false, "e80d405f-ba25-4a65-b005-9ce14747acce", false, "admin@eword.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "98057eff-318c-4137-b05c-ad7c58dd9738", "2334e12d-57f6-4ed6-9899-1d5facd1c00c" });
        }
    }
}
