using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class SrmProcurementService : ISrmProcurementService
    {
        private readonly FabrikaDbContext _db;

        public SrmProcurementService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            return await _db.Suppliers.ToListAsync();
        }

        public async Task<Supplier?> GetSupplierByCodeAsync(string code)
        {
            return await _db.Suppliers.FirstOrDefaultAsync(s => s.Code == code);
        }

        public async Task<Supplier> CreateSupplierAsync(Supplier supplier)
        {
            supplier.CreatedAt = DateTime.UtcNow;
            _db.Suppliers.Add(supplier);
            await _db.SaveChangesAsync();
            return supplier;
        }

        public async Task<IEnumerable<PurchaseOrder>> GetOrdersBySupplierAsync(int supplierId)
        {
            return await _db.PurchaseOrders
                .Where(o => o.SupplierId == supplierId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<PurchaseOrder> CreatePurchaseOrderAsync(PurchaseOrder order)
        {
            order.OrderDate = DateTime.Now;
            order.CreatedAt = DateTime.UtcNow;
            order.UpdatedAt = DateTime.UtcNow;
            
            _db.PurchaseOrders.Add(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task UpdatePurchaseOrderStatusAsync(int orderId, PurchaseOrderStatus status)
        {
            var order = await _db.PurchaseOrders.FindAsync(orderId)
                ?? throw new KeyNotFoundException($"Satın alma siparişi bulunamadı: {orderId}");
                
            order.Status = status;
            order.UpdatedAt = DateTime.UtcNow;
            
            await _db.SaveChangesAsync();
        }

        public async Task UpdateSupplierPerformanceAsync(int supplierId, double newScore)
        {
            var supplier = await _db.Suppliers.FindAsync(supplierId)
                ?? throw new KeyNotFoundException($"Tedarikçi bulunamadı: {supplierId}");
                
            supplier.PerformanceScore = newScore;
            await _db.SaveChangesAsync();
        }

        public async Task<object> GetProcurementStatsAsync()
        {
            var totalProcurement = await _db.PurchaseOrders
                .Where(o => o.Status != PurchaseOrderStatus.Cancelled)
                .SumAsync(o => o.Quantity * o.UnitPrice);
                
            var activePoCount = await _db.PurchaseOrders
                .CountAsync(o => o.Status != PurchaseOrderStatus.Received && o.Status != PurchaseOrderStatus.Cancelled);
                
            return new
            {
                TotalProcurementCost = totalProcurement,
                ActivePurchaseOrdersCount = activePoCount,
                LastUpdate = DateTime.UtcNow
            };
        }
    }
}
