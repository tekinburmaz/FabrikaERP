using System;

namespace FabrikaERP.Models
{
    public class CostCenter
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        
        public string? Department { get; set; }
        public string? Manager { get; set; }
        
        /// <summary>Bütçe (Yıllık/Dönemlik).</summary>
        public decimal Budget { get; set; }
        /// <summary>Gerçekleşen Harcama.</summary>
        public decimal ActualCost { get; set; }
        
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
