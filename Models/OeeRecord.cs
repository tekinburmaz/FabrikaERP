using System;

namespace FabrikaERP.Models
{
    public class OeeRecord
    {
        public int Id { get; set; }
        public int MachineId { get; set; }
        public Machine? Machine { get; set; }
        
        public double Availability { get; set; }
        public double Performance { get; set; }
        public double Quality { get; set; }
        
        /// <summary>OEE = A * P * Q</summary>
        public double OverallEffectiveness => Availability * Performance * Quality;
        
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
