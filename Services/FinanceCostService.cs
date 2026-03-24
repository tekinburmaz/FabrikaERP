using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class FinanceCostService : IFinanceCostService
    {
        private readonly FabrikaDbContext _db;

        public FinanceCostService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<FinanceTransaction>> GetAllTransactionsAsync()
        {
            return await _db.FinanceTransactions
                .Include(t => t.Customer)
                .Include(t => t.Supplier)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<FinanceTransaction> CreateTransactionAsync(FinanceTransaction transaction)
        {
            transaction.CreatedAt = DateTime.UtcNow;
            if (transaction.TransactionDate == default) transaction.TransactionDate = DateTime.Now;
            
            _db.FinanceTransactions.Add(transaction);
            await _db.SaveChangesAsync();
            return transaction;
        }

        public async Task UpdateTransactionStatusAsync(int transactionId, TransactionStatus status)
        {
            var transaction = await _db.FinanceTransactions.FindAsync(transactionId)
                ?? throw new KeyNotFoundException($"Finansal işlem bulunamadı: {transactionId}");
                
            transaction.Status = status;
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CostCenter>> GetAllCostCentersAsync()
        {
            return await _db.CostCenters.ToListAsync();
        }

        public async Task<CostCenter> CreateCostCenterAsync(CostCenter costCenter)
        {
            costCenter.CreatedAt = DateTime.UtcNow;
            _db.CostCenters.Add(costCenter);
            await _db.SaveChangesAsync();
            return costCenter;
        }

        public async Task RecordCostAsync(int costCenterId, decimal amount)
        {
            var costCenter = await _db.CostCenters.FindAsync(costCenterId)
                ?? throw new KeyNotFoundException($"Masraf merkezi bulunamadı: {costCenterId}");
                
            costCenter.ActualCost += amount;
            await _db.SaveChangesAsync();
        }

        public async Task<object> GetFinancialPerformanceStatsAsync()
        {
            var totalReceipts = await _db.FinanceTransactions
                .Where(t => t.Type == TransactionType.Receipt && t.Status == TransactionStatus.Completed)
                .SumAsync(t => t.Amount);
                
            var totalPayments = await _db.FinanceTransactions
                .Where(t => t.Type == TransactionType.Payment && t.Status == TransactionStatus.Completed)
                .SumAsync(t => t.Amount);
                
            var totalBudget = await _db.CostCenters.SumAsync(c => c.Budget);
            var totalActual = await _db.CostCenters.SumAsync(c => c.ActualCost);
            
            return new
            {
                Revenue = totalReceipts,
                Expenses = totalPayments,
                NetProfit = totalReceipts - totalPayments,
                OverallBudgetUtilization = totalBudget > 0 ? (double)(totalActual / totalBudget) * 100 : 0,
                LastUpdate = DateTime.UtcNow
            };
        }
    }
}
