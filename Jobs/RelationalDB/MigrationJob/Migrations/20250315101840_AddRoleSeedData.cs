using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobs.RelationalDB.MigrationJob.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AppRoles",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "IsSystemRole", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3312), null, false, true, "Admin", new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3314) },
                    { new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3318), null, false, true, "Employer", new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3318) }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Permission", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("22203303-d215-4fcc-a3b3-31a0fb5100dc"), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3421), null, false, "ManageUsers", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3421) },
                    { new Guid("59516863-e37c-4b72-a6ce-11e464bce34a"), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3426), null, false, "PostJobs", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3426) },
                    { new Guid("c89d6edd-5668-4c34-8b44-875c352d4be1"), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3431), null, false, "ViewWorkers", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3431) },
                    { new Guid("ed48574a-7d01-41fe-844b-2bc0fa4413e7"), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3423), null, false, "ManageRoles", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3424) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("22203303-d215-4fcc-a3b3-31a0fb5100dc"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("59516863-e37c-4b72-a6ce-11e464bce34a"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("c89d6edd-5668-4c34-8b44-875c352d4be1"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("ed48574a-7d01-41fe-844b-2bc0fa4413e7"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"));

            migrationBuilder.DeleteData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"));
        }
    }
}
