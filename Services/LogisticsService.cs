using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class LogisticsService : ILogisticsService
    {
        private readonly FabrikaDbContext _db;

        public LogisticsService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<WarehouseZone>> GetAllZonesAsync()
        {
            return await _db.WarehouseZones.Where(z => z.IsActive).ToListAsync();
        }

        public async Task<WarehouseZone> CreateZoneAsync(WarehouseZone zone)
        {
            _db.WarehouseZones.Add(zone);
            await _db.SaveChangesAsync();
            return zone;
        }

        public async Task<IEnumerable<StockMovement>> GetRecentMovementsAsync(int count = 50)
        {
            return await _db.StockMovements
                .Include(m => m.InventoryItem)
                .Include(m => m.FromZone)
                .Include(m => m.ToZone)
                .OrderByDescending(m => m.Timestamp)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<InventoryItem>> GetItemsInZoneAsync(int zoneId)
        {
            return await _db.InventoryItems.Where(i => i.WarehouseZoneId == zoneId).ToListAsync();
        }

        /// <summary>
        /// Stok hareketini (Giriş/Çıkış/Transfer) işler.
        /// 1. Stok miktarını günceller.
        /// 2. Depo doluluk oranını (Occupancy) günceller.
        /// 3. Hareket kaydı oluşturur.
        /// </summary>
        public async Task<StockMovement> ProcessMovementAsync(int itemId, double quantity, MovementType type, int? fromZoneId = null, int? toZoneId = null, string? reference = null)
        {
            var item = await _db.InventoryItems.FindAsync(itemId)
                ?? throw new KeyNotFoundException($"Stok kalemi bulunamadı: {itemId}");

            var movement = new StockMovement
            {
                InventoryItemId = itemId,
                Quantity = quantity,
                Type = type,
                FromZoneId = fromZoneId,
                ToZoneId = toZoneId,
                ReferenceDocument = reference,
                Timestamp = DateTime.UtcNow
            };

            // 1. Stok Miktarı Güncelleme
            if (type == MovementType.Inbound)
            {
                item.StockQty += quantity;
            }
            else if (type == MovementType.Outbound)
            {
                if (item.StockQty < quantity) throw new InvalidOperationException("Yetersiz stok!");
                item.StockQty -= quantity;
            }
            // Transfer'de toplam stok değişmez, sadece zone değişebilir.

            // 2. Zone Güncelleme
            if (toZoneId.HasValue)
            {
                var toZone = await _db.WarehouseZones.FindAsync(toZoneId.Value);
                if (toZone != null) 
                {
                    toZone.CurrentOccupancy += quantity;
                    item.WarehouseZoneId = toZoneId; // Malzemenin yeni zone'u
                }
            }

            if (fromZoneId.HasValue)
            {
                var fromZone = await _db.WarehouseZones.FindAsync(fromZoneId.Value);
                if (fromZone != null)
                {
                    fromZone.CurrentOccupancy = Math.Max(0, fromZone.CurrentOccupancy - quantity);
                }
            }

            item.UpdatedAt = DateTime.UtcNow;
            _db.StockMovements.Add(movement);
            await _db.SaveChangesAsync();

            return movement;
        }
    }
}
