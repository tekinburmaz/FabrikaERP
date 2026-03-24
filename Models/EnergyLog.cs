using System;

namespace FabrikaERP.Models
{
    public class EnergyLog
    {
        public int Id { get; set; }
        public int? MachineId { get; set; }
        public Machine? Machine { get; set; }
        
        /// <summary>KiloWatt-Saat cinsinden tüketim.</summary>
        public double ConsumptionKwh { get; set; }
        
        /// <summary>Anlık Watt tüketimi.</summary>
        public double InstantWattage { get; set; }
        
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
