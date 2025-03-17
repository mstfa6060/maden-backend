using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobs.RelationalDB.MigrationJob.Migrations
{
    /// <inheritdoc />
    public partial class UsersTableFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "UserSource",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Module",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    ModuleType = table.Column<int>(type: "int", nullable: false),
                    ModuleCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Module", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppResources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Namespace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsSystemAdminPermitted = table.Column<bool>(type: "bit", nullable: false),
                    IsEndUserPermitted = table.Column<bool>(type: "bit", nullable: false),
                    IsEveryoneAllowed = table.Column<bool>(type: "bit", nullable: false),
                    ModuleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsCompanyAdminPermitted = table.Column<bool>(type: "bit", nullable: false),
                    IsModuleAdminPermitted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppResources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppResources_Module_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Module",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(3984), new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(3986) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(3990), new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(3990) });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Permission", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("0a07b0c5-6920-4fe6-8c86-d030abecf8e5"), new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(4115), null, false, "ViewWorkers", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(4115) },
                    { new Guid("6b926475-9ff3-49d1-be4c-dbfb07b14781"), new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(4112), null, false, "PostJobs", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(4112) },
                    { new Guid("ceffa3b6-cd88-4bf1-8073-f40cb82faaf4"), new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(4097), null, false, "ManageUsers", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(4097) },
                    { new Guid("eca94a68-6f52-42f7-9e11-8c22b4d1328e"), new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(4109), null, false, "ManageRoles", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 3, 17, 20, 15, 22, 505, DateTimeKind.Utc).AddTicks(4110) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppResources_ModuleId",
                table: "AppResources",
                column: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppResources");

            migrationBuilder.DropTable(
                name: "Module");

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("0a07b0c5-6920-4fe6-8c86-d030abecf8e5"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("6b926475-9ff3-49d1-be4c-dbfb07b14781"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("ceffa3b6-cd88-4bf1-8073-f40cb82faaf4"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("eca94a68-6f52-42f7-9e11-8c22b4d1328e"));

            migrationBuilder.DropColumn(
                name: "UserSource",
                table: "AppUsers");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3312), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3314) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3318), new DateTime(2025, 3, 15, 10, 18, 40, 640, DateTimeKind.Utc).AddTicks(3318) });

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
    }
}
