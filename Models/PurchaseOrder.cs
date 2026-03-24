using System;

namespace FabrikaERP.Models
{
    public enum PurchaseOrderStatus
    {
        Draft,
        SentToSupplier,
        PartiallyReceived,
        Received,
        Cancelled
    }

    public class PurchaseOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        
        public int SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice => Quantity * UnitPrice;
        
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime ExpectedDate { get; set; }
        
        public PurchaseOrderStatus Status { get; set; } = PurchaseOrderStatus.Draft;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
