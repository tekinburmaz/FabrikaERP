using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FabrikaERP.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    Unit = table.Column<string>(type: "TEXT", nullable: false),
                    StockQty = table.Column<double>(type: "REAL", nullable: false),
                    MinStock = table.Column<double>(type: "REAL", nullable: false),
                    MaxStock = table.Column<double>(type: "REAL", nullable: false),
                    UnitCost = table.Column<double>(type: "REAL", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true),
                    Supplier = table.Column<string>(type: "TEXT", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KpiSnapshots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Timestamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductionRate = table.Column<int>(type: "INTEGER", nullable: false),
                    OeePercent = table.Column<double>(type: "REAL", nullable: false),
                    QualityRate = table.Column<double>(type: "REAL", nullable: false),
                    ActiveMachines = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalMachines = table.Column<int>(type: "INTEGER", nullable: false),
                    ActiveAlerts = table.Column<int>(type: "INTEGER", nullable: false),
                    CompletedWorkOrders = table.Column<int>(type: "INTEGER", nullable: false),
                    PendingWorkOrders = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KpiSnapshots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Department = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    OeeTarget = table.Column<double>(type: "REAL", nullable: false),
                    OeeCurrent = table.Column<double>(type: "REAL", nullable: false),
                    LastService = table.Column<DateTime>(type: "TEXT", nullable: true),
                    NextService = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShiftName = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", nullable: false),
                    Severity = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<int>(type: "INTEGER", nullable: false),
                    IsRead = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsResolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ResolvedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ResolvedBy = table.Column<string>(type: "TEXT", nullable: true),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ScheduledAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Technician = table.Column<string>(type: "TEXT", nullable: true),
                    Cost = table.Column<double>(type: "REAL", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceRecords_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: false),
                    FullName = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShiftId = table.Column<int>(type: "INTEGER", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Shifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Shifts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderNumber = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductCode = table.Column<string>(type: "TEXT", nullable: true),
                    PlannedQty = table.Column<int>(type: "INTEGER", nullable: false),
                    ProducedQty = table.Column<int>(type: "INTEGER", nullable: false),
                    RejectedQty = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    PlannedStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PlannedEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ActualStart = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ActualEnd = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MachineId = table.Column<int>(type: "INTEGER", nullable: true),
                    AssignedUserId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WorkOrders_Users_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QualityRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Barcode = table.Column<string>(type: "TEXT", nullable: false),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Result = table.Column<int>(type: "INTEGER", nullable: false),
                    FailReason = table.Column<string>(type: "TEXT", nullable: true),
                    InspectorId = table.Column<string>(type: "TEXT", nullable: true),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    InspectedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkOrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualityRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualityRecords_WorkOrders_WorkOrderId",
                        column: x => x.WorkOrderId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Alerts",
                columns: new[] { "Id", "Category", "CreatedAt", "IsRead", "IsResolved", "MachineId", "Message", "ResolvedAt", "ResolvedBy", "Severity", "Title" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2026, 3, 23, 20, 50, 1, 989, DateTimeKind.Utc).AddTicks(7092), false, false, null, "Oluklu Mukavva Kutu stoku minimum seviyenin altına düştü.", null, null, 1, "Hammadde Stok Kritik" },
                    { 3, 5, new DateTime(2026, 3, 23, 21, 20, 1, 989, DateTimeKind.Utc).AddTicks(7098), false, false, null, "A Vardiyası 16:00'da sona eriyor. Shift geçişi hazırlanıyor.", null, null, 0, "A Vardiyası Bitiyor" },
                    { 5, 1, new DateTime(2026, 3, 23, 21, 5, 1, 989, DateTimeKind.Utc).AddTicks(7112), false, false, null, "Son 2 saatte hata oranı %1.8'e yükseldi. Kalite kontrol devreye girdi.", null, null, 1, "Kalite Anomalisi Tespit" }
                });

            migrationBuilder.InsertData(
                table: "InventoryItems",
                columns: new[] { "Id", "Category", "Code", "Description", "Location", "MaxStock", "MinStock", "Name", "StockQty", "Supplier", "Unit", "UnitCost", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 0, "HM-001", null, null, 5000.0, 500.0, "Çelik Profil 40x40", 2500.0, "MetalSan A.Ş.", "kg", 12.5, new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(9230) },
                    { 2, 0, "HM-002", null, null, 500.0, 50.0, "Alüminyum Sac 2mm", 150.0, "AlümTürk", "m²", 85.0, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1234) },
                    { 3, 0, "HM-003", null, null, 2000.0, 200.0, "Plastik Granül ABS", 800.0, "Polimer A.Ş.", "kg", 45.0, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1299) },
                    { 4, 1, "YP-001", null, null, 1000.0, 100.0, "Dişli Grubu A-12", 320.0, null, "adet", 125.0, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1301) },
                    { 5, 3, "BP-001", null, null, 50.0, 5.0, "Hidrolik Pompa Filtresi", 12.0, "HidroTek", "adet", 380.0, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1302) },
                    { 6, 3, "BP-002", null, null, 100.0, 10.0, "Rulman 6205-2RS", 48.0, "SKF Türkiye", "adet", 95.0, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1304) },
                    { 7, 4, "TK-001", null, null, 500.0, 50.0, "Kesme Yağı ISO 46", 220.0, "Mobil", "lt", 18.0, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1305) },
                    { 8, 5, "PK-001", null, null, 5000.0, 500.0, "Oluklu Mukavva Kutu", 4.0, "Karton A.Ş.", "adet", 2.5, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(1307) }
                });

            migrationBuilder.InsertData(
                table: "KpiSnapshots",
                columns: new[] { "Id", "ActiveAlerts", "ActiveMachines", "CompletedWorkOrders", "OeePercent", "PendingWorkOrders", "ProductionRate", "QualityRate", "Timestamp", "TotalMachines" },
                values: new object[] { 1, 3, 6, 2, 87.299999999999997, 3, 1247, 99.099999999999994, new DateTime(2026, 3, 23, 21, 50, 1, 992, DateTimeKind.Utc).AddTicks(2021), 8 });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "Code", "CreatedAt", "Department", "Description", "IsActive", "LastService", "Name", "NextService", "OeeCurrent", "OeeTarget", "Status" },
                values: new object[,]
                {
                    { 1, "CNC-01", new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(6677), "Üretim", null, true, null, "CNC Torna A-1", null, 87.299999999999997, 85.0, 0 },
                    { 2, "CNC-02", new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8371), "Üretim", null, true, null, "CNC Torna A-2", null, 82.099999999999994, 85.0, 0 },
                    { 3, "PRS-01", new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8378), "Presleme", null, true, null, "Pres Makinesi B-1", null, 0.0, 80.0, 2 },
                    { 4, "PRS-02", new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8379), "Presleme", null, true, null, "Pres Makinesi B-2", null, 79.5, 80.0, 0 },
                    { 5, "WLD-01", new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8381), "Kaynak", null, true, null, "Kaynak Robot C-1", null, 91.200000000000003, 90.0, 0 },
                    { 6, "WLD-02", new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8405), "Kaynak", null, true, null, "Kaynak Robot C-2", null, 0.0, 90.0, 3 },
                    { 7, "ASM-01", new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8408), "Montaj", null, true, null, "Montaj Hattı D-1", null, 84.799999999999997, 85.0, 0 },
                    { 8, "PKG-01", new DateTime(2026, 3, 23, 21, 50, 1, 988, DateTimeKind.Utc).AddTicks(8409), "Paketleme", null, true, null, "Paketleme E-1", null, 0.0, 75.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Description", "RoleName" },
                values: new object[,]
                {
                    { 1, "Sistem Yöneticisi", "Admin" },
                    { 2, "Fabrika Müdürü", "Manager" },
                    { 3, "Makine Operatörü", "Operator" },
                    { 4, "Kalite Kontrol Uzmanı", "Quality" },
                    { 5, "Bakım Teknisyeni", "Maintenance" }
                });

            migrationBuilder.InsertData(
                table: "Shifts",
                columns: new[] { "Id", "EndTime", "ShiftName", "StartTime" },
                values: new object[,]
                {
                    { 1, new TimeSpan(0, 16, 0, 0, 0), "Gündüz", new TimeSpan(0, 8, 0, 0, 0) },
                    { 2, new TimeSpan(1, 0, 0, 0, 0), "Akşam", new TimeSpan(0, 16, 0, 0, 0) },
                    { 3, new TimeSpan(0, 8, 0, 0, 0), "Gece", new TimeSpan(0, 0, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "Alerts",
                columns: new[] { "Id", "Category", "CreatedAt", "IsRead", "IsResolved", "MachineId", "Message", "ResolvedAt", "ResolvedBy", "Severity", "Title" },
                values: new object[,]
                {
                    { 1, 0, new DateTime(2026, 3, 23, 19, 50, 1, 989, DateTimeKind.Utc).AddTicks(6772), false, false, 3, "Pres Makinesi B-1 beklenmedik durma. Teknisyen çağırıldı.", null, null, 2, "Makine B-7 Ani Durdu" },
                    { 4, 0, new DateTime(2026, 3, 23, 18, 50, 1, 989, DateTimeKind.Utc).AddTicks(7110), false, false, 6, "WLD-02 elektriki arıza tespit edildi. Bakım ekibi yönlendiriliyor.", null, null, 2, "Kaynak Robot C-2 Arıza" }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceRecords",
                columns: new[] { "Id", "CompletedAt", "Cost", "CreatedAt", "Description", "MachineId", "Notes", "ScheduledAt", "StartedAt", "Status", "Technician", "Title", "Type" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(7743), null, 1, null, new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Local), null, 0, "Ahmet Yılmaz", "Periyodik Yağlama", 0 },
                    { 2, null, null, new DateTime(2026, 3, 23, 21, 50, 1, 991, DateTimeKind.Utc).AddTicks(7283), null, 6, null, new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 3, 23, 19, 50, 1, 991, DateTimeKind.Utc).AddTicks(7305), 1, "Mehmet Kaya", "Elektrik Arıza Giderme", 1 },
                    { 3, new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), 1250.0, new DateTime(2026, 3, 23, 21, 50, 1, 991, DateTimeKind.Utc).AddTicks(7610), null, 4, null, new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 3, 21, 0, 0, 0, 0, DateTimeKind.Local), 2, "Ali Demir", "Filtre Değişimi", 0 },
                    { 4, new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 3200.0, new DateTime(2026, 3, 23, 21, 50, 1, 991, DateTimeKind.Utc).AddTicks(8132), null, 3, null, new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Local), 2, "Ahmet Yılmaz", "Acil Pnömatik Tamir", 3 }
                });

            migrationBuilder.InsertData(
                table: "WorkOrders",
                columns: new[] { "Id", "ActualEnd", "ActualStart", "AssignedUserId", "CreatedAt", "MachineId", "Notes", "OrderNumber", "PlannedEnd", "PlannedQty", "PlannedStart", "ProducedQty", "ProductCode", "ProductName", "RejectedQty", "Status" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(2004), 1, null, "WO-2024-0891", new DateTime(2024, 3, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 500, new DateTime(2024, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 390, "YP-001", "Dişli Grubu A-12", 4, 1 },
                    { 2, null, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(4610), 3, null, "WO-2024-0890", new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 200, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 90, "YP-002", "Gövde Kasası B-7", 2, 2 },
                    { 3, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(4614), 5, null, "WO-2024-0889", new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, "BP-006", "Rulman Seti C-3", 9, 3 },
                    { 4, null, null, null, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(4850), 6, null, "WO-2024-0888", new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 350, new DateTime(2024, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "YP-003", "Piston Grubu D-1", 0, 5 },
                    { 5, new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2026, 3, 23, 21, 50, 1, 989, DateTimeKind.Utc).AddTicks(4854), 7, null, "WO-2024-0887", new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 250, new DateTime(2024, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 250, "FP-001", "Montaj Kiti E-2", 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "QualityRecords",
                columns: new[] { "Id", "Barcode", "FailReason", "InspectedAt", "InspectorId", "Notes", "ProductName", "Result", "WorkOrderId" },
                values: new object[,]
                {
                    { 1, "BC-2024-001", null, new DateTime(2026, 3, 23, 17, 50, 1, 992, DateTimeKind.Utc).AddTicks(827), "QC-01", null, "Dişli Grubu A-12", 0, 1 },
                    { 2, "BC-2024-002", "Çap toleransı dışı", new DateTime(2026, 3, 23, 18, 50, 1, 992, DateTimeKind.Utc).AddTicks(1213), "QC-01", null, "Dişli Grubu A-12", 1, 1 },
                    { 3, "BC-2024-003", null, new DateTime(2026, 3, 23, 19, 50, 1, 992, DateTimeKind.Utc).AddTicks(1217), "QC-02", null, "Rulman Seti C-3", 0, 3 },
                    { 4, "BC-2024-004", null, new DateTime(2026, 3, 23, 20, 50, 1, 992, DateTimeKind.Utc).AddTicks(1219), "QC-02", null, "Rulman Seti C-3", 0, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_MachineId",
                table: "Alerts",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceRecords_MachineId",
                table: "MaintenanceRecords",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_QualityRecords_WorkOrderId",
                table: "QualityRecords",
                column: "WorkOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ShiftId",
                table: "Users",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_AssignedUserId",
                table: "WorkOrders",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_MachineId",
                table: "WorkOrders",
                column: "MachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");

            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.DropTable(
                name: "KpiSnapshots");

            migrationBuilder.DropTable(
                name: "MaintenanceRecords");

            migrationBuilder.DropTable(
                name: "QualityRecords");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Shifts");
        }
    }
}
