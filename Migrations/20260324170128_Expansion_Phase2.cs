using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Expansion_Phase2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BudgetPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Department = table.Column<string>(type: "TEXT", nullable: false),
                    FiscalYear = table.Column<int>(type: "INTEGER", nullable: false),
                    AllocatedAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    SpentAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CapacityPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    AvailableHours = table.Column<double>(type: "REAL", nullable: false),
                    PlannedHours = table.Column<double>(type: "REAL", nullable: false),
                    WeekStarting = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapacityPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComplianceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    AuditDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AuditorName = table.Column<string>(type: "TEXT", nullable: false),
                    ResultSummary = table.Column<string>(type: "TEXT", nullable: false),
                    CertificatePath = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplianceRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayrollRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Period = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BaseSalary = table.Column<decimal>(type: "TEXT", nullable: false),
                    Bonus = table.Column<decimal>(type: "TEXT", nullable: false),
                    TaxDeductions = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayrollRecords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductVersions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    VersionNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ChangeLogs = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductVersions", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 1, 27, 374, DateTimeKind.Utc).AddTicks(3461));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 1, 27, 374, DateTimeKind.Utc).AddTicks(3738));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 31, 27, 374, DateTimeKind.Utc).AddTicks(3744));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 1, 27, 374, DateTimeKind.Utc).AddTicks(3753));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 27, 374, DateTimeKind.Utc).AddTicks(3754));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(8780), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(8781) });

            migrationBuilder.UpdateData(
                table: "CostCenters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "CostCenters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 379, DateTimeKind.Utc).AddTicks(592));

            migrationBuilder.UpdateData(
                table: "CostCenters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 379, DateTimeKind.Utc).AddTicks(595));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 377, DateTimeKind.Utc).AddTicks(9359));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(1254));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 376, DateTimeKind.Utc).AddTicks(4000));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 376, DateTimeKind.Utc).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(3229), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(3416) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(3818), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(3818) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(3846), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(3846) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(3848), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(3849) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(3851), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(3851) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 377, DateTimeKind.Utc).AddTicks(4704));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 377, DateTimeKind.Utc).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 377, DateTimeKind.Utc).AddTicks(6646));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 31, 27, 376, DateTimeKind.Utc).AddTicks(7992));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 31, 27, 376, DateTimeKind.Utc).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 31, 27, 376, DateTimeKind.Utc).AddTicks(8183));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAt",
                value: new DateTime(2026, 3, 23, 20, 1, 27, 377, DateTimeKind.Local).AddTicks(3520));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAt",
                value: new DateTime(2026, 2, 22, 20, 1, 27, 377, DateTimeKind.Local).AddTicks(4105));

            migrationBuilder.UpdateData(
                table: "FinanceTransactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 379, DateTimeKind.Utc).AddTicks(1215));

            migrationBuilder.UpdateData(
                table: "FinanceTransactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 379, DateTimeKind.Utc).AddTicks(2683));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(7671));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(7675));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(7681));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 374, DateTimeKind.Utc).AddTicks(9280));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 377, DateTimeKind.Utc).AddTicks(7167), new DateTime(2026, 4, 8, 20, 1, 27, 377, DateTimeKind.Local).AddTicks(7884), new DateTime(2026, 4, 3, 20, 1, 27, 377, DateTimeKind.Local).AddTicks(7695) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 377, DateTimeKind.Utc).AddTicks(8576), new DateTime(2026, 3, 23, 20, 1, 27, 377, DateTimeKind.Local).AddTicks(8580), new DateTime(2026, 3, 22, 20, 1, 27, 377, DateTimeKind.Local).AddTicks(8578) });

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(2930));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(4441));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(4444));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(4446));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(4447));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(4448));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(4449));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 374, DateTimeKind.Utc).AddTicks(4346));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 374, DateTimeKind.Utc).AddTicks(5717), new DateTime(2026, 3, 24, 15, 1, 27, 374, DateTimeKind.Utc).AddTicks(5722) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 374, DateTimeKind.Utc).AddTicks(6031));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 374, DateTimeKind.Utc).AddTicks(6518));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 1, 27, 376, DateTimeKind.Utc).AddTicks(6579));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 1, 27, 376, DateTimeKind.Utc).AddTicks(6774));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 1, 27, 376, DateTimeKind.Utc).AddTicks(6776));

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 376, DateTimeKind.Utc).AddTicks(1868), new DateTime(2026, 3, 24, 17, 1, 27, 376, DateTimeKind.Utc).AddTicks(1869) });

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 376, DateTimeKind.Utc).AddTicks(3409), new DateTime(2026, 3, 24, 17, 1, 27, 376, DateTimeKind.Utc).AddTicks(3409) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(4778), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(4778) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(6274), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(6274) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(6930), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(6931) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(7994), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(7995) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(7996), new DateTime(2026, 3, 24, 17, 1, 27, 375, DateTimeKind.Utc).AddTicks(7996) });

            migrationBuilder.UpdateData(
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(7079), new DateTime(2026, 3, 24, 20, 1, 27, 378, DateTimeKind.Local).AddTicks(7076), new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(7079) });

            migrationBuilder.UpdateData(
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(8680), new DateTime(2026, 3, 24, 20, 1, 27, 378, DateTimeKind.Local).AddTicks(8678), new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(8680) });

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 1, 27, 374, DateTimeKind.Utc).AddTicks(8212));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 1, 27, 374, DateTimeKind.Utc).AddTicks(8573));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 1, 27, 374, DateTimeKind.Utc).AddTicks(8577));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 16, 1, 27, 374, DateTimeKind.Utc).AddTicks(8579));

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 377, DateTimeKind.Utc).AddTicks(531), new DateTime(2026, 3, 22, 20, 1, 27, 377, DateTimeKind.Local).AddTicks(1260) });

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 377, DateTimeKind.Utc).AddTicks(1957), new DateTime(2026, 3, 23, 20, 1, 27, 377, DateTimeKind.Local).AddTicks(1958) });

            migrationBuilder.UpdateData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(1926), new DateTime(2026, 3, 24, 20, 1, 27, 378, DateTimeKind.Local).AddTicks(1924), new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(1926) });

            migrationBuilder.UpdateData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(3566), new DateTime(2026, 3, 24, 20, 1, 27, 378, DateTimeKind.Local).AddTicks(3564), new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(3566) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(4373));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 378, DateTimeKind.Utc).AddTicks(6406));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(1840));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 373, DateTimeKind.Utc).AddTicks(8634));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 374, DateTimeKind.Utc).AddTicks(946));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 374, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 374, DateTimeKind.Utc).AddTicks(1223));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 17, 1, 27, 374, DateTimeKind.Utc).AddTicks(1226));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BudgetPlans");

            migrationBuilder.DropTable(
                name: "CapacityPlans");

            migrationBuilder.DropTable(
                name: "ComplianceRecords");

            migrationBuilder.DropTable(
                name: "PayrollRecords");

            migrationBuilder.DropTable(
                name: "ProductVersions");

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 27, 37, 78, DateTimeKind.Utc).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 27, 37, 78, DateTimeKind.Utc).AddTicks(690));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 57, 37, 78, DateTimeKind.Utc).AddTicks(696));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 13, 27, 37, 78, DateTimeKind.Utc).AddTicks(706));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 42, 37, 78, DateTimeKind.Utc).AddTicks(707));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(5691), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(5692) });

            migrationBuilder.UpdateData(
                table: "CostCenters",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(6388));

            migrationBuilder.UpdateData(
                table: "CostCenters",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(7677));

            migrationBuilder.UpdateData(
                table: "CostCenters",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 81, DateTimeKind.Utc).AddTicks(6436));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 81, DateTimeKind.Utc).AddTicks(8249));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 80, DateTimeKind.Utc).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 80, DateTimeKind.Utc).AddTicks(2133));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(144), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(332) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(840), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(840) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(844), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(845) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(847), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(848) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(849), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(850) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 81, DateTimeKind.Utc).AddTicks(1759));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 81, DateTimeKind.Utc).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 81, DateTimeKind.Utc).AddTicks(3628));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 57, 37, 80, DateTimeKind.Utc).AddTicks(4915));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 57, 37, 80, DateTimeKind.Utc).AddTicks(5106));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 57, 37, 80, DateTimeKind.Utc).AddTicks(5108));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAt",
                value: new DateTime(2026, 3, 23, 19, 27, 37, 81, DateTimeKind.Local).AddTicks(451));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAt",
                value: new DateTime(2026, 2, 22, 19, 27, 37, 81, DateTimeKind.Local).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "FinanceTransactions",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "FinanceTransactions",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(3288));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(5298));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(5302));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(5304));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(5306));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(5307));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(5309));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(5311));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 78, DateTimeKind.Utc).AddTicks(6056));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 81, DateTimeKind.Utc).AddTicks(4152), new DateTime(2026, 4, 8, 19, 27, 37, 81, DateTimeKind.Local).AddTicks(4954), new DateTime(2026, 4, 3, 19, 27, 37, 81, DateTimeKind.Local).AddTicks(4763) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 81, DateTimeKind.Utc).AddTicks(5658), new DateTime(2026, 3, 23, 19, 27, 37, 81, DateTimeKind.Local).AddTicks(5662), new DateTime(2026, 3, 22, 19, 27, 37, 81, DateTimeKind.Local).AddTicks(5660) });

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(1063));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(2470));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(2474));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(2476));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(2493));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(2494));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(2518));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 78, DateTimeKind.Utc).AddTicks(1308));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 78, DateTimeKind.Utc).AddTicks(2618), new DateTime(2026, 3, 24, 14, 27, 37, 78, DateTimeKind.Utc).AddTicks(2623) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 78, DateTimeKind.Utc).AddTicks(2846));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 78, DateTimeKind.Utc).AddTicks(3303));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 27, 37, 80, DateTimeKind.Utc).AddTicks(3506));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 27, 37, 80, DateTimeKind.Utc).AddTicks(3700));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 27, 37, 80, DateTimeKind.Utc).AddTicks(3702));

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(8880), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(8881) });

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 80, DateTimeKind.Utc).AddTicks(356), new DateTime(2026, 3, 24, 16, 27, 37, 80, DateTimeKind.Utc).AddTicks(357) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(1695), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(1696) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(3135), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(3136) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(3796), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(3797) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(4868), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(4868) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(4871), new DateTime(2026, 3, 24, 16, 27, 37, 79, DateTimeKind.Utc).AddTicks(4871) });

            migrationBuilder.UpdateData(
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(4219), new DateTime(2026, 3, 24, 19, 27, 37, 82, DateTimeKind.Local).AddTicks(4217), new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(4219) });

            migrationBuilder.UpdateData(
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(5837), new DateTime(2026, 3, 24, 19, 27, 37, 82, DateTimeKind.Local).AddTicks(5836), new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 12, 27, 37, 78, DateTimeKind.Utc).AddTicks(4984));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 27, 37, 78, DateTimeKind.Utc).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 27, 37, 78, DateTimeKind.Utc).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 27, 37, 78, DateTimeKind.Utc).AddTicks(5356));

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 80, DateTimeKind.Utc).AddTicks(7554), new DateTime(2026, 3, 22, 19, 27, 37, 80, DateTimeKind.Local).AddTicks(8298) });

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 80, DateTimeKind.Utc).AddTicks(9013), new DateTime(2026, 3, 23, 19, 27, 37, 80, DateTimeKind.Local).AddTicks(9015) });

            migrationBuilder.UpdateData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 81, DateTimeKind.Utc).AddTicks(8925), new DateTime(2026, 3, 24, 19, 27, 37, 81, DateTimeKind.Local).AddTicks(8923), new DateTime(2026, 3, 24, 16, 27, 37, 81, DateTimeKind.Utc).AddTicks(8925) });

            migrationBuilder.UpdateData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(680), new DateTime(2026, 3, 24, 19, 27, 37, 82, DateTimeKind.Local).AddTicks(679), new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(3544));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 76, DateTimeKind.Utc).AddTicks(9531));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 76, DateTimeKind.Utc).AddTicks(9981));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 76, DateTimeKind.Utc).AddTicks(9983));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(8327));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(8332));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(8555));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 27, 37, 77, DateTimeKind.Utc).AddTicks(8558));
        }
    }
}
