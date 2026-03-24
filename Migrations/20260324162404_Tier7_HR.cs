using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Tier7_HR : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeCode = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: false),
                    Salary = table.Column<decimal>(type: "TEXT", nullable: false),
                    HireDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    ApprovedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OvertimeHours = table.Column<double>(type: "REAL", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftSegments_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 24, 4, 138, DateTimeKind.Utc).AddTicks(6238));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 24, 4, 138, DateTimeKind.Utc).AddTicks(6619));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 54, 4, 138, DateTimeKind.Utc).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 13, 24, 4, 138, DateTimeKind.Utc).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 39, 4, 138, DateTimeKind.Utc).AddTicks(6657));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(2873), new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(2874) });

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(8445));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(7168), new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(7511) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(7918), new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(7919) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(7924), new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(7924) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(7926), new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(7927) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(7928), new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(7929) });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "Department", "EmployeeCode", "FirstName", "HireDate", "JobTitle", "LastName", "Salary", "Status", "UserId" },
                values: new object[] { 2, new DateTime(2026, 3, 24, 16, 24, 4, 142, DateTimeKind.Utc).AddTicks(1162), "Bakım", "EMP-002", "Mehmet", new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Teknisyen", "Demir", 38000m, 0, null });

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 54, 4, 141, DateTimeKind.Utc).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 54, 4, 141, DateTimeKind.Utc).AddTicks(2627));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 54, 4, 141, DateTimeKind.Utc).AddTicks(2630));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAt",
                value: new DateTime(2026, 3, 23, 19, 24, 4, 141, DateTimeKind.Local).AddTicks(8028));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAt",
                value: new DateTime(2026, 2, 22, 19, 24, 4, 141, DateTimeKind.Local).AddTicks(8609));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(8812));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(810));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(815));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(816));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(818));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(819));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(821));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(2579));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(6422));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(8015));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(8019));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(8039));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(8045));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(7633));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(9070), new DateTime(2026, 3, 24, 14, 24, 4, 138, DateTimeKind.Utc).AddTicks(9074) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(9295));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(9747));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 24, 4, 141, DateTimeKind.Utc).AddTicks(1024));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 24, 4, 141, DateTimeKind.Utc).AddTicks(1220));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 24, 4, 141, DateTimeKind.Utc).AddTicks(1222));

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(5981), new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(5982) });

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(7876), new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(7876) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(8799), new DateTime(2026, 3, 24, 16, 24, 4, 139, DateTimeKind.Utc).AddTicks(8799) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(286), new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(287) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(962), new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(963) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(2043), new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(2044) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(2046), new DateTime(2026, 3, 24, 16, 24, 4, 140, DateTimeKind.Utc).AddTicks(2046) });

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 12, 24, 4, 139, DateTimeKind.Utc).AddTicks(1467));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 24, 4, 139, DateTimeKind.Utc).AddTicks(1835));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 24, 4, 139, DateTimeKind.Utc).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 24, 4, 139, DateTimeKind.Utc).AddTicks(1841));

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 141, DateTimeKind.Utc).AddTicks(5033), new DateTime(2026, 3, 22, 19, 24, 4, 141, DateTimeKind.Local).AddTicks(5848) });

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 141, DateTimeKind.Utc).AddTicks(6562), new DateTime(2026, 3, 23, 19, 24, 4, 141, DateTimeKind.Local).AddTicks(6564) });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "FullName", "IsActive", "PasswordHash", "RoleId", "ShiftId", "Username" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(5088), "Sistem Yöneticisi", true, "admin", 1, null, "admin" },
                    { 2, new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(5312), "Fabrika Müdürü", true, "manager", 2, null, "manager" },
                    { 3, new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(5314), "Hattı Operatörü", true, "operator", 3, null, "operator" }
                });

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(1447));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(3768));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(4165));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 138, DateTimeKind.Utc).AddTicks(4168));

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CreatedAt", "Department", "EmployeeCode", "FirstName", "HireDate", "JobTitle", "LastName", "Salary", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 24, 16, 24, 4, 141, DateTimeKind.Utc).AddTicks(9240), "Üretim", "EMP-001", "Ahmet", new DateTime(2020, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hattı Şefi", "Yılmaz", 45000m, 0, 1 },
                    { 3, new DateTime(2026, 3, 24, 16, 24, 4, 142, DateTimeKind.Utc).AddTicks(1166), "Kalite", "EMP-003", "Ayşe", new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mühendis", "Kaya", 52000m, 0, 2 }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "ApprovedBy", "CreatedAt", "EmployeeId", "EndDate", "Reason", "StartDate", "Status", "Type" },
                values: new object[,]
                {
                    { 2, "Admin", new DateTime(2026, 3, 24, 16, 24, 4, 142, DateTimeKind.Utc).AddTicks(3111), 2, new DateTime(2026, 3, 23, 19, 24, 4, 142, DateTimeKind.Local).AddTicks(3115), "Grip", new DateTime(2026, 3, 22, 19, 24, 4, 142, DateTimeKind.Local).AddTicks(3112), 1, 1 },
                    { 1, "Admin", new DateTime(2026, 3, 24, 16, 24, 4, 142, DateTimeKind.Utc).AddTicks(1685), 1, new DateTime(2026, 4, 8, 19, 24, 4, 142, DateTimeKind.Local).AddTicks(2409), "Yaz Tatili", new DateTime(2026, 4, 3, 19, 24, 4, 142, DateTimeKind.Local).AddTicks(2216), 1, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftSegments_EmployeeId",
                table: "ShiftSegments",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "ShiftSegments");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 19, 31, 718, DateTimeKind.Utc).AddTicks(304));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 19, 31, 718, DateTimeKind.Utc).AddTicks(587));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 49, 31, 718, DateTimeKind.Utc).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 13, 19, 31, 718, DateTimeKind.Utc).AddTicks(601));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 34, 31, 718, DateTimeKind.Utc).AddTicks(602));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 721, DateTimeKind.Utc).AddTicks(91), new DateTime(2026, 3, 24, 16, 19, 31, 721, DateTimeKind.Utc).AddTicks(92) });

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 721, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 721, DateTimeKind.Utc).AddTicks(6511));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(4569), new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(4762) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(5169), new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(5169) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(5173), new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(5174) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(5176), new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(5176) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(5178), new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(5179) });

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 49, 31, 721, DateTimeKind.Utc).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 49, 31, 721, DateTimeKind.Utc).AddTicks(9581));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 49, 31, 721, DateTimeKind.Utc).AddTicks(9618));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAt",
                value: new DateTime(2026, 3, 23, 19, 19, 31, 722, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAt",
                value: new DateTime(2026, 2, 22, 19, 19, 31, 722, DateTimeKind.Local).AddTicks(5583));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(5089));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(5120));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(5122));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(435));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(2488));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(2492));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(2495));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(2497));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(2500));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(2502));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 718, DateTimeKind.Utc).AddTicks(1264));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 719, DateTimeKind.Utc).AddTicks(6480), new DateTime(2026, 3, 24, 14, 19, 31, 719, DateTimeKind.Utc).AddTicks(6496) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 719, DateTimeKind.Utc).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 719, DateTimeKind.Utc).AddTicks(7282));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 19, 31, 721, DateTimeKind.Utc).AddTicks(7974));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 19, 31, 721, DateTimeKind.Utc).AddTicks(8172));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 19, 31, 721, DateTimeKind.Utc).AddTicks(8174));

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 721, DateTimeKind.Utc).AddTicks(3352), new DateTime(2026, 3, 24, 16, 19, 31, 721, DateTimeKind.Utc).AddTicks(3353) });

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 721, DateTimeKind.Utc).AddTicks(4839), new DateTime(2026, 3, 24, 16, 19, 31, 721, DateTimeKind.Utc).AddTicks(4839) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(6050), new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(6051) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(7445), new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(7446) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(8136), new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(8136) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(9288), new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(9290), new DateTime(2026, 3, 24, 16, 19, 31, 720, DateTimeKind.Utc).AddTicks(9291) });

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 12, 19, 31, 719, DateTimeKind.Utc).AddTicks(9232));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 19, 31, 719, DateTimeKind.Utc).AddTicks(9680));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 19, 31, 719, DateTimeKind.Utc).AddTicks(9684));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 19, 31, 719, DateTimeKind.Utc).AddTicks(9686));

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 722, DateTimeKind.Utc).AddTicks(2087), new DateTime(2026, 3, 22, 19, 19, 31, 722, DateTimeKind.Local).AddTicks(2855) });

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 19, 31, 722, DateTimeKind.Utc).AddTicks(3554), new DateTime(2026, 3, 23, 19, 19, 31, 722, DateTimeKind.Local).AddTicks(3556) });

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(5770));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(8214));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(8218));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(8424));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 19, 31, 717, DateTimeKind.Utc).AddTicks(8427));
        }
    }
}
