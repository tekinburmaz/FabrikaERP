using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface ISrmProcurementService
    {
        // Supplier
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<Supplier?> GetSupplierByCodeAsync(string code);
        Task<Supplier> CreateSupplierAsync(Supplier supplier);
        
        // Purchase Orders
        Task<IEnumerable<PurchaseOrder>> GetOrdersBySupplierAsync(int supplierId);
        Task<PurchaseOrder> CreatePurchaseOrderAsync(PurchaseOrder order);
        Task UpdatePurchaseOrderStatusAsync(int orderId, PurchaseOrderStatus status);
        
        // Performance
        Task UpdateSupplierPerformanceAsync(int supplierId, double newScore);
        Task<object> GetProcurementStatsAsync();
    }
}
