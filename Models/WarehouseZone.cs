using System;
using System.Collections.Generic;

namespace FabrikaERP.Models
{
    public enum ZoneType
    {
        RawMaterial,
        WIP, // Work In Progress
        FinishedGoods,
        Quarantine,
        Scrap,
        Shipping
    }

    public class WarehouseZone
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty; // PRD-01, RM-A1
        public string Name { get; set; } = string.Empty;
        public ZoneType Type { get; set; }
        
        /// <summary>Kapasite (birim/palette cinsinden).</summary>
        public double MaxCapacity { get; set; }
        
        /// <summary>Anlık doluluk.</summary>
        public double CurrentOccupancy { get; set; }
        
        public string? Temperature { get; set; }
        public bool IsActive { get; set; } = true;
        
        public ICollection<InventoryItem> Items { get; set; } = new List<InventoryItem>();
    }
}
