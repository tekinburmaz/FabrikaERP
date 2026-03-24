using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Tier10_FinanceCost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CostCenters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: true),
                    Manager = table.Column<string>(type: "TEXT", nullable: true),
                    Budget = table.Column<decimal>(type: "TEXT", nullable: false),
                    ActualCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostCenters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TransactionNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    Currency = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: true),
                    SupplierId = table.Column<int>(type: "INTEGER", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinanceTransactions_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FinanceTransactions_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "CostCenters",
                columns: new[] { "Id", "ActualCost", "Budget", "Code", "CreatedAt", "Department", "IsActive", "Manager", "Name" },
                values: new object[,]
                {
                    { 1, 1250000m, 5000000m, "CC-PROD", new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(6388), "Üretim", true, "Üretim Md.", "Üretim Departmanı" },
                    { 2, 450000m, 2000000m, "CC-RND", new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(7677), "Ar-Ge", true, "Ar-Ge Md.", "Ar-Ge Merkezi" },
                    { 3, 210000m, 800000m, "CC-QA", new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(7680), "Kalite", true, "Kalite Md.", "Kalite Kontrol" }
                });

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

            migrationBuilder.InsertData(
                table: "FinanceTransactions",
                columns: new[] { "Id", "Amount", "CreatedAt", "Currency", "CustomerId", "Description", "Status", "SupplierId", "TransactionDate", "TransactionNumber", "Type" },
                values: new object[,]
                {
                    { 1, 150000m, new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(8285), "TRY", 1, "Sipariş SO-2024-001 Ön Ödemesi", 1, null, new DateTime(2026, 3, 19, 0, 0, 0, 0, DateTimeKind.Local), "TR-001", 1 },
                    { 2, 52500m, new DateTime(2026, 3, 24, 16, 27, 37, 82, DateTimeKind.Utc).AddTicks(9888), "TRY", null, "Hammadde Alımı PO-2024-001 Ödemesi", 0, 1, new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Local), "TR-002", 0 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_FinanceTransactions_CustomerId",
                table: "FinanceTransactions",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_FinanceTransactions_SupplierId",
                table: "FinanceTransactions",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CostCenters");

            migrationBuilder.DropTable(
                name: "FinanceTransactions");

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
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 789, DateTimeKind.Utc).AddTicks(2506), new DateTime(2026, 3, 24, 19, 26, 14, 789, DateTimeKind.Local).AddTicks(2504), new DateTime(2026, 3, 24, 16, 26, 14, 789, DateTimeKind.Utc).AddTicks(2507) });

            migrationBuilder.UpdateData(
                table: "PurchaseOrders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "OrderDate", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 26, 14, 789, DateTimeKind.Utc).AddTicks(4169), new DateTime(2026, 3, 24, 19, 26, 14, 789, DateTimeKind.Local).AddTicks(4167), new DateTime(2026, 3, 24, 16, 26, 14, 789, DateTimeKind.Utc).AddTicks(4169) });

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

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 788, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.UpdateData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 26, 14, 789, DateTimeKind.Utc).AddTicks(1780));

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
        }
    }
}
