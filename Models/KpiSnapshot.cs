namespace FabrikaERP.Models
{
    /// <summary>
    /// Belirli bir anda alınan KPI anlık görüntüsü (dashboard için).
    /// </summary>
    public class KpiSnapshot
    {
        public int      Id                  { get; set; }
        public DateTime Timestamp           { get; set; } = DateTime.UtcNow;
        public int      ProductionRate      { get; set; }   // adet/saat
        public double   OeePercent          { get; set; }
        public double   QualityRate         { get; set; }   // 0–100
        public int      ActiveMachines      { get; set; }
        public int      TotalMachines       { get; set; }
        public int      ActiveAlerts        { get; set; }
        public int      CompletedWorkOrders { get; set; }
        public int      PendingWorkOrders   { get; set; }
    }
}
