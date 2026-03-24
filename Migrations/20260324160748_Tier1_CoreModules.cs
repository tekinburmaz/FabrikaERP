using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class Tier1_CoreModules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ReadAt",
                table: "Alerts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AuditLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    EntityName = table.Column<string>(type: "TEXT", nullable: false),
                    EntityKey = table.Column<string>(type: "TEXT", nullable: false),
                    Action = table.Column<int>(type: "INTEGER", nullable: false),
                    OldValues = table.Column<string>(type: "TEXT", nullable: true),
                    NewValues = table.Column<string>(type: "TEXT", nullable: true),
                    ChangedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    FilePath = table.Column<string>(type: "TEXT", nullable: false),
                    FileExtension = table.Column<string>(type: "TEXT", nullable: false),
                    Version = table.Column<string>(type: "TEXT", nullable: false),
                    Department = table.Column<string>(type: "TEXT", nullable: true),
                    MachineCode = table.Column<string>(type: "TEXT", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    UploadedBy = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "ReadAt" },
                values: new object[] { new DateTime(2026, 3, 24, 14, 7, 48, 144, DateTimeKind.Utc).AddTicks(7131), null });

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "ReadAt" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 7, 48, 144, DateTimeKind.Utc).AddTicks(7535), null });

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "ReadAt" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 37, 48, 144, DateTimeKind.Utc).AddTicks(7542), null });

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "ReadAt" },
                values: new object[] { new DateTime(2026, 3, 24, 13, 7, 48, 144, DateTimeKind.Utc).AddTicks(7554), null });

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "ReadAt" },
                values: new object[] { new DateTime(2026, 3, 24, 15, 22, 48, 144, DateTimeKind.Utc).AddTicks(7555), null });

            migrationBuilder.InsertData(
                table: "Documents",
                columns: new[] { "Id", "Code", "CreatedAt", "Department", "Description", "ExpiryDate", "FileExtension", "FilePath", "IsActive", "MachineCode", "Title", "Type", "UpdatedAt", "UploadedBy", "Version" },
                values: new object[,]
                {
                    { 1, "DOC-MAN-001", new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(5880), "Üretim", null, null, "PDF", "", true, "CNC-01", "CNC Torna A-1 Kullanım Kılavuzu", 1, new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6114), "Admin", "v2.1" },
                    { 2, "DOC-ISO-001", new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6618), "Kalite", null, new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "PDF", "", true, null, "ISO 9001:2015 Kalite Prosedürü", 5, new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6619), "Admin", "v3.0" },
                    { 3, "DOC-SAF-001", new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6625), "Güvenlik", null, null, "PDF", "", true, null, "Makine Güvenlik Prosedürü", 2, new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6625), "Admin", "v1.5" },
                    { 4, "DOC-WI-001", new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6628), "Kaynak", null, null, "DOCX", "", true, "WLD-01", "Kaynak Robotu Operasyon Talimatı", 4, new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6628), "Admin", "v1.0" },
                    { 5, "DOC-FRM-001", new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6630), "Bakım", null, null, "XLSX", "", true, null, "Günlük Bakım Kontrol Formu", 6, new DateTime(2026, 3, 24, 16, 7, 48, 147, DateTimeKind.Utc).AddTicks(6631), "Admin", "v1.2" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditLogs");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropColumn(
                name: "ReadAt",
                table: "Alerts");

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 19, 50, 1, 989, DateTimeKind.Utc).AddTicks(6772));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 20, 50, 1, 989, DateTimeKind.Utc).AddTicks(7092));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 20, 1, 989, DateTimeKind.Utc).AddTicks(7098));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 18, 50, 1, 989, DateTimeKind.Utc).AddTicks(7110));

            migrationBuilder.UpdateData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 5, 1, 989, DateTimeKind.Utc).AddTicks(7112));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1234));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1299));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 4,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1301));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 5,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 6,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1304));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 7,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1305));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumn: "Id",
                keyValue: 8,
                column: "UpdatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1307));

            migrationBuilder.UpdateData(
                table: "KpiSnapshots",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 992, DateTimeKind.Utc).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(6677));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8371));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8378));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8379));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8381));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8405));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8408));

            migrationBuilder.UpdateData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8409));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(7743));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "StartedAt" },
                values: new object[] { new DateTime(2026, 3, 23, 21, 50, 1, 991, DateTimeKind.Utc).AddTicks(7283), new DateTime(2026, 3, 23, 19, 50, 1, 991, DateTimeKind.Utc).AddTicks(7305) });

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 991, DateTimeKind.Utc).AddTicks(7610));

            migrationBuilder.UpdateData(
                table: "MaintenanceRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 991, DateTimeKind.Utc).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 1,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 23, 17, 50, 1, 992, DateTimeKind.Utc).AddTicks(827));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 2,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 23, 18, 50, 1, 992, DateTimeKind.Utc).AddTicks(1213));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 3,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 23, 19, 50, 1, 992, DateTimeKind.Utc).AddTicks(1217));

            migrationBuilder.UpdateData(
                table: "QualityRecords",
                keyColumn: "Id",
                keyValue: 4,
                column: "InspectedAt",
                value: new DateTime(2026, 3, 23, 20, 50, 1, 992, DateTimeKind.Utc).AddTicks(1219));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(2004));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(4614));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(4850));

            migrationBuilder.UpdateData(
                table: "WorkOrders",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(4854));
        }
    }
}
