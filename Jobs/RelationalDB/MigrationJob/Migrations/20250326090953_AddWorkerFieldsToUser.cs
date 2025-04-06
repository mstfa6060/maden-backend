using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobs.RelationalDB.MigrationJob.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkerFieldsToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("0303bda1-176c-40d2-bee5-bc30bd244efa"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("4b2a3c91-aeb7-4665-8154-8bbe4227792d"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("8c9beb6e-8580-429d-a326-aede5a63f7bb"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("b320166d-d769-4902-ad2d-66f00d53bff0"));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "AppUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "District",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "AppUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "District",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1191), new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1194) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1211), new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1212) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Permission", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0303bda1-176c-40d2-bee5-bc30bd244efa"), new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1385), null, false, "ManageRoles", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1385) },
                    { new Guid("4b2a3c91-aeb7-4665-8154-8bbe4227792d"), new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1429), null, false, "ViewWorkers", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1429) },
                    { new Guid("8c9beb6e-8580-429d-a326-aede5a63f7bb"), new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1381), null, false, "ManageUsers", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1381) },
                    { new Guid("b320166d-d769-4902-ad2d-66f00d53bff0"), new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1421), null, false, "PostJobs", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 18, 18, 34, 18, 566, DateTimeKind.Utc).AddTicks(1421) }
                });
        }
    }
}
