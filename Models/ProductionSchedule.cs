using System;

namespace FabrikaERP.Models
{
    public enum ScheduleStatus
    {
        Draft,
        Confirmed,
        InProgress,
        Completed,
        Cancelled
    }

    public class ProductionSchedule
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        
        public double Quantity { get; set; }
        public DateTime TargetDate { get; set; }
        
        public int? MachineId { get; set; }
        public Machine? Machine { get; set; }
        
        public ScheduleStatus Status { get; set; } = ScheduleStatus.Draft;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
