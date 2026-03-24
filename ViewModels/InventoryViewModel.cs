using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FabrikaERP.ViewModels
{
    public class InventoryViewModel : ObservableObject
    {
        public ObservableCollection<InventoryItem> Items       { get; } = new();
        public ObservableCollection<InventoryItem> LowStockItems { get; } = new();

        private string _searchText = string.Empty;
        public string SearchText
        {
            get => _searchText;
            set { SetProperty(ref _searchText, value); FilterItems(); }
        }

        private InventoryCategory? _categoryFilter;
        public InventoryCategory? CategoryFilter
        {
            get => _categoryFilter;
            set { SetProperty(ref _categoryFilter, value); FilterItems(); }
        }

        private int _totalItemCount;
        public int TotalItemCount    { get => _totalItemCount;    set => SetProperty(ref _totalItemCount, value); }
        private int _lowStockCount;
        public int LowStockCount     { get => _lowStockCount;     set => SetProperty(ref _lowStockCount, value); }
        private double _totalValue;
        public double TotalValue     { get => _totalValue;        set => SetProperty(ref _totalValue, value); }

        private List<InventoryItem> _allItems = new();

        public string[] CategoryOptions { get; } = { "Tümü", "Hammadde", "Yarı Mamul", "Mamul", "Yedek Parça", "Sarf Malzeme", "Ambalaj" };

        public RelayCommand RefreshCommand { get; }

        public InventoryViewModel()
        {
            RefreshCommand = new RelayCommand(_ => _ = LoadAsync());
            _ = LoadAsync();
        }

        public async Task LoadAsync()
        {
            try
            {
                await using var db = new FabrikaDbContext();
                _allItems = await db.InventoryItems.OrderBy(i => i.Name).ToListAsync();
                UpdateStats();
                FilterItems();
            }
            catch { LoadSample(); }
        }

        private void FilterItems()
        {
            Items.Clear();
            foreach (var item in _allItems)
            {
                bool matchText = string.IsNullOrWhiteSpace(SearchText) ||
                                 item.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                 item.Code.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                bool matchCat  = CategoryFilter is null; // simple: no category filter for now
                if (matchText) Items.Add(item);
            }

            LowStockItems.Clear();
            foreach (var item in _allItems.Where(i => i.IsLowStock))
                LowStockItems.Add(item);
        }

        private void UpdateStats()
        {
            TotalItemCount = _allItems.Count;
            LowStockCount  = _allItems.Count(i => i.IsLowStock);
            TotalValue     = _allItems.Sum(i => i.StockValue);
        }

        private void LoadSample()
        {
            _allItems = new List<InventoryItem>
            {
                new() { Id=1, Code="HM-001", Name="Çelik Profil 40x40",    Category=InventoryCategory.RawMaterial,  Unit="kg",   StockQty=2500, MinStock=500,  MaxStock=5000, UnitCost=12.50 },
                new() { Id=2, Code="HM-002", Name="Alüminyum Sac 2mm",     Category=InventoryCategory.RawMaterial,  Unit="m²",   StockQty=150,  MinStock=50,   MaxStock=500,  UnitCost=85.00 },
                new() { Id=3, Code="HM-003", Name="Plastik Granül ABS",    Category=InventoryCategory.RawMaterial,  Unit="kg",   StockQty=800,  MinStock=200,  MaxStock=2000, UnitCost=45.00 },
                new() { Id=4, Code="YP-001", Name="Dişli Grubu A-12",      Category=InventoryCategory.SemiFinished, Unit="adet", StockQty=320,  MinStock=100,  MaxStock=1000, UnitCost=125.0 },
                new() { Id=5, Code="BP-001", Name="Hidrolik Pompa Filtresi",Category=InventoryCategory.SparePart,   Unit="adet", StockQty=12,   MinStock=5,    MaxStock=50,   UnitCost=380.0 },
                new() { Id=6, Code="BP-002", Name="Rulman 6205-2RS",        Category=InventoryCategory.SparePart,   Unit="adet", StockQty=48,   MinStock=10,   MaxStock=100,  UnitCost=95.00 },
                new() { Id=7, Code="TK-001", Name="Kesme Yağı ISO 46",     Category=InventoryCategory.Consumable,  Unit="lt",   StockQty=220,  MinStock=50,   MaxStock=500,  UnitCost=18.00 },
                new() { Id=8, Code="PK-001", Name="Oluklu Mukavva Kutu",   Category=InventoryCategory.Packaging,   Unit="adet", StockQty=4,    MinStock=500,  MaxStock=5000, UnitCost=2.50  },
            };
            UpdateStats();
            FilterItems();
        }
    }
}
