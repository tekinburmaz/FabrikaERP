using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class EnergyMaintenanceService : IEnergyMaintenanceService
    {
        private readonly FabrikaDbContext _db;

        public EnergyMaintenanceService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<OeeRecord>> GetRecentOeeRecordsAsync(int machineId, int count = 10)
        {
            return await _db.OeeRecords
                .Where(o => o.MachineId == machineId)
                .OrderByDescending(o => o.Timestamp)
                .Take(count)
                .ToListAsync();
        }

        public async Task<OeeRecord> LogOeeAsync(int machineId, double availability, double performance, double quality)
        {
            var record = new OeeRecord
            {
                MachineId = machineId,
                Availability = availability,
                Performance = performance,
                Quality = quality,
                Timestamp = DateTime.UtcNow
            };
            
            _db.OeeRecords.Add(record);
            
            // Makine anlık OEE değerini de güncelleyelim
            var machine = await _db.Machines.FindAsync(machineId);
            if (machine != null)
            {
                machine.OeeCurrent = record.OverallEffectiveness * 100;
            }
            
            await _db.SaveChangesAsync();
            return record;
        }

        public async Task<IEnumerable<EnergyLog>> GetRecentEnergyLogsAsync(int? machineId = null, int count = 20)
        {
            var query = _db.EnergyLogs.AsQueryable();
            if (machineId.HasValue) query = query.Where(e => e.MachineId == machineId);
            
            return await query.OrderByDescending(e => e.Timestamp).Take(count).ToListAsync();
        }

        public async Task<EnergyLog> LogEnergyAsync(int? machineId, double consumptionKwh, double instantWattage)
        {
            var log = new EnergyLog
            {
                MachineId = machineId,
                ConsumptionKwh = consumptionKwh,
                InstantWattage = instantWattage,
                Timestamp = DateTime.UtcNow
            };
            
            _db.EnergyLogs.Add(log);
            await _db.SaveChangesAsync();
            return log;
        }

        public async Task<IEnumerable<MaintenanceRecord>> GetPendingMaintenanceAsync()
        {
            return await _db.MaintenanceRecords
                .Where(m => m.Status == MaintenanceStatus.Scheduled || m.Status == MaintenanceStatus.InProgress)
                .Include(m => m.Machine)
                .ToListAsync();
        }

        public async Task<MaintenanceRecord> ScheduleMaintenanceAsync(int machineId, string title, MaintenanceType type, DateTime scheduledAt)
        {
            var record = new MaintenanceRecord
            {
                MachineId = machineId,
                Title = title,
                Type = type,
                ScheduledAt = scheduledAt,
                Status = MaintenanceStatus.Scheduled
            };
            
            _db.MaintenanceRecords.Add(record);
            await _db.SaveChangesAsync();
            return record;
        }

        public async Task CompleteMaintenanceAsync(int recordId, double cost, string technicianNotes)
        {
            var record = await _db.MaintenanceRecords.FindAsync(recordId)
                ?? throw new KeyNotFoundException($"Bakım kaydı bulunamadı: {recordId}");
                
            record.Status = MaintenanceStatus.Completed;
            record.CompletedAt = DateTime.UtcNow;
            record.Cost = cost;
            // Not alanı modelde yoksa Audit log'dan veya açıklama alanından yürütülebilir.
            
            await _db.SaveChangesAsync();
        }
    }
}
