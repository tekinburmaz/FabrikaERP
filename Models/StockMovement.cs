using System;

namespace FabrikaERP.Models
{
    public enum MovementType
    {
        Inbound,  // Giriş
        Outbound, // Çıkış
        Transfer  // Ambarlar arası transfer
    }

    public class StockMovement
    {
        public int Id { get; set; }
        public int InventoryItemId { get; set; }
        public InventoryItem? InventoryItem { get; set; }
        
        public MovementType Type { get; set; }
        public double Quantity { get; set; }
        
        public int? FromZoneId { get; set; }
        public WarehouseZone? FromZone { get; set; }
        
        public int? ToZoneId { get; set; }
        public WarehouseZone? ToZone { get; set; }
        
        public string? ReferenceDocument { get; set; } // Satın alma no, iş emri no vb.
        public string? CreatedBy { get; set; }
        
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    }
}
