using System;

namespace FabrikaERP.Models
{
    public enum PrototypeStatus
    {
        Designing,
        Manufacturing,
        Testing,
        Validated,
        Failed
    }

    public class Prototype
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int ProjectId { get; set; }
        public Project? Project { get; set; }
        
        public PrototypeStatus Status { get; set; } = PrototypeStatus.Designing;
        public string Version { get; set; } = "v1.0";
        public string TestResults { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
