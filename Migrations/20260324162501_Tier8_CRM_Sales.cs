using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Tier8_CRM_Sales : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
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
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    UnitPrice = table.Column<double>(type: "REAL", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    RequestedDeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesOrders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "Code", "CompanyName", "ContactPerson", "CreatedAt", "Email", "IsActive", "Name", "Phone", "TaxNumber", "TaxOffice" },
                values: new object[,]
                {
                    { 1, "İstanbul, Türkiye", "CUS-001", "Mega İnşaat ve Sanayi Limited Şirketi", "Ali Mega", new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(7323), "info@megainsaat.com", true, "Mega Insaat Ltd.", "0212 555 44 33", "1234567890", "Boğaziçi" },
                    { 2, "Ankara, Türkiye", "CUS-002", "Solar Enerji Sistemleri Anonim Şirketi", "Can Güneş", new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(9168), "satis@solarenerji.com", true, "Solar Enerji A.S.", "0312 444 33 22", "0987654321", "Ankara" }
                });

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

            migrationBuilder.InsertData(
                table: "SalesOrders",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "OrderDate", "OrderNumber", "ProductCode", "ProductName", "Quantity", "RequestedDeliveryDate", "Status", "UnitPrice", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(9862), 1, new DateTime(2026, 3, 24, 19, 25, 0, 696, DateTimeKind.Local).AddTicks(9859), "SO-2024-001", "YP-001", "Dişli Grubu A-12", 1000.0, new DateTime(2026, 4, 23, 0, 0, 0, 0, DateTimeKind.Local), 1, 150.0, new DateTime(2026, 3, 24, 16, 25, 0, 696, DateTimeKind.Utc).AddTicks(9862) },
                    { 2, new DateTime(2026, 3, 24, 16, 25, 0, 697, DateTimeKind.Utc).AddTicks(1538), 2, new DateTime(2026, 3, 24, 19, 25, 0, 697, DateTimeKind.Local).AddTicks(1537), "SO-2024-002", "FP-001", "Montaj Kiti E-2", 500.0, new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Local), 0, 280.0, new DateTime(2026, 3, 24, 16, 25, 0, 697, DateTimeKind.Utc).AddTicks(1539) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropTable(
                name: "Customers");

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

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 141, DateTimeKind.Utc).AddTicks(9240));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 142, DateTimeKind.Utc).AddTicks(1162));

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 142, DateTimeKind.Utc).AddTicks(1166));

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
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 142, DateTimeKind.Utc).AddTicks(1685), new DateTime(2026, 4, 8, 19, 24, 4, 142, DateTimeKind.Local).AddTicks(2409), new DateTime(2026, 4, 3, 19, 24, 4, 142, DateTimeKind.Local).AddTicks(2216) });

            migrationBuilder.UpdateData(
                table: "LeaveRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "EndDate", "StartDate" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 24, 4, 142, DateTimeKind.Utc).AddTicks(3111), new DateTime(2026, 3, 23, 19, 24, 4, 142, DateTimeKind.Local).AddTicks(3115), new DateTime(2026, 3, 22, 19, 24, 4, 142, DateTimeKind.Local).AddTicks(3112) });

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(5312));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 24, 4, 137, DateTimeKind.Utc).AddTicks(5314));

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
        }
    }
}
