using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface IEnergyMaintenanceService
    {
        // OEE
        Task<IEnumerable<OeeRecord>> GetRecentOeeRecordsAsync(int machineId, int count = 10);
        Task<OeeRecord> LogOeeAsync(int machineId, double availability, double performance, double quality);
        
        // Energy
        Task<IEnumerable<EnergyLog>> GetRecentEnergyLogsAsync(int? machineId = null, int count = 20);
        Task<EnergyLog> LogEnergyAsync(int? machineId, double consumptionKwh, double instantWattage);
        
        // Maintenance
        Task<IEnumerable<MaintenanceRecord>> GetPendingMaintenanceAsync();
        Task<MaintenanceRecord> ScheduleMaintenanceAsync(int machineId, string title, MaintenanceType type, DateTime scheduledAt);
        Task CompleteMaintenanceAsync(int recordId, double cost, string technicianNotes);
    }
}
