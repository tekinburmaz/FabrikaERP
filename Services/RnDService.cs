using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class RnDService : IRnDService
    {
        private readonly FabrikaDbContext _db;

        public RnDService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            return await _db.ProjectList.Include(p => p.Prototypes).ToListAsync();
        }

        public async Task<Project?> GetProjectByCodeAsync(string code)
        {
            return await _db.ProjectList.Include(p => p.Prototypes).FirstOrDefaultAsync(p => p.Code == code);
        }

        public async Task<Project> CreateProjectAsync(Project project)
        {
            project.CreatedAt = DateTime.UtcNow;
            project.UpdatedAt = DateTime.UtcNow;
            _db.ProjectList.Add(project);
            await _db.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateProjectStatusAsync(int projectId, ProjectStatus status)
        {
            var project = await _db.ProjectList.FindAsync(projectId) 
                ?? throw new KeyNotFoundException($"Proje bulunamadı: {projectId}");
            
            project.Status = status;
            project.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return project;
        }

        public async Task<IEnumerable<Prototype>> GetPrototypesByProjectAsync(int projectId)
        {
            return await _db.Prototypes.Where(p => p.ProjectId == projectId).ToListAsync();
        }

        public async Task<Prototype> CreatePrototypeAsync(Prototype prototype)
        {
            prototype.CreatedAt = DateTime.UtcNow;
            prototype.UpdatedAt = DateTime.UtcNow;
            _db.Prototypes.Add(prototype);
            await _db.SaveChangesAsync();
            return prototype;
        }

        public async Task<Prototype> UpdatePrototypeStatusAsync(int prototypeId, PrototypeStatus status)
        {
            var prototype = await _db.Prototypes.FindAsync(prototypeId)
                ?? throw new KeyNotFoundException($"Prototip bulunamadı: {prototypeId}");
                
            prototype.Status = status;
            prototype.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
            return prototype;
        }
    }
}
