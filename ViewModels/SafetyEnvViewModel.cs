using FabrikaERP.Data;
using FabrikaERP.Models;
using FabrikaERP.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Linq;

namespace FabrikaERP.ViewModels
{
    public class SafetyEnvViewModel : ObservableObject
    {
        private readonly SafetyEnvironmentService _service;

        public ObservableCollection<SafetyIncident> Incidents { get; } = new();
        public ObservableCollection<EnvironmentalImpact> Impacts { get; } = new();

        private int _incidentCount;
        public int IncidentCount { get => _incidentCount; set => SetProperty(ref _incidentCount, value); }

        private double _totalCarbon;
        public double TotalCarbon { get => _totalCarbon; set => SetProperty(ref _totalCarbon, value); }

        public RelayCommand RefreshCommand { get; }

        public SafetyEnvViewModel()
        {
            var db = new FabrikaDbContext();
            _service = new SafetyEnvironmentService(db);

            RefreshCommand = new RelayCommand(_ => _ = LoadDataAsync());
            _ = LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            var incidents = await _service.GetAllIncidentsAsync();
            Incidents.Clear();
            foreach (var i in incidents) Incidents.Add(i);
            IncidentCount = Incidents.Count;

            var impacts = await _service.GetImpactLogsAsync();
            Impacts.Clear();
            foreach (var imp in impacts) Impacts.Add(imp);
            TotalCarbon = Impacts.Sum(i => i.Value);
        }
    }
}
