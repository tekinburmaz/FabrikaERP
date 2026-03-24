using FabrikaERP.Data;
using FabrikaERP.Models;
using FabrikaERP.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace FabrikaERP.ViewModels
{
    public class FinanceViewModel : ObservableObject
    {
        private readonly FinanceCostService _service;

        public ObservableCollection<FinanceTransaction> RecentTransactions { get; } = new();
        public ObservableCollection<CostCenter> CostCenters { get; } = new();

        private decimal _totalRevenue;
        public decimal TotalRevenue { get => _totalRevenue; set => SetProperty(ref _totalRevenue, value); }

        private decimal _totalExpenses;
        public decimal TotalExpenses { get => _totalExpenses; set => SetProperty(ref _totalExpenses, value); }

        private double _budgetUtilization;
        public double BudgetUtilization { get => _budgetUtilization; set => SetProperty(ref _budgetUtilization, value); }

        public RelayCommand RefreshCommand { get; }

        public FinanceViewModel()
        {
            var db = new FabrikaDbContext();
            _service = new FinanceCostService(db);

            RefreshCommand = new RelayCommand(_ => _ = LoadDataAsync());
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var stats = (dynamic)await _service.GetFinancialPerformanceStatsAsync();
            TotalRevenue = (decimal)stats.Revenue;
            TotalExpenses = (decimal)stats.Expenses;
            BudgetUtilization = (double)stats.OverallBudgetUtilization;

            var transactions = await _service.GetAllTransactionsAsync();
            RecentTransactions.Clear();
            foreach (var t in transactions.Take(10)) RecentTransactions.Add(t);

            var centers = await _service.GetAllCostCentersAsync();
            CostCenters.Clear();
            foreach (var c in centers) CostCenters.Add(c);
        }
    }
}
