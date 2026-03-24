using System;

namespace FabrikaERP.Models
{
    public enum ImpactType
    {
        Waste,     // Atık
        Emission,  // Emisyon
        WaterUse,  // Su kullanımı
        Chemical   // Kimyasal sızıntı/kullanım
    }

    public class EnvironmentalImpact
    {
        public int Id { get; set; }
        public ImpactType Type { get; set; }
        public string Description { get; set; } = string.Empty;
        
        public double Value { get; set; }
        public string Unit { get; set; } = "kg";
        
        public DateTime RecordedAt { get; set; } = DateTime.UtcNow;
        public string? Location { get; set; }
        
        /// <summary>Yasal sınır değeri (opsiyonel).</summary>
        public double? LegalLimit { get; set; }
    }
}
