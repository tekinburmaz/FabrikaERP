using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FabrikaERP.ViewModels
{
    public class MaintenanceViewModel : ObservableObject
    {
        public ObservableCollection<MaintenanceRecord> Records   { get; } = new();
        public ObservableCollection<Machine>           Machines  { get; } = new();

        private int _scheduledCount;
        public int ScheduledCount  { get => _scheduledCount;  set => SetProperty(ref _scheduledCount, value); }
        private int _inProgressCount;
        public int InProgressCount { get => _inProgressCount; set => SetProperty(ref _inProgressCount, value); }
        private int _completedCount;
        public int CompletedCount  { get => _completedCount;  set => SetProperty(ref _completedCount, value); }
        private double _totalCost;
        public double TotalCost    { get => _totalCost;       set => SetProperty(ref _totalCost, value); }

        private string _filterStatus = "Tümü";
        public string FilterStatus
        {
            get => _filterStatus;
            set { SetProperty(ref _filterStatus, value); FilterRecords(); }
        }

        public string[] StatusOptions { get; } = { "Tümü", "Planlandı", "Devam Ediyor", "Tamamlandı", "İptal" };

        private List<MaintenanceRecord> _allRecords = new();

        public RelayCommand RefreshCommand { get; }

        public MaintenanceViewModel()
        {
            RefreshCommand = new RelayCommand(_ => _ = LoadAsync());
            _ = LoadAsync();
        }

        public async Task LoadAsync()
        {
            try
            {
                await using var db = new FabrikaDbContext();
                _allRecords = await db.MaintenanceRecords
                    .Include(r => r.Machine)
                    .OrderByDescending(r => r.ScheduledAt)
                    .ToListAsync();
                var mList = await db.Machines.OrderBy(m => m.Code).ToListAsync();
                Machines.Clear();
                foreach (var m in mList) Machines.Add(m);
                UpdateStats();
                FilterRecords();
            }
            catch { LoadSample(); }
        }

        private void FilterRecords()
        {
            Records.Clear();
            foreach (var r in _allRecords)
            {
                bool match = FilterStatus == "Tümü" ||
                             (FilterStatus == "Planlandı"     && r.Status == MaintenanceStatus.Scheduled) ||
                             (FilterStatus == "Devam Ediyor"  && r.Status == MaintenanceStatus.InProgress) ||
                             (FilterStatus == "Tamamlandı"    && r.Status == MaintenanceStatus.Completed) ||
                             (FilterStatus == "İptal"         && r.Status == MaintenanceStatus.Cancelled);
                if (match) Records.Add(r);
            }
        }

        private void UpdateStats()
        {
            ScheduledCount  = _allRecords.Count(r => r.Status == MaintenanceStatus.Scheduled);
            InProgressCount = _allRecords.Count(r => r.Status == MaintenanceStatus.InProgress);
            CompletedCount  = _allRecords.Count(r => r.Status == MaintenanceStatus.Completed);
            TotalCost       = _allRecords.Where(r => r.Cost.HasValue).Sum(r => r.Cost!.Value);
        }

        private void LoadSample()
        {
            _allRecords = new List<MaintenanceRecord>
            {
                new() { Id=1, Type=MaintenanceType.Preventive,  Status=MaintenanceStatus.Scheduled,  Title="Periyodik Yağlama",     Machine=new Machine{Code="CNC-01",Name="CNC Torna A-1"}, ScheduledAt=DateTime.Today.AddDays(2),  Technician="Ahmet Yılmaz" },
                new() { Id=2, Type=MaintenanceType.Corrective,  Status=MaintenanceStatus.InProgress, Title="Elektrik Arıza",         Machine=new Machine{Code="WLD-02",Name="Kaynak Robot C-2"}, ScheduledAt=DateTime.Today,             Technician="Mehmet Kaya",  StartedAt=DateTime.Now.AddHours(-2) },
                new() { Id=3, Type=MaintenanceType.Preventive,  Status=MaintenanceStatus.Completed,  Title="Filtre Değişimi",        Machine=new Machine{Code="PRS-02",Name="Pres B-2"},       ScheduledAt=DateTime.Today.AddDays(-3), Technician="Ali Demir",    CompletedAt=DateTime.Today.AddDays(-3), Cost=1250 },
                new() { Id=4, Type=MaintenanceType.Emergency,   Status=MaintenanceStatus.Completed,  Title="Acil Pnömatik Tamir",    Machine=new Machine{Code="PRS-01",Name="Pres B-1"},       ScheduledAt=DateTime.Today.AddDays(-1), Technician="Ahmet Yılmaz", CompletedAt=DateTime.Today.AddDays(-1), Cost=3200 },
                new() { Id=5, Type=MaintenanceType.Predictive,  Status=MaintenanceStatus.Scheduled,  Title="Rulman Kontrol",         Machine=new Machine{Code="ASM-01",Name="Montaj D-1"},     ScheduledAt=DateTime.Today.AddDays(5),  Technician="Ali Demir" },
            };
            UpdateStats();
            FilterRecords();
        }
    }
}
