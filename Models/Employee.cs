using System;

namespace FabrikaERP.Models
{
    public enum EmployeeStatus
    {
        Active,
        OnLeave,
        Resigned,
        Suspended
    }

    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";
        
        public string Department { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeStatus Status { get; set; } = EmployeeStatus.Active;
        
        /// <summary>Kullanıcı hesabı ile ilişkilendirme (isteğe bağlı).</summary>
        public int? UserId { get; set; }
        public User? User { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
