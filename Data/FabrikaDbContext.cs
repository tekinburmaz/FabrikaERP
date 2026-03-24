using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace FabrikaERP.Data
{
    public class FabrikaDbContext : DbContext
    {
        // ── Temel ──────────────────────────────────────────
        public DbSet<User>     Users  { get; set; } = null!;
        public DbSet<Role>     Roles  { get; set; } = null!;
        public DbSet<Shift>    Shifts { get; set; } = null!;

        // ── Üretim ─────────────────────────────────────────
        public DbSet<Machine>   Machines   { get; set; } = null!;
        public DbSet<WorkOrder> WorkOrders { get; set; } = null!;
        public DbSet<ProductionSchedule> ProductionSchedules { get; set; } = null!;

        // ── Planlama & Tahmin ──────────────────────────────
        public DbSet<DemandForecast> DemandForecasts { get; set; } = null!;
        public DbSet<MaterialRequirement> MaterialRequirements { get; set; } = null!;

        // ── Kalite ─────────────────────────────────────────
        public DbSet<QualityRecord> QualityRecords { get; set; } = null!;

        // ── Stok ───────────────────────────────────────────
        public DbSet<InventoryItem> InventoryItems { get; set; } = null!;
        public DbSet<WarehouseZone> WarehouseZones { get; set; } = null!;
        public DbSet<StockMovement> StockMovements { get; set; } = null!;

        // ── Satış & CRM ──────────────────────────────────
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<SalesOrder> SalesOrders { get; set; } = null!;

        // ── Satın Alma & SRM ──────────────────────────────
        public DbSet<Supplier> Suppliers { get; set; } = null!;
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; } = null!;

        // ── Finans & Maliyet ──────────────────────────────
        public DbSet<FinanceTransaction> FinanceTransactions { get; set; } = null!;
        public DbSet<CostCenter> CostCenters { get; set; } = null!;

        // ── Bakım ──────────────────────────────────────────
        public DbSet<MaintenanceRecord> MaintenanceRecords { get; set; } = null!;

        // ── İSG & Çevre ──────────────────────────────────
        public DbSet<SafetyIncident> SafetyIncidents { get; set; } = null!;
        public DbSet<EnvironmentalImpact> EnvironmentalImpacts { get; set; } = null!;

        // ── İnsan Kaynakları ──────────────────────────────
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<ShiftSegment> ShiftSegments { get; set; } = null!;
        public DbSet<LeaveRequest> LeaveRequests { get; set; } = null!;

        // ── Verimlilik & Enerji ─────────────────────────────
        public DbSet<OeeRecord> OeeRecords { get; set; } = null!;
        public DbSet<EnergyLog> EnergyLogs { get; set; } = null!;

        // ── Genişleme Paketleri (Tier 11-35 Shells) ──────────
        public DbSet<ProductVersion>   ProductVersions   { get; set; } = null!;
        public DbSet<ComplianceRecord> ComplianceRecords { get; set; } = null!;
        public DbSet<CapacityPlan>     CapacityPlans     { get; set; } = null!;
        public DbSet<PayrollRecord>    PayrollRecords    { get; set; } = null!;
        public DbSet<BudgetPlan>       BudgetPlans       { get; set; } = null!;

        // ── R&D ───────────────────────────────────────────
        public DbSet<Project> ProjectList { get; set; } = null!;
        public DbSet<Prototype> Prototypes { get; set; } = null!;

        // ── Ürün & BOM ─────────────────────────────────────
        public DbSet<BillOfMaterial> BillOfMaterials { get; set; } = null!;
        public DbSet<BomItem> BomItems { get; set; } = null!;

        // ── Uyarılar & KPI ─────────────────────────────────
        public DbSet<Alert>       Alerts       { get; set; } = null!;
        public DbSet<KpiSnapshot> KpiSnapshots { get; set; } = null!;

        // ── Denetim & Doküman ──────────────────────────────
        public DbSet<AuditLog>  AuditLogs  { get; set; } = null!;
        public DbSet<Document>  Documents  { get; set; } = null!;

        // Aktif oturumun kullanıcısını SaveChanges içinde kullanmak için.
        // SessionManager.CurrentUser?.Username gibi bir değer atanmalı.
        public string? CurrentUserId { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // SQLite veritabanı uygulama dizininde FabrikaERP.db adıyla kullanılacak
                string dbPath = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "FabrikaERP.db");
                optionsBuilder.UseSqlite($"Data Source={dbPath}");
                optionsBuilder.ConfigureWarnings(w => w.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
            }
        }

        // ── Otomatik Audit Loglama ───────────────────────────
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var auditEntries = BuildAuditEntries();
            var result = await base.SaveChangesAsync(cancellationToken);

            // PK değerleri SaveChanges sonrası kesinleşir (Insert için)
            foreach (var (entry, log) in auditEntries.Where(e => e.log.EntityKey == "0" || e.log.EntityKey == ""))
            {
                var pk = entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey());
                if (pk != null) log.EntityKey = pk.CurrentValue?.ToString() ?? "?";
            }

            if (auditEntries.Any())
            {
                AuditLogs.AddRange(auditEntries.Select(e => e.log));
                await base.SaveChangesAsync(cancellationToken);
            }

            return result;
        }

        private List<(EntityEntry entry, AuditLog log)> BuildAuditEntries()
        {
            ChangeTracker.DetectChanges();
            var result = new List<(EntityEntry, AuditLog)>();

            foreach (var entry in ChangeTracker.Entries())
            {
                // AuditLog'un kendisini loglama
                if (entry.Entity is AuditLog) continue;

                AuditAction? action = entry.State switch
                {
                    EntityState.Added    => AuditAction.Insert,
                    EntityState.Modified => AuditAction.Update,
                    EntityState.Deleted  => AuditAction.Delete,
                    _                    => null
                };

                if (action == null) continue;

                var log = new AuditLog
                {
                    UserId     = CurrentUserId,
                    EntityName = entry.Entity.GetType().Name,
                    EntityKey  = entry.Properties.FirstOrDefault(p => p.Metadata.IsPrimaryKey())?.CurrentValue?.ToString() ?? "0",
                    Action     = action.Value,
                    ChangedAt  = DateTime.UtcNow
                };

                if (action == AuditAction.Update || action == AuditAction.Delete)
                    log.OldValues = JsonSerializer.Serialize(
                        entry.Properties.ToDictionary(p => p.Metadata.Name, p => p.OriginalValue));

                if (action == AuditAction.Insert || action == AuditAction.Update)
                    log.NewValues = JsonSerializer.Serialize(
                        entry.Properties.ToDictionary(p => p.Metadata.Name, p => p.CurrentValue));

                result.Add((entry, log));
            }

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ── Seed: Roller ───────────────────────────────
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin",    Description = "Sistem Yöneticisi" },
                new Role { Id = 2, RoleName = "Manager",  Description = "Fabrika Müdürü" },
                new Role { Id = 3, RoleName = "Operator", Description = "Makine Operatörü" },
                new Role { Id = 4, RoleName = "Quality",  Description = "Kalite Kontrol Uzmanı" },
                new Role { Id = 5, RoleName = "Maintenance", Description = "Bakım Teknisyeni" }
            );

            // ── Seed: Vardiyalar ───────────────────────────
            modelBuilder.Entity<Shift>().HasData(
                new Shift { Id = 1, ShiftName = "Gündüz", StartTime = new TimeSpan(8,  0, 0), EndTime = new TimeSpan(16, 0, 0) },
                new Shift { Id = 2, ShiftName = "Akşam",  StartTime = new TimeSpan(16, 0, 0), EndTime = new TimeSpan(24, 0, 0) },
                new Shift { Id = 3, ShiftName = "Gece",   StartTime = new TimeSpan(0,  0, 0), EndTime = new TimeSpan(8,  0, 0) }
            );

            // ── Seed: Kullanıcılar ─────────────────────────
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin",   PasswordHash = "admin",   FullName = "Sistem Yöneticisi", RoleId = 1, IsActive = true, CreatedAt = DateTime.UtcNow },
                new User { Id = 2, Username = "manager", PasswordHash = "manager", FullName = "Fabrika Müdürü",    RoleId = 2, IsActive = true, CreatedAt = DateTime.UtcNow },
                new User { Id = 3, Username = "operator",PasswordHash = "operator",FullName = "Hattı Operatörü",   RoleId = 3, IsActive = true, CreatedAt = DateTime.UtcNow }
            );

            // ── Seed: Makineler ────────────────────────────
            modelBuilder.Entity<Machine>().HasData(
                new Machine { Id = 1, Code = "CNC-01", Name = "CNC Torna A-1",     Department = "Üretim",    Status = MachineStatus.Running,     OeeTarget = 85, OeeCurrent = 87.3 },
                new Machine { Id = 2, Code = "CNC-02", Name = "CNC Torna A-2",     Department = "Üretim",    Status = MachineStatus.Running,     OeeTarget = 85, OeeCurrent = 82.1 },
                new Machine { Id = 3, Code = "PRS-01", Name = "Pres Makinesi B-1", Department = "Presleme",  Status = MachineStatus.Maintenance, OeeTarget = 80, OeeCurrent = 0    },
                new Machine { Id = 4, Code = "PRS-02", Name = "Pres Makinesi B-2", Department = "Presleme",  Status = MachineStatus.Running,     OeeTarget = 80, OeeCurrent = 79.5 },
                new Machine { Id = 5, Code = "WLD-01", Name = "Kaynak Robot C-1",  Department = "Kaynak",    Status = MachineStatus.Running,     OeeTarget = 90, OeeCurrent = 91.2 },
                new Machine { Id = 6, Code = "WLD-02", Name = "Kaynak Robot C-2",  Department = "Kaynak",    Status = MachineStatus.Breakdown,   OeeTarget = 90, OeeCurrent = 0    },
                new Machine { Id = 7, Code = "ASM-01", Name = "Montaj Hattı D-1",  Department = "Montaj",    Status = MachineStatus.Running,     OeeTarget = 85, OeeCurrent = 84.8 },
                new Machine { Id = 8, Code = "PKG-01", Name = "Paketleme E-1",     Department = "Paketleme", Status = MachineStatus.Idle,        OeeTarget = 75, OeeCurrent = 0    }
            );

            // ── Seed: Stok kalemleri ───────────────────────
            modelBuilder.Entity<InventoryItem>().HasData(
                new InventoryItem { Id = 1, Code = "HM-001", Name = "Çelik Profil 40x40",   Category = InventoryCategory.RawMaterial,  Unit = "kg",   StockQty = 2500, MinStock = 500,  MaxStock = 5000, UnitCost = 12.50, Supplier = "MetalSan A.Ş.", WarehouseZoneId = 1 },
                new InventoryItem { Id = 2, Code = "HM-002", Name = "Alüminyum Sac 2mm",    Category = InventoryCategory.RawMaterial,  Unit = "m²",   StockQty = 150,  MinStock = 50,   MaxStock = 500,  UnitCost = 85.00, Supplier = "AlümTürk",     WarehouseZoneId = 1 },
                new InventoryItem { Id = 3, Code = "HM-003", Name = "Plastik Granül ABS",   Category = InventoryCategory.RawMaterial,  Unit = "kg",   StockQty = 800,  MinStock = 200,  MaxStock = 2000, UnitCost = 45.00, Supplier = "Polimer A.Ş.", WarehouseZoneId = 1 },
                new InventoryItem { Id = 4, Code = "YP-001", Name = "Dişli Grubu A-12",     Category = InventoryCategory.SemiFinished, Unit = "adet", StockQty = 320,  MinStock = 100,  MaxStock = 1000, UnitCost = 125.0, Supplier = null,           WarehouseZoneId = 2 },
                new InventoryItem { Id = 5, Code = "BP-001", Name = "Hidrolik Pompa Filtresi", Category = InventoryCategory.SparePart, Unit = "adet", StockQty = 12,   MinStock = 5,    MaxStock = 50,   UnitCost = 380.0, Supplier = "HidroTek",     WarehouseZoneId = 1 },
                new InventoryItem { Id = 6, Code = "BP-002", Name = "Rulman 6205-2RS",      Category = InventoryCategory.SparePart,    Unit = "adet", StockQty = 48,   MinStock = 10,   MaxStock = 100,  UnitCost = 95.00, Supplier = "SKF Türkiye",  WarehouseZoneId = 1 },
                new InventoryItem { Id = 7, Code = "TK-001", Name = "Kesme Yağı ISO 46",    Category = InventoryCategory.Consumable,   Unit = "lt",   StockQty = 220,  MinStock = 50,   MaxStock = 500,  UnitCost = 18.00, Supplier = "Mobil",        WarehouseZoneId = 1 },
                new InventoryItem { Id = 8, Code = "PK-001", Name = "Oluklu Mukavva Kutu",  Category = InventoryCategory.Packaging,    Unit = "adet", StockQty = 4,    MinStock = 500,  MaxStock = 5000, UnitCost = 2.50,  Supplier = "Karton A.Ş.",  WarehouseZoneId = 1 }
            );

            // ── Seed: İş emirleri ──────────────────────────
            modelBuilder.Entity<WorkOrder>().HasData(
                new WorkOrder { Id = 1, OrderNumber = "WO-2024-0891", ProductName = "Dişli Grubu A-12",  ProductCode = "YP-001", PlannedQty = 500, ProducedQty = 390, RejectedQty = 4,  Status = WorkOrderStatus.InProgress, PlannedStart = new DateTime(2024,3,20), PlannedEnd = new DateTime(2024,3,23), ActualStart = new DateTime(2024,3,20), MachineId = 1 },
                new WorkOrder { Id = 2, OrderNumber = "WO-2024-0890", ProductName = "Gövde Kasası B-7",  ProductCode = "YP-002", PlannedQty = 200, ProducedQty = 90,  RejectedQty = 2,  Status = WorkOrderStatus.OnHold,     PlannedStart = new DateTime(2024,3,21), PlannedEnd = new DateTime(2024,3,24), ActualStart = new DateTime(2024,3,21), MachineId = 3 },
                new WorkOrder { Id = 3, OrderNumber = "WO-2024-0889", ProductName = "Rulman Seti C-3",   ProductCode = "BP-006", PlannedQty = 1000,ProducedQty = 1000,RejectedQty = 9,  Status = WorkOrderStatus.Completed,  PlannedStart = new DateTime(2024,3,18), PlannedEnd = new DateTime(2024,3,22), ActualStart = new DateTime(2024,3,18), ActualEnd = new DateTime(2024,3,22), MachineId = 5 },
                new WorkOrder { Id = 4, OrderNumber = "WO-2024-0888", ProductName = "Piston Grubu D-1",  ProductCode = "YP-003", PlannedQty = 350, ProducedQty = 0,   RejectedQty = 0,  Status = WorkOrderStatus.Delayed,    PlannedStart = new DateTime(2024,3,22), PlannedEnd = new DateTime(2024,3,25), MachineId = 6 },
                new WorkOrder { Id = 5, OrderNumber = "WO-2024-0887", ProductName = "Montaj Kiti E-2",   ProductCode = "FP-001", PlannedQty = 250, ProducedQty = 250, RejectedQty = 1,  Status = WorkOrderStatus.Completed,  PlannedStart = new DateTime(2024,3,17), PlannedEnd = new DateTime(2024,3,21), ActualStart = new DateTime(2024,3,17), ActualEnd = new DateTime(2024,3,21), MachineId = 7 }
            );

            // ── Seed: Uyarılar ─────────────────────────────
            modelBuilder.Entity<Alert>().HasData(
                new Alert { Id = 1, Title = "Makine B-7 Ani Durdu",        Message = "Pres Makinesi B-1 beklenmedik durma. Teknisyen çağırıldı.", Severity = AlertSeverity.Critical, Category = AlertCategory.Machine,    MachineId = 3, CreatedAt = DateTime.UtcNow.AddHours(-2) },
                new Alert { Id = 2, Title = "Hammadde Stok Kritik",        Message = "Oluklu Mukavva Kutu stoku minimum seviyenin altına düştü.", Severity = AlertSeverity.Warning,  Category = AlertCategory.Inventory,  CreatedAt = DateTime.UtcNow.AddHours(-1) },
                new Alert { Id = 3, Title = "A Vardiyası Bitiyor",         Message = "A Vardiyası 16:00'da sona eriyor. Shift geçişi hazırlanıyor.", Severity = AlertSeverity.Info,     Category = AlertCategory.System,     CreatedAt = DateTime.UtcNow.AddMinutes(-30) },
                new Alert { Id = 4, Title = "Kaynak Robot C-2 Arıza",      Message = "WLD-02 elektriki arıza tespit edildi. Bakım ekibi yönlendiriliyor.", Severity = AlertSeverity.Critical, Category = AlertCategory.Machine, MachineId = 6, CreatedAt = DateTime.UtcNow.AddHours(-3) },
                new Alert { Id = 5, Title = "Kalite Anomalisi Tespit",     Message = "Son 2 saatte hata oranı %1.8'e yükseldi. Kalite kontrol devreye girdi.", Severity = AlertSeverity.Warning, Category = AlertCategory.Quality, CreatedAt = DateTime.UtcNow.AddMinutes(-45) }
            );

            // ── Seed: Bakım kayıtları ──────────────────────
            modelBuilder.Entity<MaintenanceRecord>().HasData(
                new MaintenanceRecord { Id = 1, Type = MaintenanceType.Preventive, Status = MaintenanceStatus.Scheduled,  Title = "Periyodik Yağlama",     MachineId = 1, ScheduledAt = DateTime.Today.AddDays(2),  Technician = "Ahmet Yılmaz" },
                new MaintenanceRecord { Id = 2, Type = MaintenanceType.Corrective, Status = MaintenanceStatus.InProgress, Title = "Elektrik Arıza Giderme", MachineId = 6, ScheduledAt = DateTime.Today,             Technician = "Mehmet Kaya", StartedAt = DateTime.UtcNow.AddHours(-2) },
                new MaintenanceRecord { Id = 3, Type = MaintenanceType.Preventive, Status = MaintenanceStatus.Completed,  Title = "Filtre Değişimi",        MachineId = 4, ScheduledAt = DateTime.Today.AddDays(-3), Technician = "Ali Demir",   StartedAt = DateTime.Today.AddDays(-3), CompletedAt = DateTime.Today.AddDays(-3), Cost = 1250 },
                new MaintenanceRecord { Id = 4, Type = MaintenanceType.Emergency,  Status = MaintenanceStatus.Completed,  Title = "Acil Pnömatik Tamir",    MachineId = 3, ScheduledAt = DateTime.Today.AddDays(-1), Technician = "Ahmet Yılmaz",StartedAt = DateTime.Today.AddDays(-1), CompletedAt = DateTime.Today.AddDays(-1), Cost = 3200 }
            );

            // ── Seed: Kalite kayıtları ─────────────────────
            modelBuilder.Entity<QualityRecord>().HasData(
                new QualityRecord { Id = 1, Barcode = "BC-2024-001", ProductName = "Dişli Grubu A-12", Result = QualityResult.Pass, InspectorId = "QC-01", WorkOrderId = 1, InspectedAt = DateTime.UtcNow.AddHours(-4) },
                new QualityRecord { Id = 2, Barcode = "BC-2024-002", ProductName = "Dişli Grubu A-12", Result = QualityResult.Fail, FailReason = "Çap toleransı dışı", InspectorId = "QC-01", WorkOrderId = 1, InspectedAt = DateTime.UtcNow.AddHours(-3) },
                new QualityRecord { Id = 3, Barcode = "BC-2024-003", ProductName = "Rulman Seti C-3",  Result = QualityResult.Pass, InspectorId = "QC-02", WorkOrderId = 3, InspectedAt = DateTime.UtcNow.AddHours(-2) },
                new QualityRecord { Id = 4, Barcode = "BC-2024-004", ProductName = "Rulman Seti C-3",  Result = QualityResult.Pass, InspectorId = "QC-02", WorkOrderId = 3, InspectedAt = DateTime.UtcNow.AddHours(-1) }
            );

            // ── Seed: KPI Snapshot ─────────────────────────
            modelBuilder.Entity<KpiSnapshot>().HasData(
                new KpiSnapshot { Id = 1, Timestamp = DateTime.UtcNow, ProductionRate = 1247, OeePercent = 87.3, QualityRate = 99.1, ActiveMachines = 6, TotalMachines = 8, ActiveAlerts = 3, CompletedWorkOrders = 2, PendingWorkOrders = 3 }
            );

            // ── Seed: Dokümanlar ───────────────────────────
            modelBuilder.Entity<Document>().HasData(
                new Document { Id = 1, Code = "DOC-MAN-001", Title = "CNC Torna A-1 Kullanım Kılavuzu",    Type = DocumentType.MachinManual,    Version = "v2.1", Department = "Üretim",   MachineCode = "CNC-01", FilePath = "", FileExtension = "PDF", UploadedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Document { Id = 2, Code = "DOC-ISO-001", Title = "ISO 9001:2015 Kalite Prosedürü",     Type = DocumentType.IsoDocument,      Version = "v3.0", Department = "Kalite",  FilePath = "", FileExtension = "PDF", ExpiryDate = new DateTime(2025,12,31), UploadedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Document { Id = 3, Code = "DOC-SAF-001", Title = "Makine Güvenlik Prosedürü",          Type = DocumentType.SafetyProcedure, Version = "v1.5", Department = "Güvenlik", FilePath = "", FileExtension = "PDF", UploadedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Document { Id = 4, Code = "DOC-WI-001",  Title = "Kaynak Robotu Operasyon Talimatı",  Type = DocumentType.WorkInstruction, Version = "v1.0", Department = "Kaynak",  MachineCode = "WLD-01", FilePath = "", FileExtension = "DOCX", UploadedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow },
                new Document { Id = 5, Code = "DOC-FRM-001", Title = "Günlük Bakım Kontrol Formu",        Type = DocumentType.FormTemplate,    Version = "v1.2", Department = "Bakım",   FilePath = "", FileExtension = "XLSX", UploadedBy = "Admin", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow }
            );

            // ── Seed: R&D Projeleri ──────────────────────────
            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Code = "PRJ-24-001", Name = "Yeni Nesil Elektrikli Motor", Status = ProjectStatus.Development, StartDate = new DateTime(2024, 1, 1), Manager = "Ar-Ge Müdürü", Budget = 1500000 },
                new Project { Id = 2, Code = "PRJ-24-002", Name = "Akıllı Sensör Entegrasyonu", Status = ProjectStatus.Prototyping, StartDate = new DateTime(2024, 2, 15), Manager = "Sistem Mühendisi", Budget = 450000 }
            );

            // ── Seed: Prototipler ──────────────────────────
            modelBuilder.Entity<Prototype>().HasData(
                new Prototype { Id = 1, ProjectId = 1, Code = "PRT-EM-01", Name = "V1 Motor Prototipi", Status = PrototypeStatus.Validated, Version = "v1.2" },
                new Prototype { Id = 2, ProjectId = 1, Code = "PRT-EM-02", Name = "V2 Yüksek Torklu Motor", Status = PrototypeStatus.Manufacturing, Version = "v2.0" },
                new Prototype { Id = 3, ProjectId = 2, Code = "PRT-SN-01", Name = "Sıcaklık Sensör Modülü", Status = PrototypeStatus.Testing, Version = "v1.0" }
            );

            // ── Seed: BOM ──────────────────────────────────
            modelBuilder.Entity<BillOfMaterial>().HasData(
                new BillOfMaterial { Id = 1, ProductCode = "YP-001", ProductName = "Dişli Grubu A-12", Version = "1.0", IsActive = true }
            );

            modelBuilder.Entity<BomItem>().HasData(
                new BomItem { Id = 1, BillOfMaterialId = 1, MaterialCode = "HM-001", MaterialName = "Çelik Profil 40x40", Quantity = 2.5, Unit = "kg" },
                new BomItem { Id = 2, BillOfMaterialId = 1, MaterialCode = "BP-002", MaterialName = "Rulman 6205-2RS", Quantity = 2, Unit = "adet" }
            );

            // ── Seed: Üretim Planları (MPS) ───────────────────
            modelBuilder.Entity<ProductionSchedule>().HasData(
                new ProductionSchedule { Id = 1, OrderNumber = "MPS-2024-001", ProductCode = "YP-001", ProductName = "Dişli Grubu A-12", Quantity = 500, TargetDate = DateTime.Today.AddDays(7), Status = ScheduleStatus.Confirmed, MachineId = 1 },
                new ProductionSchedule { Id = 2, OrderNumber = "MPS-2024-002", ProductCode = "YP-002", ProductName = "Gövde Kasası B-7", Quantity = 200, TargetDate = DateTime.Today.AddDays(10), Status = ScheduleStatus.Draft, MachineId = 3 }
            );

            // ── Seed: Tahminler ──────────────────────────────
            modelBuilder.Entity<DemandForecast>().HasData(
                new DemandForecast { Id = 1, ProductCode = "YP-001", ProductName = "Dişli Grubu A-12", ForecastedQty = 1200, Period = new DateTime(2024, 4, 1), Reliability = 0.85 },
                new DemandForecast { Id = 2, ProductCode = "YP-002", ProductName = "Gövde Kasası B-7", ForecastedQty = 450, Period = new DateTime(2024, 4, 1), Reliability = 0.75 }
            );

            // ── Seed: OEE Kayıtları ─────────────────────────
            modelBuilder.Entity<OeeRecord>().HasData(
                new OeeRecord { Id = 1, MachineId = 1, Availability = 0.95, Performance = 0.92, Quality = 0.99, Timestamp = DateTime.UtcNow.AddHours(-1) },
                new OeeRecord { Id = 2, MachineId = 2, Availability = 0.88, Performance = 0.94, Quality = 0.98, Timestamp = DateTime.UtcNow.AddHours(-1) },
                new OeeRecord { Id = 3, MachineId = 4, Availability = 0.92, Performance = 0.89, Quality = 0.97, Timestamp = DateTime.UtcNow.AddHours(-1) }
            );

            // ── Seed: Enerji Logları ─────────────────────────
            modelBuilder.Entity<EnergyLog>().HasData(
                new EnergyLog { Id = 1, MachineId = 1, ConsumptionKwh = 12.5, InstantWattage = 4500, Timestamp = DateTime.UtcNow.AddMinutes(-30) },
                new EnergyLog { Id = 2, MachineId = 2, ConsumptionKwh = 8.2,  InstantWattage = 3200, Timestamp = DateTime.UtcNow.AddMinutes(-30) },
                new EnergyLog { Id = 3, MachineId = 5, ConsumptionKwh = 15.7, InstantWattage = 5800, Timestamp = DateTime.UtcNow.AddMinutes(-30) }
            );

            // ── Seed: Depo Bölgeleri ─────────────────────────
            modelBuilder.Entity<WarehouseZone>().HasData(
                new WarehouseZone { Id = 1, Code = "RM-A1", Name = "Hammadde Depo A-1", Type = ZoneType.RawMaterial, MaxCapacity = 5000, CurrentOccupancy = 2500 },
                new WarehouseZone { Id = 2, Code = "WIP-01", Name = "Ara Mamul İstasyonu 1", Type = ZoneType.WIP, MaxCapacity = 1000, CurrentOccupancy = 320 },
                new WarehouseZone { Id = 3, Code = "FG-01", Name = "Bitmiş Ürün Deposu", Type = ZoneType.FinishedGoods, MaxCapacity = 2000, CurrentOccupancy = 150 }
            );

            // ── Seed: İSG Kayıtları ─────────────────────────
            modelBuilder.Entity<SafetyIncident>().HasData(
                new SafetyIncident { Id = 1, Title = "Ramak Kala: Forklift Geçişi", Description = "B-Blok geçişinde forklift yaya yoluna çok yaklaştı.", Severity = IncidentSeverity.NearMiss, IncidentDate = DateTime.Now.AddDays(-2), Location = "Depo Girişi", ReportedBy = "Ismail Depo", IsClosed = true },
                new SafetyIncident { Id = 2, Title = "Küçük Yaralanma: El Kesilmesi", Description = "Paketleme sırasında kağıt kesiği oluştu.", Severity = IncidentSeverity.Minor, IncidentDate = DateTime.Now.AddDays(-1), Location = "Paketleme Hattı", ReportedBy = "Ayşe Paket", IsClosed = false }
            );

            // ── Seed: Çevresel Etkiler ───────────────────────
            modelBuilder.Entity<EnvironmentalImpact>().HasData(
                new EnvironmentalImpact { Id = 1, Type = ImpactType.Waste, Description = "Metal Çapağı", Value = 120, Unit = "kg", RecordedAt = DateTime.Now.AddDays(-1), Location = "CNC Atölyesi", LegalLimit = 1000 },
                new EnvironmentalImpact { Id = 2, Type = ImpactType.Emission, Description = "CO2 Salınımı (Tahmini)", Value = 450, Unit = "ton", RecordedAt = DateTime.Now.AddDays(-30), Location = "Tesis Geneli", LegalLimit = 10000 }
            );

            // ── Seed: Personel ──────────────────────────────
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, EmployeeCode = "EMP-001", FirstName = "Ahmet", LastName = "Yılmaz", Department = "Üretim", JobTitle = "Hattı Şefi", Salary = 45000, HireDate = new DateTime(2020, 5, 10), Status = EmployeeStatus.Active, UserId = 1 },
                new Employee { Id = 2, EmployeeCode = "EMP-002", FirstName = "Mehmet", LastName = "Demir", Department = "Bakım", JobTitle = "Teknisyen", Salary = 38000, HireDate = new DateTime(2021, 2, 15), Status = EmployeeStatus.Active },
                new Employee { Id = 3, EmployeeCode = "EMP-003", FirstName = "Ayşe", LastName = "Kaya", Department = "Kalite", JobTitle = "Mühendis", Salary = 52000, HireDate = new DateTime(2019, 11, 1), Status = EmployeeStatus.Active, UserId = 2 }
            );

            // ── Seed: İzin Talepleri ────────────────────────
            modelBuilder.Entity<LeaveRequest>().HasData(
                new LeaveRequest { Id = 1, EmployeeId = 1, Type = LeaveType.Annual, StartDate = DateTime.Now.AddDays(10), EndDate = DateTime.Now.AddDays(15), Reason = "Yaz Tatili", Status = LeaveStatus.Approved, ApprovedBy = "Admin" },
                new LeaveRequest { Id = 2, EmployeeId = 2, Type = LeaveType.Sick, StartDate = DateTime.Now.AddDays(-2), EndDate = DateTime.Now.AddDays(-1), Reason = "Grip", Status = LeaveStatus.Approved, ApprovedBy = "Admin" }
            );

            // ── Seed: Müşteriler ───────────────────────────
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Code = "CUS-001", Name = "Mega Insaat Ltd.", CompanyName = "Mega İnşaat ve Sanayi Limited Şirketi", TaxNumber = "1234567890", TaxOffice = "Boğaziçi", ContactPerson = "Ali Mega", Email = "info@megainsaat.com", Phone = "0212 555 44 33", Address = "İstanbul, Türkiye" },
                new Customer { Id = 2, Code = "CUS-002", Name = "Solar Enerji A.S.", CompanyName = "Solar Enerji Sistemleri Anonim Şirketi", TaxNumber = "0987654321", TaxOffice = "Ankara", ContactPerson = "Can Güneş", Email = "satis@solarenerji.com", Phone = "0312 444 33 22", Address = "Ankara, Türkiye" }
            );

            // ── Seed: Satış Siparişleri ─────────────────────
            modelBuilder.Entity<SalesOrder>().HasData(
                new SalesOrder { Id = 1, OrderNumber = "SO-2024-001", CustomerId = 1, ProductCode = "YP-001", ProductName = "Dişli Grubu A-12", Quantity = 1000, UnitPrice = 150, RequestedDeliveryDate = DateTime.Today.AddDays(30), Status = SalesOrderStatus.Confirmed },
                new SalesOrder { Id = 2, OrderNumber = "SO-2024-002", CustomerId = 2, ProductCode = "FP-001", ProductName = "Montaj Kiti E-2", Quantity = 500, UnitPrice = 280, RequestedDeliveryDate = DateTime.Today.AddDays(45), Status = SalesOrderStatus.Draft }
            );

            // ── Seed: Tedarikçiler ─────────────────────────
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { Id = 1, Code = "SUP-001", Name = "MetalSan A.S.", CompanyName = "Metal Sanayi Ticaret Anonim Şirketi", TaxNumber = "5556667778", TaxOffice = "Gebze", ContactPerson = "Zeki Demir", Email = "info@metalsan.com", Phone = "0262 333 22 11", Category = "Hammadde", PerformanceScore = 95 },
                new Supplier { Id = 2, Code = "SUP-002", Name = "Polimer Kimya", CompanyName = "Polimer Sanayi Limited Şirketi", TaxNumber = "1112223334", TaxOffice = "Tuzla", ContactPerson = "Mert Plastik", Email = "satis@polimer.com", Phone = "0216 444 55 66", Category = "Kimyasal", PerformanceScore = 88 }
            );

            // ── Seed: Satın Alma Siparişleri ────────────────
            modelBuilder.Entity<PurchaseOrder>().HasData(
                new PurchaseOrder { Id = 1, OrderNumber = "PO-2024-001", SupplierId = 1, ProductCode = "HM-001", ProductName = "Çelik Profil 40x40", Quantity = 5000, UnitPrice = 10.5, ExpectedDate = DateTime.Today.AddDays(15), Status = PurchaseOrderStatus.SentToSupplier },
                new PurchaseOrder { Id = 2, OrderNumber = "PO-2024-002", SupplierId = 2, ProductCode = "HM-003", ProductName = "Plastik Granül ABS", Quantity = 2000, UnitPrice = 42, ExpectedDate = DateTime.Today.AddDays(20), Status = PurchaseOrderStatus.Draft }
            );

            // ── Seed: Masraf Merkezleri ─────────────────────
            modelBuilder.Entity<CostCenter>().HasData(
                new CostCenter { Id = 1, Code = "CC-PROD", Name = "Üretim Departmanı", Department = "Üretim", Manager = "Üretim Md.", Budget = 5000000, ActualCost = 1250000 },
                new CostCenter { Id = 2, Code = "CC-RND",  Name = "Ar-Ge Merkezi",      Department = "Ar-Ge",  Manager = "Ar-Ge Md.",   Budget = 2000000, ActualCost = 450000 },
                new CostCenter { Id = 3, Code = "CC-QA",   Name = "Kalite Kontrol",     Department = "Kalite", Manager = "Kalite Md.", Budget = 800000,  ActualCost = 210000 }
            );

            // ── Seed: Finansal İşlemler ─────────────────────
            modelBuilder.Entity<FinanceTransaction>().HasData(
                new FinanceTransaction { Id = 1, TransactionNumber = "TR-001", Type = TransactionType.Receipt, Status = TransactionStatus.Completed, Amount = 150000, Description = "Sipariş SO-2024-001 Ön Ödemesi", CustomerId = 1, TransactionDate = DateTime.Today.AddDays(-5) },
                new FinanceTransaction { Id = 2, TransactionNumber = "TR-002", Type = TransactionType.Payment, Status = TransactionStatus.Pending,   Amount = 52500,  Description = "Hammadde Alımı PO-2024-001 Ödemesi", SupplierId = 1, TransactionDate = DateTime.Today.AddDays(1) }
            );
        }
    }
}
