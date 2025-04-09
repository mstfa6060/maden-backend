using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Jobs.RelationalDB.MigrationJob.Migrations
{
    /// <inheritdoc />
    public partial class AddJobAndJobApplicationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRelSystemUserModules_AppSystemAdmins_SystemAdminId",
                table: "AppRelSystemUserModules");

            migrationBuilder.DropForeignKey(
                name: "FK_AppRelSystemUserModules_Module_ModuleId",
                table: "AppRelSystemUserModules");

            migrationBuilder.DropForeignKey(
                name: "FK_AppResources_Module_ModuleId",
                table: "AppResources");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_AppRoles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AppRoles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AppUsers_UserId",
                table: "UserRoles");

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

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    EmployerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_AppUsers_EmployerId",
                        column: x => x.EmployerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AppliedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_AppUsers_WorkerId",
                        column: x => x.WorkerId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplications_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3135), new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3138) });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"),
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3144), new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3144) });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "IsDeleted", "Permission", "RoleId", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("58e67985-0368-49e7-81d0-6a2d008104ab"), new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3323), null, false, "ManageRoles", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3324) },
                    { new Guid("823e663b-c3b5-4706-aa9c-48de6034dbd5"), new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3329), null, false, "ViewWorkers", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3330) },
                    { new Guid("c2ab1a28-9027-415c-a96e-397359568926"), new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3321), null, false, "ManageUsers", new Guid("a1d5b3e4-8e5a-4b3c-9ef5-d3e5a3b7c1f8"), new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3321) },
                    { new Guid("f38ba4f1-c16e-4d26-ac9e-a9a71fdb61d4"), new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3326), null, false, "PostJobs", new Guid("b3f8a7d1-4e2c-4a3e-8b5a-d3e7b9c5e2f1"), new DateTime(2025, 4, 9, 17, 9, 0, 331, DateTimeKind.Utc).AddTicks(3327) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_JobId",
                table: "JobApplications",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_WorkerId",
                table: "JobApplications",
                column: "WorkerId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_EmployerId",
                table: "Jobs",
                column: "EmployerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AppRelSystemUserModules_AppSystemAdmins_SystemAdminId",
                table: "AppRelSystemUserModules",
                column: "SystemAdminId",
                principalTable: "AppSystemAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppRelSystemUserModules_Module_ModuleId",
                table: "AppRelSystemUserModules",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppResources_Module_ModuleId",
                table: "AppResources",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_AppRoles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AppRoles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AppUsers_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppRelSystemUserModules_AppSystemAdmins_SystemAdminId",
                table: "AppRelSystemUserModules");

            migrationBuilder.DropForeignKey(
                name: "FK_AppRelSystemUserModules_Module_ModuleId",
                table: "AppRelSystemUserModules");

            migrationBuilder.DropForeignKey(
                name: "FK_AppResources_Module_ModuleId",
                table: "AppResources");

            migrationBuilder.DropForeignKey(
                name: "FK_RolePermissions_AppRoles_RoleId",
                table: "RolePermissions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AppRoles_RoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_AppUsers_UserId",
                table: "UserRoles");

            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("58e67985-0368-49e7-81d0-6a2d008104ab"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("823e663b-c3b5-4706-aa9c-48de6034dbd5"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("c2ab1a28-9027-415c-a96e-397359568926"));

            migrationBuilder.DeleteData(
                table: "RolePermissions",
                keyColumn: "Id",
                keyValue: new Guid("f38ba4f1-c16e-4d26-ac9e-a9a71fdb61d4"));

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

            migrationBuilder.AddForeignKey(
                name: "FK_AppRelSystemUserModules_AppSystemAdmins_SystemAdminId",
                table: "AppRelSystemUserModules",
                column: "SystemAdminId",
                principalTable: "AppSystemAdmins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppRelSystemUserModules_Module_ModuleId",
                table: "AppRelSystemUserModules",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AppResources_Module_ModuleId",
                table: "AppResources",
                column: "ModuleId",
                principalTable: "Module",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RolePermissions_AppRoles_RoleId",
                table: "RolePermissions",
                column: "RoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AppRoles_RoleId",
                table: "UserRoles",
                column: "RoleId",
                principalTable: "AppRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoles_AppUsers_UserId",
                table: "UserRoles",
                column: "UserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
