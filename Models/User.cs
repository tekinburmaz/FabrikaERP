using System;

namespace FabrikaERP.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        
        // Navigation Properties
        public int RoleId { get; set; }
        public Role? Role { get; set; }
        
        public int? ShiftId { get; set; }
        public Shift? Shift { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;
    }
}
