namespace FabrikaERP.Models
{
    public enum MachineStatus
    {
        Running,
        Idle,
        Maintenance,
        Breakdown,
        Setup
    }

    public class Machine
    {
        public int           Id           { get; set; }
        public string        Code         { get; set; } = string.Empty;
        public string        Name         { get; set; } = string.Empty;
        public string?       Description  { get; set; }
        public string?       Department   { get; set; }
        public MachineStatus Status       { get; set; } = MachineStatus.Idle;
        public double        OeeTarget    { get; set; } = 85.0;
        public double        OeeCurrent   { get; set; } = 0.0;
        public DateTime?     LastService  { get; set; }
        public DateTime?     NextService  { get; set; }
        public bool          IsActive     { get; set; } = true;
        public DateTime      CreatedAt    { get; set; } = DateTime.UtcNow;

        public ICollection<WorkOrder>         WorkOrders         { get; set; } = new List<WorkOrder>();
        public ICollection<MaintenanceRecord> MaintenanceRecords { get; set; } = new List<MaintenanceRecord>();
    }
}
