using System;
using System.Collections.Generic;

namespace FabrikaERP.Models
{
    public class Shift
    {
        public int Id { get; set; }
        public string ShiftName { get; set; } = string.Empty;
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        
        // Navigation Properties
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
