using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface ISafetyEnvironmentService
    {
        // Safety / HSE
        Task<IEnumerable<SafetyIncident>> GetAllIncidentsAsync(bool onlyOpen = false);
        Task<SafetyIncident> ReportIncidentAsync(SafetyIncident incident);
        Task CloseIncidentAsync(int incidentId, string correctiveAction);
        
        // Environment / EMS
        Task<IEnumerable<EnvironmentalImpact>> GetImpactLogsAsync(ImpactType? type = null);
        Task<EnvironmentalImpact> LogImpactAsync(EnvironmentalImpact impact);
        
        Task<object> GetSustainabilityStatsAsync();
    }
}
