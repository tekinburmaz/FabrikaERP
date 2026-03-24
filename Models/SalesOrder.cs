using System;

namespace FabrikaERP.Models
{
    public enum SalesOrderStatus
    {
        Draft,
        Confirmed,
        InProduction,
        ReadyForShipping,
        Shipped,
        Delivered,
        Cancelled
    }

    public class SalesOrder
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; } = string.Empty;
        
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice => Quantity * UnitPrice;
        
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DateTime RequestedDeliveryDate { get; set; }
        
        public SalesOrderStatus Status { get; set; } = SalesOrderStatus.Draft;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
