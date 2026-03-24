using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface IPlanningService
    {
        Task<IEnumerable<ProductionSchedule>> GetAllSchedulesAsync();
        Task<ProductionSchedule> CreateScheduleAsync(ProductionSchedule schedule);
        Task<bool> DeleteScheduleAsync(int scheduleId);
        
        /// <summary>
        /// Malzeme İhtiyaç Planlamasını (MRP) çalıştırır. 
        /// Mevcut planlar ve ürün ağaçlarını (BOM) kullanarak eksik malzemeleri hesaplar.
        /// </summary>
        Task<IEnumerable<MaterialRequirement>> RunMrpAsync();
        
        Task<IEnumerable<MaterialRequirement>> GetLastMrpResultsAsync();
        
        Task<IEnumerable<DemandForecast>> GetForecastsAsync();
    }
}
