using System;

namespace FabrikaERP.Models
{
    public enum IncidentSeverity
    {
        NearMiss, // Ramak kala
        Minor,
        Moderate,
        Major,
        Critical
    }

    public class SafetyIncident
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime IncidentDate { get; set; }
        
        public IncidentSeverity Severity { get; set; } = IncidentSeverity.Minor;
        public string Location { get; set; } = string.Empty;
        
        public string ReportedBy { get; set; } = string.Empty;
        public string? CorrectiveAction { get; set; }
        
        public bool IsClosed { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
