using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class PlanningService : IPlanningService
    {
        private readonly FabrikaDbContext _db;

        public PlanningService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<ProductionSchedule>> GetAllSchedulesAsync()
        {
            return await _db.ProductionSchedules
                .Include(s => s.Machine)
                .OrderBy(s => s.TargetDate)
                .ToListAsync();
        }

        public async Task<ProductionSchedule> CreateScheduleAsync(ProductionSchedule schedule)
        {
            schedule.CreatedAt = DateTime.UtcNow;
            schedule.UpdatedAt = DateTime.UtcNow;
            _db.ProductionSchedules.Add(schedule);
            await _db.SaveChangesAsync();
            return schedule;
        }

        public async Task<bool> DeleteScheduleAsync(int scheduleId)
        {
            var schedule = await _db.ProductionSchedules.FindAsync(scheduleId);
            if (schedule == null) return false;
            
            _db.ProductionSchedules.Remove(schedule);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<DemandForecast>> GetForecastsAsync()
        {
            return await _db.DemandForecasts.OrderBy(f => f.Period).ToListAsync();
        }

        public async Task<IEnumerable<MaterialRequirement>> GetLastMrpResultsAsync()
        {
            return await _db.MaterialRequirements
                .OrderByDescending(r => r.CreatedAt)
                .Take(100)
                .ToListAsync();
        }

        /// <summary>
        /// MRP Hesaplama Mantığı:
        /// 1. Tüm aktif üretim planlarını getir.
        /// 2. Her plan için ürün ağacını (BOM) bul.
        /// 3. Gereken malzemeleri kümülatif olarak tola.
        /// 4. Mevcut stok miktarını düşür ve eksikleri MaterialRequirements tablosuna kaydet.
        /// </summary>
        public async Task<IEnumerable<MaterialRequirement>> RunMrpAsync()
        {
            // Eski sonuçları temizleyelim (yeni bir MRP çalıştırıyoruz)
            var oldRequirements = await _db.MaterialRequirements.ToListAsync();
            _db.MaterialRequirements.RemoveRange(oldRequirements);
            await _db.SaveChangesAsync();

            var activeSchedules = await _db.ProductionSchedules
                .Where(s => s.Status == ScheduleStatus.Confirmed || s.Status == ScheduleStatus.InProgress)
                .ToListAsync();

            var requirements = new List<MaterialRequirement>();

            foreach (var schedule in activeSchedules)
            {
                var bom = await _db.BillOfMaterials
                    .Include(b => b.Items)
                    .FirstOrDefaultAsync(b => b.ProductCode == schedule.ProductCode && b.IsActive);

                if (bom == null) continue;

                foreach (var item in bom.Items)
                {
                    var totalRequired = schedule.Quantity * item.Quantity;

                    var inventory = await _db.InventoryItems
                        .FirstOrDefaultAsync(i => i.Code == item.MaterialCode);

                    var availableInStock = inventory?.StockQty ?? 0;

                    requirements.Add(new MaterialRequirement
                    {
                        MaterialCode = item.MaterialCode,
                        MaterialName = item.MaterialName,
                        RequiredQty = totalRequired,
                        AvailableInStock = availableInStock,
                        RequiredByDate = schedule.TargetDate,
                        ProductionScheduleId = schedule.Id,
                        CreatedAt = DateTime.UtcNow
                    });
                }
            }

            if (requirements.Any())
            {
                _db.MaterialRequirements.AddRange(requirements);
                await _db.SaveChangesAsync();
            }

            return requirements;
        }
    }
}
