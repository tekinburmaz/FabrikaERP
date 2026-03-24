using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FabrikaERP.ViewModels
{
    public class ShopFloorViewModel : BaseViewModel
    {
        public ObservableCollection<Machine>   Machines   { get; } = new();
        public ObservableCollection<WorkOrder> WorkOrders { get; } = new();

        private Machine? _selectedMachine;
        public Machine? SelectedMachine
        {
            get => _selectedMachine;
            set => SetProperty(ref _selectedMachine, value);
        }

        private string _searchText = string.Empty;
        public string SearchText
        {
            get => _searchText;
            set
            {
                SetProperty(ref _searchText, value);
                FilterMachines();
            }
        }

        private string _statusFilter = "Tümü";
        public string StatusFilter
        {
            get => _statusFilter;
            set
            {
                SetProperty(ref _statusFilter, value);
                FilterMachines();
            }
        }

        public string[] StatusOptions { get; } = { "Tümü", "Çalışıyor", "Boşta", "Bakım", "Arıza" };

        private List<Machine> _allMachines = new();

        private int _runningCount;
        public int RunningCount { get => _runningCount; set => SetProperty(ref _runningCount, value); }
        private int _idleCount;
        public int IdleCount    { get => _idleCount;    set => SetProperty(ref _idleCount, value); }
        private int _maintenanceCount;
        public int MaintenanceCount { get => _maintenanceCount; set => SetProperty(ref _maintenanceCount, value); }
        private int _breakdownCount;
        public int BreakdownCount { get => _breakdownCount; set => SetProperty(ref _breakdownCount, value); }

        public RelayCommand RefreshCommand   { get; }
        public RelayCommand SelectAllCommand { get; }

        public ShopFloorViewModel()
        {
            RefreshCommand   = new RelayCommand(_ => _ = LoadAsync());
            SelectAllCommand = new RelayCommand(_ => SelectedMachine = null);
            _ = LoadAsync();
        }

        public async Task LoadAsync()
        {
            try
            {
                await using var db = new FabrikaDbContext();
                _allMachines = await db.Machines
                    .Include(m => m.WorkOrders.Where(w => w.Status == WorkOrderStatus.InProgress))
                    .OrderBy(m => m.Code)
                    .ToListAsync();

                var orders = await db.WorkOrders
                    .Include(w => w.Machine)
                    .Where(w => w.Status == WorkOrderStatus.InProgress || w.Status == WorkOrderStatus.Planned)
                    .OrderByDescending(w => w.CreatedAt)
                    .ToListAsync();

                WorkOrders.Clear();
                foreach (var o in orders) WorkOrders.Add(o);

                UpdateCounts();
                FilterMachines();
            }
            catch
            {
                LoadSample();
            }
        }

        private void FilterMachines()
        {
            Machines.Clear();
            foreach (var m in _allMachines)
            {
                bool matchText   = string.IsNullOrWhiteSpace(SearchText) ||
                                   m.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                   m.Code.Contains(SearchText, StringComparison.OrdinalIgnoreCase);
                bool matchStatus = StatusFilter == "Tümü" ||
                                   (StatusFilter == "Çalışıyor" && m.Status == MachineStatus.Running) ||
                                   (StatusFilter == "Boşta"    && m.Status == MachineStatus.Idle) ||
                                   (StatusFilter == "Bakım"    && m.Status == MachineStatus.Maintenance) ||
                                   (StatusFilter == "Arıza"    && m.Status == MachineStatus.Breakdown);
                if (matchText && matchStatus) Machines.Add(m);
            }
        }

        private void UpdateCounts()
        {
            RunningCount     = _allMachines.Count(m => m.Status == MachineStatus.Running);
            IdleCount        = _allMachines.Count(m => m.Status == MachineStatus.Idle);
            MaintenanceCount = _allMachines.Count(m => m.Status == MachineStatus.Maintenance);
            BreakdownCount   = _allMachines.Count(m => m.Status == MachineStatus.Breakdown);
        }

        private void LoadSample()
        {
            _allMachines = new List<Machine>
            {
                new() { Id = 1, Code = "CNC-01", Name = "CNC Torna A-1",     Department = "Üretim",    Status = MachineStatus.Running,     OeeCurrent = 87.3 },
                new() { Id = 2, Code = "CNC-02", Name = "CNC Torna A-2",     Department = "Üretim",    Status = MachineStatus.Running,     OeeCurrent = 82.1 },
                new() { Id = 3, Code = "PRS-01", Name = "Pres Makinesi B-1", Department = "Presleme",  Status = MachineStatus.Maintenance, OeeCurrent = 0    },
                new() { Id = 4, Code = "PRS-02", Name = "Pres Makinesi B-2", Department = "Presleme",  Status = MachineStatus.Running,     OeeCurrent = 79.5 },
                new() { Id = 5, Code = "WLD-01", Name = "Kaynak Robot C-1",  Department = "Kaynak",    Status = MachineStatus.Running,     OeeCurrent = 91.2 },
                new() { Id = 6, Code = "WLD-02", Name = "Kaynak Robot C-2",  Department = "Kaynak",    Status = MachineStatus.Breakdown,   OeeCurrent = 0    },
                new() { Id = 7, Code = "ASM-01", Name = "Montaj Hattı D-1",  Department = "Montaj",    Status = MachineStatus.Running,     OeeCurrent = 84.8 },
                new() { Id = 8, Code = "PKG-01", Name = "Paketleme E-1",     Department = "Paketleme", Status = MachineStatus.Idle,        OeeCurrent = 0    },
            };
            UpdateCounts();
            FilterMachines();
        }
    }
}
