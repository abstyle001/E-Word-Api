using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace E_Word_Api.Migrations
{
    /// <inheritdoc />
    public partial class AddReviewTrackingToUserWord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d3e4f5a6-b7c8-9d0e-f1a2-b3c4d5e6f708");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c2f3a4b5-6d7e-8f90-a1b2-c3d4e5f60708", "e4f5a6b7-c8d9-0e1f-a2b3-c4d5e6f70809" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c2f3a4b5-6d7e-8f90-a1b2-c3d4e5f60708");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e4f5a6b7-c8d9-0e1f-a2b3-c4d5e6f70809");

            // Note: Progresses.CorrectStreak and Progresses.TotalAttempts appear in the
            // model snapshot but do not exist in actual databases. Skip DROP COLUMN for them.

            migrationBuilder.AddColumn<int>(
                name: "IntervalDays",
                table: "UserWords",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastReviewedAt",
                table: "UserWords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextReviewAt",
                table: "UserWords",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepetitionCount",
                table: "UserWords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            // Migrate legacy data: schedule existing mastered words for review (1 day after mastery)
            migrationBuilder.Sql(
                "UPDATE UserWords SET IntervalDays = 1, RepetitionCount = 0, NextReviewAt = DATEADD(day, 1, MasteredAt) WHERE NextReviewAt IS NULL");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IntervalDays",
                table: "UserWords");

            migrationBuilder.DropColumn(
                name: "LastReviewedAt",
                table: "UserWords");

            migrationBuilder.DropColumn(
                name: "NextReviewAt",
                table: "UserWords");

            migrationBuilder.DropColumn(
                name: "RepetitionCount",
                table: "UserWords");

            migrationBuilder.AddColumn<int>(
                name: "CorrectStreak",
                table: "Progresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalAttempts",
                table: "Progresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
