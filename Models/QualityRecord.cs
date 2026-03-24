namespace FabrikaERP.Models
{
    public enum QualityResult
    {
        Pass,
        Fail,
        Conditional
    }

    public class QualityRecord
    {
        public int           Id           { get; set; }
        public string        Barcode      { get; set; } = string.Empty;
        public string        ProductName  { get; set; } = string.Empty;
        public QualityResult Result       { get; set; } = QualityResult.Pass;
        public string?       FailReason   { get; set; }
        public string?       InspectorId  { get; set; }
        public string?       Notes        { get; set; }
        public DateTime      InspectedAt  { get; set; } = DateTime.UtcNow;

        public int?       WorkOrderId  { get; set; }
        public WorkOrder? WorkOrder    { get; set; }
    }
}
