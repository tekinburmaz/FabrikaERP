namespace FabrikaERP.Models
{
    public enum WorkOrderStatus
    {
        Planned,
        InProgress,
        OnHold,
        Completed,
        Cancelled,
        Delayed
    }

    public class WorkOrder
    {
        public int             Id           { get; set; }
        public string          OrderNumber  { get; set; } = string.Empty;
        public string          ProductName  { get; set; } = string.Empty;
        public string?         ProductCode  { get; set; }
        public int             PlannedQty   { get; set; }
        public int             ProducedQty  { get; set; }
        public int             RejectedQty  { get; set; }
        public WorkOrderStatus Status       { get; set; } = WorkOrderStatus.Planned;
        public DateTime        PlannedStart { get; set; }
        public DateTime        PlannedEnd   { get; set; }
        public DateTime?       ActualStart  { get; set; }
        public DateTime?       ActualEnd    { get; set; }
        public string?         Notes        { get; set; }
        public DateTime        CreatedAt    { get; set; } = DateTime.UtcNow;

        public int?    MachineId  { get; set; }
        public Machine? Machine   { get; set; }

        public int?  AssignedUserId { get; set; }
        public User? AssignedUser   { get; set; }

        public double ProgressPercent =>
            PlannedQty == 0 ? 0 : Math.Min(100, (ProducedQty / (double)PlannedQty) * 100);
    }
}
