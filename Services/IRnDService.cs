using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface IRnDService
    {
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project?> GetProjectByCodeAsync(string code);
        Task<Project> CreateProjectAsync(Project project);
        Task<Project> UpdateProjectStatusAsync(int projectId, ProjectStatus status);
        
        Task<IEnumerable<Prototype>> GetPrototypesByProjectAsync(int projectId);
        Task<Prototype> CreatePrototypeAsync(Prototype prototype);
        Task<Prototype> UpdatePrototypeStatusAsync(int prototypeId, PrototypeStatus status);
    }
}
