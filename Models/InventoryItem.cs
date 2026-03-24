namespace FabrikaERP.Models
{
    public enum InventoryCategory
    {
        RawMaterial,
        SemiFinished,
        FinishedGood,
        SparePart,
        Consumable,
        Packaging
    }

    public class InventoryItem
    {
        public int               Id          { get; set; }
        public string            Code        { get; set; } = string.Empty;
        public string            Name        { get; set; } = string.Empty;
        public string?           Description { get; set; }
        public InventoryCategory Category   { get; set; } = InventoryCategory.RawMaterial;
        public string            Unit        { get; set; } = "adet";
        public double            StockQty    { get; set; }
        public double            MinStock    { get; set; }
        public double            MaxStock    { get; set; }
        public double            UnitCost    { get; set; }
        
        public int?              WarehouseZoneId { get; set; }
        public WarehouseZone?    WarehouseZone   { get; set; }
        
        public string?           Supplier    { get; set; }
        public DateTime          UpdatedAt   { get; set; } = DateTime.UtcNow;

        public bool IsLowStock => StockQty <= MinStock;
        public double StockValue => StockQty * UnitCost;
    }
}
