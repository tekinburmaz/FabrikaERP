using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface IFinanceCostService
    {
        // Transactions (AP/AR)
        Task<IEnumerable<FinanceTransaction>> GetAllTransactionsAsync();
        Task<FinanceTransaction> CreateTransactionAsync(FinanceTransaction transaction);
        Task UpdateTransactionStatusAsync(int transactionId, TransactionStatus status);
        
        // Cost Centers
        Task<IEnumerable<CostCenter>> GetAllCostCentersAsync();
        Task<CostCenter> CreateCostCenterAsync(CostCenter costCenter);
        Task RecordCostAsync(int costCenterId, decimal amount);
        
        // Reports
        Task<object> GetFinancialPerformanceStatsAsync();
    }
}
