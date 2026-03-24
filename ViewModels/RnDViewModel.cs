using FabrikaERP.Data;
using FabrikaERP.Models;
using FabrikaERP.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace FabrikaERP.ViewModels
{
    public class RnDViewModel : ObservableObject
    {
        private readonly RnDService _rndService;

        public ObservableCollection<Project> Projects { get; } = new();
        public ObservableCollection<Prototype> Prototypes { get; } = new();

        private Project? _selectedProject;
        public Project? SelectedProject
        {
            get => _selectedProject;
            set
            {
                if (SetProperty(ref _selectedProject, value))
                {
                    _ = LoadPrototypesAsync();
                }
            }
        }

        public RelayCommand RefreshCommand { get; }

        public RnDViewModel()
        {
            // Basit bir DI simülasyonu (Context doğrudan servise veriliyor)
            var db = new FabrikaDbContext();
            _rndService = new RnDService(db);

            RefreshCommand = new RelayCommand(_ => _ = LoadProjectsAsync());
            _ = LoadProjectsAsync();
        }

        public async Task LoadProjectsAsync()
        {
            var projects = await _rndService.GetAllProjectsAsync();
            Projects.Clear();
            foreach (var p in projects) Projects.Add(p);
        }

        private async Task LoadPrototypesAsync()
        {
            if (SelectedProject == null)
            {
                Prototypes.Clear();
                return;
            }

            var prototypes = await _rndService.GetPrototypesByProjectAsync(SelectedProject.Id);
            Prototypes.Clear();
            foreach (var prt in prototypes) Prototypes.Add(prt);
        }
    }
}
