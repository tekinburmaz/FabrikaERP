using System;
using System.Collections.Generic;

namespace FabrikaERP.Models
{
    public enum ProjectStatus
    {
        Proposed,
        InAnalysis,
        Development,
        Prototyping,
        Testing,
        Completed,
        Cancelled
    }

    public class Project
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ProjectStatus Status { get; set; } = ProjectStatus.Proposed;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Manager { get; set; } = string.Empty;
        public decimal Budget { get; set; }
        
        public ICollection<Prototype> Prototypes { get; set; } = new List<Prototype>();
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
