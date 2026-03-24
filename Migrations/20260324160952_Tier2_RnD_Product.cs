using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Tier2_RnD_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BillOfMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfMaterials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Manager = table.Column<string>(type: "TEXT", nullable: false),
                    Budget = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BomItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BillOfMaterialId = table.Column<int>(type: "INTEGER", nullable: false),
                    MaterialCode = table.Column<string>(type: "TEXT", nullable: false),
                    MaterialName = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BomItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BomItems_BillOfMaterials_BillOfMaterialId",
                        column: x => x.BillOfMaterialId,
                        principalTable: "BillOfMaterials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prototypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ProjectId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    TestResults = table.Column<string>(type: "TEXT", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prototypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prototypes_ProjectList_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "ProjectList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "BillOfMaterials",
                columns: new[] { "Id", "CreatedAt", "IsActive", "ProductCode", "ProductName", "UpdatedAt", "Version" },
                values: new object[] { 1, new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(4414), true, "YP-001", "Dişli Grubu A-12", new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(4415), "1.0" });

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

            migrationBuilder.InsertData(
                table: "ProjectList",
                columns: new[] { "Id", "Budget", "Code", "CreatedAt", "Description", "EndDate", "Manager", "Name", "StartDate", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1500000m, "PRJ-24-001", new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(40), "", null, "Ar-Ge Müdürü", "Yeni Nesil Elektrikli Motor", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(41) },
                    { 2, 450000m, "PRJ-24-002", new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(1589), "", null, "Sistem Mühendisi", "Akıllı Sensör Entegrasyonu", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(1590) }
                });

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

            migrationBuilder.InsertData(
                table: "BomItems",
                columns: new[] { "Id", "BillOfMaterialId", "MaterialCode", "MaterialName", "Position", "Quantity", "Unit" },
                values: new object[,]
                {
                    { 1, 1, "HM-001", "Çelik Profil 40x40", null, 2.5, "kg" },
                    { 2, 1, "BP-002", "Rulman 6205-2RS", null, 2.0, "adet" }
                });

            migrationBuilder.InsertData(
                table: "Prototypes",
                columns: new[] { "Id", "Code", "CreatedAt", "Name", "ProjectId", "Status", "TestResults", "UpdatedAt", "Version" },
                values: new object[,]
                {
                    { 1, "PRT-EM-01", new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(2274), "V1 Motor Prototipi", 1, 3, "", new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(2275), "v1.2" },
                    { 2, "PRT-EM-02", new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(3391), "V2 Yüksek Torklu Motor", 1, 1, "", new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(3392), "v2.0" },
                    { 3, "PRT-SN-01", new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(3393), "Sıcaklık Sensör Modülü", 2, 2, "", new DateTime(2026, 3, 24, 16, 9, 51, 344, DateTimeKind.Utc).AddTicks(3394), "v1.0" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BomItems_BillOfMaterialId",
                table: "BomItems",
                column: "BillOfMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Prototypes_ProjectId",
                table: "Prototypes",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BomItems");

            migrationBuilder.DropTable(
                name: "Prototypes");

            migrationBuilder.DropTable(
                name: "BillOfMaterials");

            migrationBuilder.DropTable(
                name: "ProjectList");

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 14, 7, 48, 144, DateTimeKind.Utc).AddTicks(7131));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 7, 48, 144, DateTimeKind.Utc).AddTicks(7535));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 37, 48, 144, DateTimeKind.Utc).AddTicks(7542));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 13, 7, 48, 144, DateTimeKind.Utc).AddTicks(7554));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 15, 22, 48, 144, DateTimeKind.Utc).AddTicks(7555));

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(5880), new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6114) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6618), new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6619) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6625), new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6625) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6628), new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6628) });

            migrationBuilder.UpdateData(
                table: "Documents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6630), new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6631) });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 143, DateTimeKind.Utc).AddTicks(8807));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(1050));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(1054));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(1056));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(1080));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(1082));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(1101));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(893));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 143, DateTimeKind.Utc).AddTicks(6191));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 143, DateTimeKind.Utc).AddTicks(8037));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 143, DateTimeKind.Utc).AddTicks(8042));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 143, DateTimeKind.Utc).AddTicks(8044));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 143, DateTimeKind.Utc).AddTicks(8046));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 143, DateTimeKind.Utc).AddTicks(8047));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 143, DateTimeKind.Utc).AddTicks(8049));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 143, DateTimeKind.Utc).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(8256));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 24, 16, 7, 48, 146, DateTimeKind.Utc).AddTicks(6082), new DateTime(2026, 3, 24, 14, 7, 48, 146, DateTimeKind.Utc).AddTicks(6099) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 146, DateTimeKind.Utc).AddTicks(6434));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 146, DateTimeKind.Utc).AddTicks(7047));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 12, 7, 48, 146, DateTimeKind.Utc).AddTicks(9522));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 13, 7, 48, 146, DateTimeKind.Utc).AddTicks(9977));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 14, 7, 48, 146, DateTimeKind.Utc).AddTicks(9982));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 24, 15, 7, 48, 146, DateTimeKind.Utc).AddTicks(9984));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(4733));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(4738));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(4999));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 24, 16, 7, 48, 144, DateTimeKind.Utc).AddTicks(5003));
        }
    }
}
