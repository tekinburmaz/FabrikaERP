using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class CrmSalesService : ICrmSalesService
    {
        private readonly FabrikaDbContext _db;

        public CrmSalesService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _db.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByCodeAsync(string code)
        {
            return await _db.Customers.FirstOrDefaultAsync(c => c.Code == code);
        }

        public async Task<Customer> CreateCustomerAsync(Customer customer)
        {
            customer.CreatedAt = DateTime.UtcNow;
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<SalesOrder>> GetOrdersByCustomerAsync(int customerId)
        {
            return await _db.SalesOrders
                .Where(o => o.CustomerId == customerId)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();
        }

        public async Task<SalesOrder> CreateOrderAsync(SalesOrder order)
        {
            order.OrderDate = DateTime.Now;
            order.CreatedAt = DateTime.UtcNow;
            order.UpdatedAt = DateTime.UtcNow;
            
            _db.SalesOrders.Add(order);
            await _db.SaveChangesAsync();
            return order;
        }

        public async Task UpdateOrderStatusAsync(int orderId, SalesOrderStatus status)
        {
            var order = await _db.SalesOrders.FindAsync(orderId)
                ?? throw new KeyNotFoundException($"Satış siparişi bulunamadı: {orderId}");
                
            order.Status = status;
            order.UpdatedAt = DateTime.UtcNow;
            
            await _db.SaveChangesAsync();
        }

        public async Task<object> GetSalesPerformanceStatsAsync()
        {
            var totalSales = await _db.SalesOrders
                .Where(o => o.Status != SalesOrderStatus.Cancelled)
                .SumAsync(o => o.Quantity * o.UnitPrice);
                
            var activeOrdersCount = await _db.SalesOrders
                .CountAsync(o => o.Status != SalesOrderStatus.Delivered && o.Status != SalesOrderStatus.Cancelled);
                
            return new
            {
                TotalRevenue = totalSales,
                ActiveOrdersCount = activeOrdersCount,
                LastUpdate = DateTime.UtcNow
            };
        }
    }
}
