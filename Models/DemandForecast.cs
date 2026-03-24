using System;

namespace FabrikaERP.Models
{
    public class DemandForecast
    {
        public int Id { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        
        /// <summary>Tahmin edilen miktar.</summary>
        public double ForecastedQty { get; set; }
        
        /// <summary>Tahmin dönemi (Ay/Yıl).</summary>
        public DateTime Period { get; set; }
        
        /// <summary>Tahmin güven aralığı (0-1).</summary>
        public double Reliability { get; set; } = 0.8;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
