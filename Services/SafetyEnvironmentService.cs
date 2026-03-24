using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class SafetyEnvironmentService : ISafetyEnvironmentService
    {
        private readonly FabrikaDbContext _db;

        public SafetyEnvironmentService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<SafetyIncident>> GetAllIncidentsAsync(bool onlyOpen = false)
        {
            var query = _db.SafetyIncidents.AsQueryable();
            if (onlyOpen) query = query.Where(i => !i.IsClosed);
            
            return await query.OrderByDescending(i => i.IncidentDate).ToListAsync();
        }

        public async Task<SafetyIncident> ReportIncidentAsync(SafetyIncident incident)
        {
            incident.CreatedAt = DateTime.UtcNow;
            _db.SafetyIncidents.Add(incident);
            await _db.SaveChangesAsync();
            return incident;
        }

        public async Task CloseIncidentAsync(int incidentId, string correctiveAction)
        {
            var incident = await _db.SafetyIncidents.FindAsync(incidentId)
                ?? throw new KeyNotFoundException($"Olay kaydı bulunamadı: {incidentId}");
                
            incident.IsClosed = true;
            incident.CorrectiveAction = correctiveAction;
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<EnvironmentalImpact>> GetImpactLogsAsync(ImpactType? type = null)
        {
            var query = _db.EnvironmentalImpacts.AsQueryable();
            if (type.HasValue) query = query.Where(i => i.Type == type.Value);
            
            return await query.OrderByDescending(i => i.RecordedAt).ToListAsync();
        }

        public async Task<EnvironmentalImpact> LogImpactAsync(EnvironmentalImpact impact)
        {
            impact.RecordedAt = DateTime.UtcNow;
            _db.EnvironmentalImpacts.Add(impact);
            await _db.SaveChangesAsync();
            return impact;
        }

        public async Task<object> GetSustainabilityStatsAsync()
        {
            var totalWaste = await _db.EnvironmentalImpacts
                .Where(i => i.Type == ImpactType.Waste)
                .SumAsync(i => i.Value);
                
            var openIncidents = await _db.SafetyIncidents
                .CountAsync(i => !i.IsClosed);
                
            return new
            {
                TotalWasteKg = totalWaste,
                OpenSafetyIncidents = openIncidents,
                LastUpdate = DateTime.UtcNow
            };
        }
    }
}
