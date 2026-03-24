using System;
using System.Collections.Generic;

namespace FabrikaERP.Models
{
    public class BillOfMaterial
    {
        public int Id { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string Version { get; set; } = "1.0";
        public bool IsActive { get; set; } = true;
        
        public ICollection<BomItem> Items { get; set; } = new List<BomItem>();
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }

    public class BomItem
    {
        public int Id { get; set; }
        public int BillOfMaterialId { get; set; }
        public BillOfMaterial? BillOfMaterial { get; set; }
        
        public string MaterialCode { get; set; } = string.Empty;
        public string MaterialName { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public string Unit { get; set; } = "adet";
        public string? Position { get; set; }
    }
}
