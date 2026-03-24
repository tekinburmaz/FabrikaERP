using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;

namespace FabrikaERP.ViewModels
{
    /// <summary>
    /// Manufacturing Execution System — iş emirleri yönetim ekranı.
    /// </summary>
    public class MesViewModel : ObservableObject
    {
        public ObservableCollection<WorkOrder> WorkOrders { get; } = new();

        private WorkOrder? _selectedOrder;
        public WorkOrder? SelectedOrder
        {
            get => _selectedOrder;
            set => SetProperty(ref _selectedOrder, value);
        }

        private string _statusFilter = "Tümü";
        public string StatusFilter
        {
            get => _statusFilter;
            set { SetProperty(ref _statusFilter, value); FilterOrders(); }
        }

        public string[] StatusOptions { get; } = { "Tümü", "Planlandı", "Devam Ediyor", "Beklemede", "Tamamlandı", "Gecikiyor" };

        private int _inProgressCount;
        public int InProgressCount { get => _inProgressCount; set => SetProperty(ref _inProgressCount, value); }
        private int _completedCount;
        public int CompletedCount  { get => _completedCount;  set => SetProperty(ref _completedCount, value); }
        private int _delayedCount;
        public int DelayedCount    { get => _delayedCount;    set => SetProperty(ref _delayedCount, value); }
        private int _totalProduced;
        public int TotalProduced   { get => _totalProduced;   set => SetProperty(ref _totalProduced, value); }

        private List<WorkOrder> _allOrders = new();

        public RelayCommand RefreshCommand    { get; }
        public RelayCommand StartOrderCommand { get; }
        public RelayCommand PauseOrderCommand { get; }

        public MesViewModel()
        {
            RefreshCommand    = new RelayCommand(_ => _ = LoadAsync());
            StartOrderCommand = new RelayCommand(_ => _ = StartSelectedAsync(), _ => SelectedOrder?.Status == WorkOrderStatus.Planned);
            PauseOrderCommand = new RelayCommand(_ => _ = PauseSelectedAsync(),  _ => SelectedOrder?.Status == WorkOrderStatus.InProgress);
            
            // Başlatıcı constructor'dan MesPage.Loaded'a taşındı
        }

        public async Task LoadAsync()
        {
            try
            {
                await using var db = new FabrikaDbContext();
                _allOrders = await db.WorkOrders
                    .Include(w => w.Machine)
                    .Include(w => w.AssignedUser)
                    .OrderByDescending(w => w.PlannedEnd)
                    .ToListAsync();
                UpdateStats();
                FilterOrders();
            }
            catch { LoadSample(); }
        }

        private void FilterOrders()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                WorkOrders.Clear();
                foreach (var o in _allOrders)
                {
                    bool match = StatusFilter == "Tümü" ||
                                 (StatusFilter == "Planlandı"    && o.Status == WorkOrderStatus.Planned) ||
                                 (StatusFilter == "Devam Ediyor" && o.Status == WorkOrderStatus.InProgress) ||
                                 (StatusFilter == "Beklemede"    && o.Status == WorkOrderStatus.OnHold) ||
                                 (StatusFilter == "Tamamlandı"   && o.Status == WorkOrderStatus.Completed) ||
                                 (StatusFilter == "Gecikiyor"    && o.Status == WorkOrderStatus.Delayed);
                    if (match) WorkOrders.Add(o);
                }
            });
        }

        private void UpdateStats()
        {
            Application.Current?.Dispatcher?.Invoke(() =>
            {
                InProgressCount = _allOrders.Count(o => o.Status == WorkOrderStatus.InProgress);
                CompletedCount  = _allOrders.Count(o => o.Status == WorkOrderStatus.Completed);
                DelayedCount    = _allOrders.Count(o => o.Status == WorkOrderStatus.Delayed);
                TotalProduced   = _allOrders.Sum(o => o.ProducedQty);
            });
        }

        private async Task StartSelectedAsync()
        {
            if (SelectedOrder is null) return;
            SelectedOrder.Status     = WorkOrderStatus.InProgress;
            SelectedOrder.ActualStart = DateTime.UtcNow;
            try
            {
                await using var db = new FabrikaDbContext();
                db.WorkOrders.Update(SelectedOrder);
                await db.SaveChangesAsync();
            }
            catch { /* demo mod */ }
            FilterOrders();
        }

        private async Task PauseSelectedAsync()
        {
            if (SelectedOrder is null) return;
            SelectedOrder.Status = WorkOrderStatus.OnHold;
            try
            {
                await using var db = new FabrikaDbContext();
                db.WorkOrders.Update(SelectedOrder);
                await db.SaveChangesAsync();
            }
            catch { /* demo mod */ }
            FilterOrders();
        }

        private void LoadSample()
        {
            _allOrders = new List<WorkOrder>
            {
                new() { OrderNumber="WO-2024-0891", ProductName="Dişli Grubu A-12",  PlannedQty=500,  ProducedQty=390, RejectedQty=4,  Status=WorkOrderStatus.InProgress, PlannedStart=DateTime.Today.AddDays(-3), PlannedEnd=DateTime.Today,           Machine=new Machine{Code="CNC-01",Name="CNC Torna A-1"} },
                new() { OrderNumber="WO-2024-0890", ProductName="Gövde Kasası B-7",  PlannedQty=200,  ProducedQty=90,  RejectedQty=2,  Status=WorkOrderStatus.OnHold,     PlannedStart=DateTime.Today.AddDays(-2), PlannedEnd=DateTime.Today.AddDays(1),  Machine=new Machine{Code="PRS-01",Name="Pres B-1"} },
                new() { OrderNumber="WO-2024-0889", ProductName="Rulman Seti C-3",   PlannedQty=1000, ProducedQty=1000,RejectedQty=9,  Status=WorkOrderStatus.Completed,  PlannedStart=DateTime.Today.AddDays(-5), PlannedEnd=DateTime.Today.AddDays(-1), Machine=new Machine{Code="WLD-01",Name="Kaynak C-1"} },
                new() { OrderNumber="WO-2024-0888", ProductName="Piston Grubu D-1",  PlannedQty=350,  ProducedQty=0,   RejectedQty=0,  Status=WorkOrderStatus.Delayed,    PlannedStart=DateTime.Today.AddDays(-1), PlannedEnd=DateTime.Today.AddDays(2),  Machine=new Machine{Code="WLD-02",Name="Kaynak C-2"} },
                new() { OrderNumber="WO-2024-0887", ProductName="Montaj Kiti E-2",   PlannedQty=250,  ProducedQty=250, RejectedQty=1,  Status=WorkOrderStatus.Completed,  PlannedStart=DateTime.Today.AddDays(-4), PlannedEnd=DateTime.Today.AddDays(-2), Machine=new Machine{Code="ASM-01",Name="Montaj D-1"} },
                new() { OrderNumber="WO-2024-0886", ProductName="Vida Seti F-5",     PlannedQty=5000, ProducedQty=0,   RejectedQty=0,  Status=WorkOrderStatus.Planned,    PlannedStart=DateTime.Today.AddDays(1),  PlannedEnd=DateTime.Today.AddDays(4),  Machine=new Machine{Code="PKG-01",Name="Paketleme E-1"} },
            };
            UpdateStats();
            FilterOrders();
        }
    }
}
