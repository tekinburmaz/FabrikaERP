using System;

namespace FabrikaERP.Models
{
    public class ShiftSegment
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        
        /// <summary>Fazla mesai süresi (saat).</summary>
        public double OvertimeHours { get; set; }
        
        public string? Note { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
