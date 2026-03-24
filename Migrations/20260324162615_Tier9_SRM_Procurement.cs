using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Tier9_SRM_Procurement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    TaxNumber = table.Column<string>(type: "TEXT", nullable: false),
                    TaxOffice = table.Column<string>(type: "TEXT", nullable: false),
                    ContactPerson = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    PerformanceScore = table.Column<double>(type: "REAL", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", nullable: false),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    UnitPrice = table.Column<double>(type: "REAL", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExpectedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 26, 14, 784, DateTimeKind.Utc).AddTicks(6803));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 26, 14, 784, DateTimeKind.Utc).AddTicks(7265));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 56, 14, 784, DateTimeKind.Utc).AddTicks(7270));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 13, 26, 14, 784, DateTimeKind.Utc).AddTicks(7280));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 41, 14, 784, DateTimeKind.Utc).AddTicks(7281));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(2933), new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(2934) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(4279));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(6118));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(8353));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(9770));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(7207), new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(7399) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(7818), new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(7818) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(7823), new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(7824) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(7826), new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(7826) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(7828), new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(7828) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 787, DateTimeKind.Utc).AddTicks(9494));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(1479));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 56, 14, 787, DateTimeKind.Utc).AddTicks(2674));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 56, 14, 787, DateTimeKind.Utc).AddTicks(2867));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 56, 14, 787, DateTimeKind.Utc).AddTicks(2870));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAt",
                value: new DateTime(2026, 3, 23, 19, 26, 14, 787, DateTimeKind.Local).AddTicks(8278));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAt",
                value: new DateTime(2026, 2, 22, 19, 26, 14, 787, DateTimeKind.Local).AddTicks(8877));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(1614));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(1618));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(1620));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(1646));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(1647));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(2006), new DateTime(2026, 4, 8, 19, 26, 14, 788, DateTimeKind.Local).AddTicks(2741), new DateTime(2026, 4, 3, 19, 26, 14, 788, DateTimeKind.Local).AddTicks(2546) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(3454), new DateTime(2026, 3, 23, 19, 26, 14, 788, DateTimeKind.Local).AddTicks(3458), new DateTime(2026, 3, 22, 19, 26, 14, 788, DateTimeKind.Local).AddTicks(3456) });

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(8821));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(8825));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(8827));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(8828));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(8830));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(8831));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(8832));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(7905));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(9511), new DateTime(2026, 3, 24, 14, 26, 14, 784, DateTimeKind.Utc).AddTicks(9516) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(9741));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(260));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 26, 14, 787, DateTimeKind.Utc).AddTicks(1188));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 26, 14, 787, DateTimeKind.Utc).AddTicks(1386));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 26, 14, 787, DateTimeKind.Utc).AddTicks(1388));

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(6144), new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(6144) });

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(7797), new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(7798) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(8719), new DateTime(2026, 3, 24, 16, 26, 14, 785, DateTimeKind.Utc).AddTicks(8720) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(278), new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(279) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(972), new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(973) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(2083), new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(2083) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(2086), new DateTime(2026, 3, 24, 16, 26, 14, 786, DateTimeKind.Utc).AddTicks(2086) });

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 12, 26, 14, 785, DateTimeKind.Utc).AddTicks(2016));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 26, 14, 785, DateTimeKind.Utc).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 26, 14, 785, DateTimeKind.Utc).AddTicks(2428));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 26, 14, 785, DateTimeKind.Utc).AddTicks(2430));

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 787, DateTimeKind.Utc).AddTicks(5267), new DateTime(2026, 3, 22, 19, 26, 14, 787, DateTimeKind.Local).AddTicks(6013) });

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 787, DateTimeKind.Utc).AddTicks(6733), new DateTime(2026, 3, 23, 19, 26, 14, 787, DateTimeKind.Local).AddTicks(6735) });

            migrationBuilder.UpdateData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(6869), new DateTime(2026, 3, 24, 19, 26, 14, 788, DateTimeKind.Local).AddTicks(6866), new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(6870) });

            migrationBuilder.UpdateData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(8563), new DateTime(2026, 3, 24, 19, 26, 14, 788, DateTimeKind.Local).AddTicks(8561), new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(8563) });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "Category", "Code", "CompanyName", "ContactPerson", "CreatedAt", "Email", "IsActive", "Name", "PerformanceScore", "Phone", "TaxNumber", "TaxOffice" },
                values: new object[,]
                {
                    { 1, "Hammadde", "SUP-001", "Metal Sanayi Ticaret Anonim Şirketi", "Zeki Demir", new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(9718), "info@metalsan.com", true, "MetalSan A.S.", 95.0, "0262 333 22 11", "5556667778", "Gebze" },
                    { 2, "Kimyasal", "SUP-002", "Polimer Sanayi Limited Şirketi", "Mert Plastik", new DateTime(2026, 3, 24, 16, 26, 14, 789, DateTimeKind.Utc).AddTicks(1780), "satis@polimer.com", true, "Polimer Kimya", 88.0, "0216 444 55 66", "1112223334", "Tuzla" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(5887));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 783, DateTimeKind.Utc).AddTicks(6148));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(4677));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 784, DateTimeKind.Utc).AddTicks(4907));

            migrationBuilder.InsertData(
                table: "PurchaseOrders",
                columns: new[] { "Id", "CreatedAt", "ExpectedDate", "OrderDate", "OrderNumber", "ProductCode", "ProductName", "Quantity", "Status", "SupplierId", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 24, 16, 26, 14, 789, DateTimeKind.Utc).AddTicks(2506), new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 3, 24, 19, 26, 14, 789, DateTimeKind.Local).AddTicks(2504), "PO-2024-001", "HM-001", "Çelik Profil 40x40", 5000.0, 1, 1, 10.5, new DateTime(2026, 3, 24, 16, 26, 14, 789, DateTimeKind.Utc).AddTicks(2507) },
                    { 2, new DateTime(2026, 3, 24, 16, 26, 14, 789, DateTimeKind.Utc).AddTicks(4169), new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 3, 24, 19, 26, 14, 789, DateTimeKind.Local).AddTicks(4167), "PO-2024-002", "HM-003", "Plastik Granül ABS", 2000.0, 0, 2, 42.0, new DateTime(2026, 3, 24, 16, 26, 14, 789, DateTimeKind.Utc).AddTicks(4169) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierId",
                table: "PurchaseOrders",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 25, 0, 693, DateTimeKind.Utc).AddTicks(962));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 25, 0, 693, DateTimeKind.Utc).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 55, 0, 693, DateTimeKind.Utc).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 13, 25, 0, 693, DateTimeKind.Utc).AddTicks(1286));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 40, 0, 693, DateTimeKind.Utc).AddTicks(1287));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(6369), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(6369) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(7323));

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(9168));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 695, DateTimeKind.Utc).AddTicks(1550));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 695, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(846), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(1034) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(1442), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(1442) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(1446), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(1446) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(1449), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(1449) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(1451), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(1451) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(4224));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(4227));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 55, 0, 695, DateTimeKind.Utc).AddTicks(5578));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 55, 0, 695, DateTimeKind.Utc).AddTicks(5776));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 55, 0, 695, DateTimeKind.Utc).AddTicks(5778));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "RecordedAt",
                value: new DateTime(2026, 3, 23, 19, 25, 0, 696, DateTimeKind.Local).AddTicks(1228));

            migrationBuilder.UpdateData(
                table: "EnvironmentalImpacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "RecordedAt",
                value: new DateTime(2026, 2, 22, 19, 25, 0, 696, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(5896));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(5902));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(5922));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(5923));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 693, DateTimeKind.Utc).AddTicks(6848));

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(4740), new DateTime(2026, 4, 8, 19, 25, 0, 696, DateTimeKind.Local).AddTicks(5473), new DateTime(2026, 4, 3, 19, 25, 0, 696, DateTimeKind.Local).AddTicks(5282) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(6258), new DateTime(2026, 3, 23, 19, 25, 0, 696, DateTimeKind.Local).AddTicks(6262), new DateTime(2026, 3, 22, 19, 25, 0, 696, DateTimeKind.Local).AddTicks(6259) });

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(3057));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(3060));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(3063));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 693, DateTimeKind.Utc).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 693, DateTimeKind.Utc).AddTicks(3210), new DateTime(2026, 3, 24, 14, 25, 0, 693, DateTimeKind.Utc).AddTicks(3215) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 693, DateTimeKind.Utc).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 693, DateTimeKind.Utc).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 25, 0, 695, DateTimeKind.Utc).AddTicks(4081));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 25, 0, 695, DateTimeKind.Utc).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 25, 0, 695, DateTimeKind.Utc).AddTicks(4303));

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(9447), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(9447) });

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 695, DateTimeKind.Utc).AddTicks(912), new DateTime(2026, 3, 24, 16, 25, 0, 695, DateTimeKind.Utc).AddTicks(913) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(2334), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(2335) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(3730), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(3731) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(4403), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(4404) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(5482), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(5483) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(5485), new DateTime(2026, 3, 24, 16, 25, 0, 694, DateTimeKind.Utc).AddTicks(5485) });

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 12, 25, 0, 693, DateTimeKind.Utc).AddTicks(5654));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 25, 0, 693, DateTimeKind.Utc).AddTicks(6054));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 25, 0, 693, DateTimeKind.Utc).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 25, 0, 693, DateTimeKind.Utc).AddTicks(6060));

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 695, DateTimeKind.Utc).AddTicks(8233), new DateTime(2026, 3, 22, 19, 25, 0, 695, DateTimeKind.Local).AddTicks(8974) });

            migrationBuilder.UpdateData(
                table: "SafetyIncidents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "IncidentDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 695, DateTimeKind.Utc).AddTicks(9684), new DateTime(2026, 3, 23, 19, 25, 0, 695, DateTimeKind.Local).AddTicks(9686) });

            migrationBuilder.UpdateData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(9862), new DateTime(2026, 3, 24, 19, 25, 0, 696, DateTimeKind.Local).AddTicks(9859), new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(9862) });

            migrationBuilder.UpdateData(
                table: "SalesOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 25, 0, 697, DateTimeKind.Utc).AddTicks(1538), new DateTime(2026, 3, 24, 19, 25, 0, 697, DateTimeKind.Local).AddTicks(1537), new DateTime(2026, 3, 24, 16, 25, 0, 697, DateTimeKind.Utc).AddTicks(1539) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(257));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(512));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(6540));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(8890));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(9108));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 25, 0, 692, DateTimeKind.Utc).AddTicks(9111));
        }
    }
}
