using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Tier6_SafetyEnvironment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnvironmentalImpacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<double>(type: "REAL", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    LegalLimit = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvironmentalImpacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SafetyIncidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Severity = table.Column<int>(type: "INTEGER", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    ReportedBy = table.Column<string>(type: "TEXT", nullable: false),
                    CorrectiveAction = table.Column<string>(type: "TEXT", nullable: true),
                    IsClosed = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyIncidents", x => x.Id);
                });

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

            migrationBuilder.InsertData(
                table: "EnvironmentalImpacts",
                columns: new[] { "Id", "Description", "LegalLimit", "Location", "RecordedAt", "Type", "Unit", "Value" },
                values: new object[,]
                {
                    { 1, "Metal Çapağı", 1000.0, "CNC Atölyesi", new DateTime(2026, 3, 23, 19, 19, 31, 722, DateTimeKind.Local).AddTicks(4997), 0, "kg", 120.0 },
                    { 2, "CO2 Salınımı (Tahmini)", 10000.0, "Tesis Geneli", new DateTime(2026, 2, 22, 19, 19, 31, 722, DateTimeKind.Local).AddTicks(5583), 1, "ton", 450.0 }
                });

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

            migrationBuilder.InsertData(
                table: "SafetyIncidents",
                columns: new[] { "Id", "CorrectiveAction", "CreatedAt", "Description", "IncidentDate", "IsClosed", "Location", "ReportedBy", "Severity", "Title" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2026, 3, 24, 16, 19, 31, 722, DateTimeKind.Utc).AddTicks(2087), "B-Blok geçişinde forklift yaya yoluna çok yaklaştı.", new DateTime(2026, 3, 22, 19, 19, 31, 722, DateTimeKind.Local).AddTicks(2855), true, "Depo Girişi", "Ismail Depo", 0, "Ramak Kala: Forklift Geçişi" },
                    { 2, null, new DateTime(2026, 3, 24, 16, 19, 31, 722, DateTimeKind.Utc).AddTicks(3554), "Paketleme sırasında kağıt kesiği oluştu.", new DateTime(2026, 3, 23, 19, 19, 31, 722, DateTimeKind.Local).AddTicks(3556), false, "Paketleme Hattı", "Ayşe Paket", 1, "Küçük Yaralanma: El Kesilmesi" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnvironmentalImpacts");

            migrationBuilder.DropTable(
                name: "SafetyIncidents");

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
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 683, DateTimeKind.Utc).AddTicks(8501));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(484));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(485));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(487));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(488));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 18, 18, 684, DateTimeKind.Utc).AddTicks(491));

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
        }
    }
}
