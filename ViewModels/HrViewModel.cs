using FabrikaERP.Data;
using FabrikaERP.Models;
using FabrikaERP.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace FabrikaERP.ViewModels
{
    public class HrViewModel : ObservableObject
    {
        private readonly HumanResourcesService _hrService;

        public ObservableCollection<Employee> Employees { get; } = new();
        public ObservableCollection<LeaveRequest> PendingLeaves { get; } = new();
        
        private int _totalEmployeeCount;
        public int TotalEmployeeCount { get => _totalEmployeeCount; set => SetProperty(ref _totalEmployeeCount, value); }

        private int _onLeaveCount;
        public int OnLeaveCount { get => _onLeaveCount; set => SetProperty(ref _onLeaveCount, value); }

        public RelayCommand RefreshCommand { get; }
        public RelayCommand ApproveLeaveCommand { get; }

        public HrViewModel()
        {
            var db = new FabrikaDbContext();
            _hrService = new HumanResourcesService(db);

            RefreshCommand = new RelayCommand(_ => _ = LoadAllAsync());
            ApproveLeaveCommand = new RelayCommand(p => _ = ApproveLeaveAsync(p));

            _ = LoadAllAsync();
        }

        private async Task LoadAllAsync()
        {
            var employees = await _hrService.GetAllEmployeesAsync();
            Employees.Clear();
            foreach (var e in employees) Employees.Add(e);
            
            TotalEmployeeCount = Employees.Count;
            OnLeaveCount = Employees.Count(e => e.Status == EmployeeStatus.OnLeave);

            var leaves = await _hrService.GetPendingLeavesAsync();
            PendingLeaves.Clear();
            foreach (var l in leaves) PendingLeaves.Add(l);
        }

        private async Task ApproveLeaveAsync(object? param)
        {
            if (param is int leaveId)
            {
                await _hrService.ApproveLeaveAsync(leaveId, "Sistem");
                await LoadAllAsync();
            }
        }
    }
}
