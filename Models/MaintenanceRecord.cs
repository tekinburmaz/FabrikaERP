namespace FabrikaERP.Models
{
    public enum MaintenanceType
    {
        Preventive,
        Corrective,
        Predictive,
        Emergency
    }

    public enum MaintenanceStatus
    {
        Scheduled,
        InProgress,
        Completed,
        Cancelled
    }

    public class MaintenanceRecord
    {
        public int               Id          { get; set; }
        public MaintenanceType   Type        { get; set; } = MaintenanceType.Preventive;
        public MaintenanceStatus Status      { get; set; } = MaintenanceStatus.Scheduled;
        public string            Title       { get; set; } = string.Empty;
        public string?           Description { get; set; }
        public DateTime          ScheduledAt { get; set; }
        public DateTime?         StartedAt   { get; set; }
        public DateTime?         CompletedAt { get; set; }
        public string?           Technician  { get; set; }
        public double?           Cost        { get; set; }
        public string?           Notes       { get; set; }
        public DateTime          CreatedAt   { get; set; } = DateTime.UtcNow;

        public int?    MachineId { get; set; }
        public Machine? Machine  { get; set; }
    }
}
