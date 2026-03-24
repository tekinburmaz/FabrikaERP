namespace FabrikaERP.Models
{
    public enum AlertSeverity
    {
        Info,
        Warning,
        Critical
    }

    public enum AlertCategory
    {
        Machine,
        Quality,
        Inventory,
        Safety,
        Maintenance,
        System
    }

    public class Alert
    {
        public int           Id          { get; set; }
        public string        Title       { get; set; } = string.Empty;
        public string        Message     { get; set; } = string.Empty;
        public AlertSeverity Severity    { get; set; } = AlertSeverity.Info;
        public AlertCategory Category   { get; set; } = AlertCategory.System;
        public bool          IsRead      { get; set; } = false;
        public bool          IsResolved  { get; set; } = false;
        public DateTime      CreatedAt   { get; set; } = DateTime.UtcNow;
        public DateTime?     ReadAt      { get; set; }
        public DateTime?     ResolvedAt  { get; set; }
        public string?       ResolvedBy  { get; set; }
        public int?          MachineId   { get; set; }
        public Machine?      Machine     { get; set; }
    }
}
