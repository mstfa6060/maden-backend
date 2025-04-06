using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobs.RelationalDB.MigrationJob.Migrations
{
    /// <inheritdoc />
    public partial class AddedPhoneNumberToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0e9603c4-a538-47f4-8032-27e091b57118"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("a672a427-b6dc-4a5c-a7e6-e0b276dadc3d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("aa20d6ca-3141-423e-bb2e-fba86d43e5ff"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("ab1ef7a5-4578-4475-8ba9-75d6c1c9af7c"));

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2829), new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2831) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2835), new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2835) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Permission", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("22a87691-e721-409a-945a-505ed1a07c08"), new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2978), null, false, "ManageUsers", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2978) },
                    { new Guid("b11e82df-eb36-4346-a902-8d6f072b7b1f"), new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2991), null, false, "PostJobs", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2991) },
                    { new Guid("e9df98de-7619-4de5-b898-a3407162d115"), new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2987), null, false, "ManageRoles", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2988) },
                    { new Guid("fa3c4397-9f97-45be-aa24-ec000bf5990f"), new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2994), null, false, "ViewWorkers", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 26, 9, 26, 11, 101, DateTimeKind.Utc).AddTicks(2994) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("22a87691-e721-409a-945a-505ed1a07c08"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b11e82df-eb36-4346-a902-8d6f072b7b1f"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("e9df98de-7619-4de5-b898-a3407162d115"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("fa3c4397-9f97-45be-aa24-ec000bf5990f"));

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7120) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7124), new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7125) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Permission", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0e9603c4-a538-47f4-8032-27e091b57118"), new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7281), null, false, "PostJobs", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7281) },
                    { new Guid("a672a427-b6dc-4a5c-a7e6-e0b276dadc3d"), new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7263), null, false, "ManageUsers", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7263) },
                    { new Guid("aa20d6ca-3141-423e-bb2e-fba86d43e5ff"), new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7284), null, false, "ViewWorkers", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7285) },
                    { new Guid("ab1ef7a5-4578-4475-8ba9-75d6c1c9af7c"), new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7266), null, false, "ManageRoles", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 26, 9, 9, 52, 846, DateTimeKind.Utc).AddTicks(7267) }
                });
        }
    }
}
