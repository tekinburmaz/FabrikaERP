using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface ICrmSalesService
    {
        // Customer
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByCodeAsync(string code);
        Task<Customer> CreateCustomerAsync(Customer customer);
        
        // Sales Orders
        Task<IEnumerable<SalesOrder>> GetOrdersByCustomerAsync(int customerId);
        Task<SalesOrder> CreateOrderAsync(SalesOrder order);
        Task UpdateOrderStatusAsync(int orderId, SalesOrderStatus status);
        
        Task<object> GetSalesPerformanceStatsAsync();
    }
}
