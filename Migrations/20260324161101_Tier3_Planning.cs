using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Tier3_Planning : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DemandForecasts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ForecastedQty = table.Column<double>(type: "REAL", nullable: false),
                    Period = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Reliability = table.Column<double>(type: "REAL", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemandForecasts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    TargetDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductionSchedules_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaterialRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaterialCode = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialName = table.Column<string>(type: "TEXT", nullable: false),
                    RequiredQty = table.Column<double>(type: "REAL", nullable: false),
                    AvailableInStock = table.Column<double>(type: "REAL", nullable: false),
                    RequiredByDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductionScheduleId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialRequirements_ProductionSchedules_ProductionScheduleId",
                        column: x => x.ProductionScheduleId,
                        principalTable: "ProductionSchedules",
                        principalColumn: "Id");
                });

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

            migrationBuilder.InsertData(
                table: "DemandForecasts",
                columns: new[] { "Id", "CreatedAt", "ForecastedQty", "Period", "ProductCode", "ProductName", "Reliability" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(8367), 1200.0, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YP-001", "Dişli Grubu A-12", 0.84999999999999998 },
                    { 2, new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(9662), 450.0, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "YP-002", "Gövde Kasası B-7", 0.75 }
                });

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

            migrationBuilder.InsertData(
                table: "ProductionSchedules",
                columns: new[] { "Id", "CreatedAt", "MachineId", "OrderNumber", "ProductCode", "ProductName", "Quantity", "Status", "TargetDate", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(5808), 1, "MPS-2024-001", "YP-001", "Dişli Grubu A-12", 500.0, 1, new DateTime(2026, 3, 31, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(5808) },
                    { 2, new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(7691), 3, "MPS-2024-002", "YP-002", "Gövde Kasası B-7", 200.0, 0, new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 3, 24, 16, 11, 0, 597, DateTimeKind.Utc).AddTicks(7691) }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequirements_ProductionScheduleId",
                table: "MaterialRequirements",
                column: "ProductionScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionSchedules_MachineId",
                table: "ProductionSchedules",
                column: "MachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DemandForecasts");

            migrationBuilder.DropTable(
                name: "MaterialRequirements");

            migrationBuilder.DropTable(
                name: "ProductionSchedules");

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 9, 51, 341, DateTimeKind.Utc).AddTicks(2894));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 9, 51, 341, DateTimeKind.Utc).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 39, 51, 341, DateTimeKind.Utc).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 13, 9, 51, 341, DateTimeKind.Utc).AddTicks(3223));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 24, 51, 341, DateTimeKind.Utc).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(4414), new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(4415) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(8291), new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(8485) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(8906), new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(8906) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(8911), new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(8913), new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(8914) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(8916), new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(8916) });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(7791));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(7794));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(7796));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(7797));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(7798));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(7820));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(7822));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(3611));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(5169));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(5172));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(5174));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(5175));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(5177));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(5178));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(5179));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 341, DateTimeKind.Utc).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 342, DateTimeKind.Utc).AddTicks(9899), new DateTime(2026, 3, 24, 14, 9, 51, 342, DateTimeKind.Utc).AddTicks(9915) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(202));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 343, DateTimeKind.Utc).AddTicks(714));

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(40), new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(41) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(1589), new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(1590) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(2274), new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(2275) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(3391), new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(3392) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(3393), new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(3394) });

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 12, 9, 51, 343, DateTimeKind.Utc).AddTicks(2948));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 9, 51, 343, DateTimeKind.Utc).AddTicks(3325));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 9, 51, 343, DateTimeKind.Utc).AddTicks(3357));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 9, 51, 343, DateTimeKind.Utc).AddTicks(3360));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 340, DateTimeKind.Utc).AddTicks(8498));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 341, DateTimeKind.Utc).AddTicks(882));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 341, DateTimeKind.Utc).AddTicks(886));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 341, DateTimeKind.Utc).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 9, 51, 341, DateTimeKind.Utc).AddTicks(1117));
        }
    }
}
