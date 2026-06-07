using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Word_Api.Migrations
{
    /// <inheritdoc />
    public partial class WordInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12ba555e-662f-423f-b0ff-cce9355f0b8e");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "5a424ec2-ff58-4ad6-aaea-07fad508b3f5", "a0e9c5bd-5294-4945-9281-440f58bf8a6a" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a424ec2-ff58-4ad6-aaea-07fad508b3f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0e9c5bd-5294-4945-9281-440f58bf8a6a");

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    English = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chinese = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    options = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7322dd9c-1e86-46c1-a006-d3b832b2ddb8", null, "Admin", "ADMIN" },
                    { "e2566882-b466-41f5-84f7-7cadc65fd9e4", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "e89f1ca1-b582-4307-a709-142eaf357974", 0, null, "北京市", "3afdbaba-e47c-410c-a516-7fe45dbc7c96", new DateTime(2026, 5, 3, 6, 24, 12, 538, DateTimeKind.Utc).AddTicks(6956), "admin@eword.com", false, true, null, "Admin", "ADMIN@EWORD.COM", "ADMIN@EWORD.COM", "AQAAAAIAAYagAAAAEA30BqRLt1WhvQA0azCCVKBv3lXCRXQgWRn158ze/YqLW8IHefuPRk3lJnVCawqkfQ==", "17323895436", false, "bfb71af8-326b-4694-815f-8839271f00f6", false, "admin@eword.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7322dd9c-1e86-46c1-a006-d3b832b2ddb8", "e89f1ca1-b582-4307-a709-142eaf357974" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2566882-b466-41f5-84f7-7cadc65fd9e4");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7322dd9c-1e86-46c1-a006-d3b832b2ddb8", "e89f1ca1-b582-4307-a709-142eaf357974" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7322dd9c-1e86-46c1-a006-d3b832b2ddb8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e89f1ca1-b582-4307-a709-142eaf357974");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12ba555e-662f-423f-b0ff-cce9355f0b8e", null, "User", "USER" },
                    { "5a424ec2-ff58-4ad6-aaea-07fad508b3f5", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Avatar", "City", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NickName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a0e9c5bd-5294-4945-9281-440f58bf8a6a", 0, null, "北京市", "435bcc96-4cc5-476d-9ffd-d9d375c16fb2", new DateTime(2026, 4, 28, 16, 15, 57, 576, DateTimeKind.Utc).AddTicks(8911), "admin@cold.com", false, true, null, "Admin", "ADMIN@COLD.COM", "ADMIN@COLD.COM", "AQAAAAIAAYagAAAAEKtubeVIW0RTDyCr0AI33ESMUyrVp0BsMRd+ZwifbcmWYQ9iRsxFFUqjrw5FoGTHzQ==", "17323895436", false, "b24fc42a-96a4-4edc-9b53-56069f304eca", false, "admin@cold.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "5a424ec2-ff58-4ad6-aaea-07fad508b3f5", "a0e9c5bd-5294-4945-9281-440f58bf8a6a" });
        }
    }
}
