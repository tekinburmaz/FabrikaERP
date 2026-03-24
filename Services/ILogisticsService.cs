using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface ILogisticsService
    {
        // Zones
        Task<IEnumerable<WarehouseZone>> GetAllZonesAsync();
        Task<WarehouseZone> CreateZoneAsync(WarehouseZone zone);
        
        // Stock Movements
        Task<IEnumerable<StockMovement>> GetRecentMovementsAsync(int count = 50);
        
        /// <summary>
        /// Bir malzemeyi bir depodan diğerine transfer eder veya sisteme giriş/çıkış yapar.
        /// Stok miktarını otomatik günceller.
        /// </summary>
        Task<StockMovement> ProcessMovementAsync(int itemId, double quantity, MovementType type, int? fromZoneId = null, int? toZoneId = null, string? reference = null);
        
        Task<IEnumerable<InventoryItem>> GetItemsInZoneAsync(int zoneId);
    }
}
