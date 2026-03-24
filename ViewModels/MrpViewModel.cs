using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FabrikaERP.ViewModels
{
    /// <summary>
    /// Material Requirements Planning — malzeme ihtiyaç hesaplama ekranı.
    /// </summary>
    public class MrpViewModel : ObservableObject
    {
        public ObservableCollection<MrpLineItem> PlanLines  { get; } = new();
        public ObservableCollection<WorkOrder>   WorkOrders { get; } = new();

        private int _pendingOrderCount;
        public int PendingOrderCount  { get => _pendingOrderCount;  set => SetProperty(ref _pendingOrderCount, value); }
        private int _shortageCount;
        public int ShortageCount      { get => _shortageCount;      set => SetProperty(ref _shortageCount, value); }
        private double _totalRequired;
        public double TotalRequired   { get => _totalRequired;      set => SetProperty(ref _totalRequired, value); }

        public RelayCommand RefreshCommand   { get; }
        public RelayCommand RunMrpCommand    { get; }

        public MrpViewModel()
        {
            RefreshCommand = new RelayCommand(_ => _ = LoadAsync());
            RunMrpCommand  = new RelayCommand(_ => _ = RunMrpAsync());
            _ = LoadAsync();
        }

        public async Task LoadAsync()
        {
            try
            {
                await using var db = new FabrikaDbContext();
                var orders = await db.WorkOrders
                    .Where(w => w.Status == WorkOrderStatus.Planned || w.Status == WorkOrderStatus.InProgress)
                    .OrderBy(w => w.PlannedEnd)
                    .ToListAsync();
                WorkOrders.Clear();
                foreach (var o in orders) WorkOrders.Add(o);

                var inventory = await db.InventoryItems.ToListAsync();
                BuildPlanLines(orders, inventory);
            }
            catch { LoadSample(); }
        }

        private void BuildPlanLines(List<WorkOrder> orders, List<InventoryItem> inventory)
        {
            PlanLines.Clear();
            foreach (var inv in inventory.Take(8))
            {
                var line = new MrpLineItem
                {
                    MaterialCode   = inv.Code,
                    MaterialName   = inv.Name,
                    Unit           = inv.Unit,
                    CurrentStock   = inv.StockQty,
                    RequiredQty    = inv.MinStock * 1.5,
                    PurchaseOrderQty = inv.IsLowStock ? inv.MaxStock - inv.StockQty : 0
                };
                PlanLines.Add(line);
            }

            PendingOrderCount = PlanLines.Count(p => p.PurchaseOrderQty > 0);
            ShortageCount     = PlanLines.Count(p => p.CurrentStock < p.RequiredQty);
            TotalRequired     = PlanLines.Sum(p => p.RequiredQty);
        }

        private async Task RunMrpAsync()
        {
            // Simüle edilmiş MRP hesaplama
            await Task.Delay(500);
            await LoadAsync();
        }

        private void LoadSample()
        {
            PlanLines.Clear();
            PlanLines.Add(new MrpLineItem { MaterialCode="HM-001", MaterialName="Çelik Profil 40x40",    Unit="kg",   CurrentStock=2500, RequiredQty=1800, PurchaseOrderQty=0 });
            PlanLines.Add(new MrpLineItem { MaterialCode="HM-002", MaterialName="Alüminyum Sac 2mm",     Unit="m²",   CurrentStock=150,  RequiredQty=200,  PurchaseOrderQty=200 });
            PlanLines.Add(new MrpLineItem { MaterialCode="HM-003", MaterialName="Plastik Granül ABS",    Unit="kg",   CurrentStock=800,  RequiredQty=600,  PurchaseOrderQty=0 });
            PlanLines.Add(new MrpLineItem { MaterialCode="BP-001", MaterialName="Hidrolik Pompa Filtresi",Unit="adet", CurrentStock=12,   RequiredQty=15,   PurchaseOrderQty=38 });
            PlanLines.Add(new MrpLineItem { MaterialCode="BP-002", MaterialName="Rulman 6205-2RS",        Unit="adet", CurrentStock=48,   RequiredQty=30,   PurchaseOrderQty=0 });
            PlanLines.Add(new MrpLineItem { MaterialCode="PK-001", MaterialName="Oluklu Mukavva Kutu",   Unit="adet", CurrentStock=4,    RequiredQty=750,  PurchaseOrderQty=4996 });
            PendingOrderCount = PlanLines.Count(p => p.PurchaseOrderQty > 0);
            ShortageCount     = PlanLines.Count(p => p.CurrentStock < p.RequiredQty);
        }
    }

    public class MrpLineItem
    {
        public string MaterialCode    { get; set; } = string.Empty;
        public string MaterialName    { get; set; } = string.Empty;
        public string Unit            { get; set; } = "adet";
        public double CurrentStock    { get; set; }
        public double RequiredQty     { get; set; }
        public double PurchaseOrderQty { get; set; }
        public bool   NeedsOrder => PurchaseOrderQty > 0;
        public bool   IsShortage => CurrentStock < RequiredQty;
    }
}
