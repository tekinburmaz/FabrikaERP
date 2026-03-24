using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Tier5_Logistics : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "InventoryItems");

            migrationBuilder.AddColumn<int>(
                name: "WarehouseZoneId",
                table: "InventoryItems",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "WarehouseZones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxCapacity = table.Column<double>(type: "REAL", nullable: false),
                    CurrentOccupancy = table.Column<double>(type: "REAL", nullable: false),
                    Temperature = table.Column<string>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseZones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    InventoryItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    FromZoneId = table.Column<int>(type: "INTEGER", nullable: true),
                    ToZoneId = table.Column<int>(type: "INTEGER", nullable: true),
                    ReferenceDocument = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedBy = table.Column<string>(type: "TEXT", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockMovements_InventoryItems_InventoryItemId",
                        column: x => x.InventoryItemId,
                        principalTable: "InventoryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StockMovements_WarehouseZones_FromZoneId",
                        column: x => x.FromZoneId,
                        principalTable: "WarehouseZones",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockMovements_WarehouseZones_ToZoneId",
                        column: x => x.ToZoneId,
                        principalTable: "WarehouseZones",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 18, 18, 684, DateTimeKind.Utc).AddTicks(5529));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 18, 18, 684, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 48, 18, 684, DateTimeKind.Utc).AddTicks(5859));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 13, 18, 18, 684, DateTimeKind.Utc).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 33, 18, 684, DateTimeKind.Utc).AddTicks(5870));

            migrationBuilder.UpdateData(
                table: "BillOfMaterials",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(6822), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(6822) });

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 688, DateTimeKind.Utc).AddTicks(2076));

            migrationBuilder.UpdateData(
                table: "DemandForecasts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 688, DateTimeKind.Utc).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(1292), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(1483) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(1894), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(1895) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(1899), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(1899) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(1920), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(1921) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(1923), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(1923) });

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 48, 18, 688, DateTimeKind.Utc).AddTicks(6112));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 48, 18, 688, DateTimeKind.Utc).AddTicks(6303));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 48, 18, 688, DateTimeKind.Utc).AddTicks(6305));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UpdatedAt", "WarehouseZoneId" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 683, DateTimeKind.Utc).AddTicks(8501), 1 });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "UpdatedAt", "WarehouseZoneId" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(457), 1 });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "UpdatedAt", "WarehouseZoneId" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(484), 1 });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "UpdatedAt", "WarehouseZoneId" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(485), 2 });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "UpdatedAt", "WarehouseZoneId" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(487), 1 });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "UpdatedAt", "WarehouseZoneId" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(488), 1 });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "UpdatedAt", "WarehouseZoneId" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(490), 1 });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "UpdatedAt", "WarehouseZoneId" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(491), 1 });

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 686, DateTimeKind.Utc).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 683, DateTimeKind.Utc).AddTicks(6483));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 683, DateTimeKind.Utc).AddTicks(7869));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 683, DateTimeKind.Utc).AddTicks(7872));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 683, DateTimeKind.Utc).AddTicks(7874));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 683, DateTimeKind.Utc).AddTicks(7876));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 683, DateTimeKind.Utc).AddTicks(7877));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 683, DateTimeKind.Utc).AddTicks(7878));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 683, DateTimeKind.Utc).AddTicks(7880));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 686, DateTimeKind.Utc).AddTicks(2915), new DateTime(2026, 3, 24, 14, 18, 18, 686, DateTimeKind.Utc).AddTicks(2931) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 686, DateTimeKind.Utc).AddTicks(3224));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 686, DateTimeKind.Utc).AddTicks(3757));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 18, 18, 688, DateTimeKind.Utc).AddTicks(4587));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 18, 18, 688, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 18, 18, 688, DateTimeKind.Utc).AddTicks(4846));

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 688, DateTimeKind.Utc).AddTicks(37), new DateTime(2026, 3, 24, 16, 18, 18, 688, DateTimeKind.Utc).AddTicks(38) });

            migrationBuilder.UpdateData(
                table: "ProductionSchedules",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 688, DateTimeKind.Utc).AddTicks(1520), new DateTime(2026, 3, 24, 16, 18, 18, 688, DateTimeKind.Utc).AddTicks(1520) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(2808), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(2808) });

            migrationBuilder.UpdateData(
                table: "ProjectList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(4265), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(4922), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(4922) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(6002), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(6002) });

            migrationBuilder.UpdateData(
                table: "Prototypes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(6004), new DateTime(2026, 3, 24, 16, 18, 18, 687, DateTimeKind.Utc).AddTicks(6004) });

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 12, 18, 18, 686, DateTimeKind.Utc).AddTicks(6073));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 18, 18, 686, DateTimeKind.Utc).AddTicks(6444));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 18, 18, 686, DateTimeKind.Utc).AddTicks(6448));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 18, 18, 686, DateTimeKind.Utc).AddTicks(6450));

            migrationBuilder.InsertData(
                table: "WarehouseZones",
                columns: new[] { "Id", "Code", "CurrentOccupancy", "IsActive", "MaxCapacity", "Name", "Temperature", "Type" },
                values: new object[,]
                {
                    { 1, "RM-A1", 2500.0, true, 5000.0, "Hammadde Depo A-1", null, 0 },
                    { 2, "WIP-01", 320.0, true, 1000.0, "Ara Mamul İstasyonu 1", null, 1 },
                    { 3, "FG-01", 150.0, true, 2000.0, "Bitmiş Ürün Deposu", null, 2 }
                });

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(1075));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(3535));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(3764));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(3767));

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_WarehouseZoneId",
                table: "InventoryItems",
                column: "WarehouseZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_FromZoneId",
                table: "StockMovements",
                column: "FromZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_InventoryItemId",
                table: "StockMovements",
                column: "InventoryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_ToZoneId",
                table: "StockMovements",
                column: "ToZoneId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_WarehouseZones_WarehouseZoneId",
                table: "InventoryItems",
                column: "WarehouseZoneId",
                principalTable: "WarehouseZones",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_WarehouseZones_WarehouseZoneId",
                table: "InventoryItems");

            migrationBuilder.DropTable(
                name: "StockMovements");

            migrationBuilder.DropTable(
                name: "WarehouseZones");

            migrationBuilder.DropIndex(
                name: "IX_InventoryItems_WarehouseZoneId",
                table: "InventoryItems");

            migrationBuilder.DropColumn(
                name: "WarehouseZoneId",
                table: "InventoryItems");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "InventoryItems",
                type: "TEXT",
                nullable: true);

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

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 46, 51, 948, DateTimeKind.Utc).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 46, 51, 948, DateTimeKind.Utc).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "EnergyLogs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 46, 51, 948, DateTimeKind.Utc).AddTicks(9891));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Location", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(3001) });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Location", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5384) });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Location", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5388) });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Location", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5390) });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Location", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5392) });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Location", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5393) });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Location", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5395) });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Location", "UpdatedAt" },
                values: new object[] { null, new DateTime(2026, 3, 24, 16, 16, 51, 943, DateTimeKind.Utc).AddTicks(5397) });

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

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 16, 51, 948, DateTimeKind.Utc).AddTicks(7957));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 16, 51, 948, DateTimeKind.Utc).AddTicks(8190));

            migrationBuilder.UpdateData(
                table: "OeeRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 15, 16, 51, 948, DateTimeKind.Utc).AddTicks(8193));

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
        }
    }
}
