using FabrikaERP.Data;
using FabrikaERP.Models;
using FabrikaERP.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FabrikaERP.ViewModels
{
    public class TradeViewModel : ObservableObject
    {
        private readonly CrmSalesService _salesService;
        private readonly SrmProcurementService _procurementService;

        public ObservableCollection<Customer> Customers { get; } = new();
        public ObservableCollection<Supplier> Suppliers { get; } = new();
        public ObservableCollection<SalesOrder> SalesOrders { get; } = new();
        public ObservableCollection<PurchaseOrder> PurchaseOrders { get; } = new();

        public RelayCommand RefreshCommand { get; }

        public TradeViewModel()
        {
            var db = new FabrikaDbContext();
            _salesService = new CrmSalesService(db);
            _procurementService = new SrmProcurementService(db);

            RefreshCommand = new RelayCommand(_ => _ = LoadAllAsync());
            _ = LoadAllAsync();
        }

        private async Task LoadAllAsync()
        {
            var customers = await _salesService.GetAllCustomersAsync();
            Customers.Clear();
            foreach (var c in customers) Customers.Add(c);

            var suppliers = await _procurementService.GetAllSuppliersAsync();
            Suppliers.Clear();
            foreach (var s in suppliers) Suppliers.Add(s);

            // Örnek sipariş yükleme
            // (Gerçekte her biri için ayrı metodlar veya genel bir liste olabilir)
        }
    }
}
