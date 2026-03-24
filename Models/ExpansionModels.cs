using System;
using System.ComponentModel.DataAnnotations;

namespace FabrikaERP.Models
{
    // ── PLM (Product Lifecycle Management) ──────────────────
    public class ProductVersion
    {
        public int Id { get; set; }
        public int ProductId { get; set; } // InventoryItem Id
        public string VersionNumber { get; set; } = "1.0.0";
        public string ChangeLogs { get; set; } = string.Empty;
        public DateTime ReleaseDate { get; set; }
        public bool IsActive { get; set; }
    }

    // ── QMS (Quality Management System) ─────────────────────
    public enum ComplianceType { ISO9001, ISO14001, OHSAS18001, Custom }
    public class ComplianceRecord
    {
        public int Id { get; set; }
        public ComplianceType Type { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime AuditDate { get; set; }
        public string AuditorName { get; set; } = string.Empty;
        public string ResultSummary { get; set; } = string.Empty;
        public string? CertificatePath { get; set; }
    }

    // ── Planning (Expanding Tier 3) ────────────────────────
    public class CapacityPlan
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public double AvailableHours { get; set; }
        public double PlannedHours { get; set; }
        public DateTime WeekStarting { get; set; }
        public double UtilizationRate => AvailableHours > 0 ? (PlannedHours / AvailableHours) * 100 : 0;
    }

    // ── HR Extended (Payroll) ────────────────────────────────
    public class PayrollRecord
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime Period { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal TaxDeductions { get; set; }
        public decimal NetPay => BaseSalary + Bonus - TaxDeductions;
        public bool IsPaid { get; set; }
    }

    // ── Finance Detay (Budget) ──────────────────────────────
    public class BudgetPlan
    {
        public int Id { get; set; }
        public string Department { get; set; } = string.Empty;
        public int FiscalYear { get; set; }
        public decimal AllocatedAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public string Currency { get; set; } = "TRY";
    }
}
