using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Tier4_MaintenanceEnergy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnergyLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: true),
                    ConsumptionKwh = table.Column<double>(type: "REAL", nullable: false),
                    InstantWattage = table.Column<double>(type: "REAL", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnergyLogs_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OeeRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: false),
                    Availability = table.Column<double>(type: "REAL", nullable: false),
                    Performance = table.Column<double>(type: "REAL", nullable: false),
                    Quality = table.Column<double>(type: "REAL", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OeeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OeeRecords_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 16, 51, 944, DateTimeKind.Utc).AddTicks(1660));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 16, 51, 944, DateTimeKind.Utc).AddTicks(2010));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 46, 51, 944, DateTimeKind.Utc).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 13, 16, 51, 944, DateTimeKind.Utc).AddTicks(2029));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 31, 51, 944, DateTimeKind.Utc).AddTicks(2031));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(8210), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(8210) });

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 948, DateTimeKind.Utc).AddTicks(4782));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 948, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(1255), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(1495) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(2041), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(2042) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(2047), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(2048) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(2051), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(2051) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(2053), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(2054) });

            migrationBuilder.InsertData(
                table: "EnergyLogs",
                columns: new[] { "Id", "ConsumptionKwh", "InstantWattage", "MachineId", "Timestamp" },
                values: new object[,]
                {
                    { 1, 12.5, 4500.0, 1, new DateTime(2026, 3, 24, 15, 46, 51, 948, DateTimeKind.Utc).AddTicks(9657) },
                    { 2, 8.1999999999999993, 3200.0, 2, new DateTime(2026, 3, 24, 15, 46, 51, 948, DateTimeKind.Utc).AddTicks(9888) },
                    { 3, 15.699999999999999, 5800.0, 5, new DateTime(2026, 3, 24, 15, 46, 51, 948, DateTimeKind.Utc).AddTicks(9891) }
                });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5384));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5390));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5392));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5397));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 946, DateTimeKind.Utc).AddTicks(6083));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(473));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 944, DateTimeKind.Utc).AddTicks(2731));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 946, DateTimeKind.Utc).AddTicks(1242), new DateTime(2026, 3, 24, 14, 16, 51, 946, DateTimeKind.Utc).AddTicks(1293) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 946, DateTimeKind.Utc).AddTicks(1688));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 946, DateTimeKind.Utc).AddTicks(2329));

            migrationBuilder.InsertData(
                table: "OeeRecords",
                columns: new[] { "Id", "Availability", "MachineId", "Performance", "Quality", "Timestamp" },
                values: new object[,]
                {
                    { 1, 0.94999999999999996, 1, 0.92000000000000004, 0.98999999999999999, new DateTime(2026, 3, 24, 15, 16, 51, 948, DateTimeKind.Utc).AddTicks(7957) },
                    { 2, 0.88, 2, 0.93999999999999995, 0.97999999999999998, new DateTime(2026, 3, 24, 15, 16, 51, 948, DateTimeKind.Utc).AddTicks(8190) },
                    { 3, 0.92000000000000004, 4, 0.89000000000000001, 0.96999999999999997, new DateTime(2026, 3, 24, 15, 16, 51, 948, DateTimeKind.Utc).AddTicks(8193) }
                });

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 948, DateTimeKind.Utc).AddTicks(2235), new DateTime(2026, 3, 24, 16, 16, 51, 948, DateTimeKind.Utc).AddTicks(2235) });

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 948, DateTimeKind.Utc).AddTicks(4071), new DateTime(2026, 3, 24, 16, 16, 51, 948, DateTimeKind.Utc).AddTicks(4071) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(3131), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(3132) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(4861), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(4862) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(5665), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(5666) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(7192), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(7192) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(7195), new DateTime(2026, 3, 24, 16, 16, 51, 947, DateTimeKind.Utc).AddTicks(7195) });

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 12, 16, 51, 946, DateTimeKind.Utc).AddTicks(4678));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 16, 51, 946, DateTimeKind.Utc).AddTicks(5133));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 16, 51, 946, DateTimeKind.Utc).AddTicks(5138));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 16, 51, 946, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(9182));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(9504));

            migrationBuilder.CreateIndex(
                name: "IX_EnergyLogs_MachineId",
                table: "EnergyLogs",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_OeeRecords_MachineId",
                table: "OeeRecords",
                column: "MachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnergyLogs");

            migrationBuilder.DropTable(
                name: "OeeRecords");

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 11, 0, 593, DateTimeKind.Utc).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 11, 0, 593, DateTimeKind.Utc).AddTicks(5701));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 41, 0, 593, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 13, 11, 0, 593, DateTimeKind.Utc).AddTicks(5718));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 26, 0, 593, DateTimeKind.Utc).AddTicks(5719));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(2076), new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(2076) });

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(8367));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(9662));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(4969), new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(5214) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(5755), new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(5756) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(5761), new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(5761) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(5764), new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(5764) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(5767), new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(5767) });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(7336));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(9562));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(9563));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(9568));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 595, DateTimeKind.Utc).AddTicks(9991));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(4753));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(6541));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(6546));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(6548));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(6549));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(6551));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(6573));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 592, DateTimeKind.Utc).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 593, DateTimeKind.Utc).AddTicks(6386));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 595, DateTimeKind.Utc).AddTicks(4356), new DateTime(2026, 3, 24, 14, 11, 0, 595, DateTimeKind.Utc).AddTicks(4410) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 595, DateTimeKind.Utc).AddTicks(5011));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 595, DateTimeKind.Utc).AddTicks(5696));

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(5808), new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(5808) });

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(7691), new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(7691) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(6947), new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(6948) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(8882), new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(8883) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(9680), new DateTime(2026, 3, 24, 16, 11, 0, 596, DateTimeKind.Utc).AddTicks(9681) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(1034), new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(1035) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(1037), new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(1037) });

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 12, 11, 0, 595, DateTimeKind.Utc).AddTicks(8548));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 11, 0, 595, DateTimeKind.Utc).AddTicks(9001));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 11, 0, 595, DateTimeKind.Utc).AddTicks(9007));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 11, 0, 595, DateTimeKind.Utc).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 593, DateTimeKind.Utc).AddTicks(270));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 593, DateTimeKind.Utc).AddTicks(2971));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 593, DateTimeKind.Utc).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 593, DateTimeKind.Utc).AddTicks(3256));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 11, 0, 593, DateTimeKind.Utc).AddTicks(3259));
        }
    }
}
