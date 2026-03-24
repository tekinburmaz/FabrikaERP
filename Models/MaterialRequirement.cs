using System;

namespace FabrikaERP.Models
{
    public class MaterialRequirement
    {
        public int Id { get; set; }
        public string MaterialCode { get; set; } = string.Empty;
        public string MaterialName { get; set; } = string.Empty;
        
        /// <summary>Toplam gereken miktar.</summary>
        public double RequiredQty { get; set; }
        
        /// <summary>Stokta mevcut miktar.</summary>
        public double AvailableInStock { get; set; }
        
        /// <summary>Satın alınması gereken fark miktar.</summary>
        public double DeficitQty => Math.Max(0, RequiredQty - AvailableInStock);
        
        public DateTime RequiredByDate { get; set; }
        
        /// <summary>Hangi üretim planı için gerektiği (opsiyonel).</summary>
        public int? ProductionScheduleId { get; set; }
        public ProductionSchedule? ProductionSchedule { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
