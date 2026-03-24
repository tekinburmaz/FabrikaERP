using System;

namespace FabrikaERP.Models
{
    /// <summary>
    /// Veritabanındaki her Ekleme / Güncelleme / Silme işlemini otomatik kaydeden denetim logu.
    /// FabrikaDbContext.SaveChangesAsync() override'ı tarafından doldurulur.
    /// </summary>
    public class AuditLog
    {
        public int    Id           { get; set; }

        /// <summary>İşlemi yapan kullanıcının kimliği (SessionManager'dan alınır).</summary>
        public string? UserId      { get; set; }

        /// <summary>Etkilenen EF Core entity sınıfının adı (örn. "WorkOrder").</summary>
        public string  EntityName  { get; set; } = string.Empty;

        /// <summary>Birincil anahtar değeri (int veya string olabilir, string olarak saklanır).</summary>
        public string  EntityKey   { get; set; } = string.Empty;

        /// <summary>Yapılan işlem türü.</summary>
        public AuditAction Action  { get; set; }

        /// <summary>Güncelleme / Silme öncesi satırın JSON temsili.</summary>
        public string? OldValues   { get; set; }

        /// <summary>Ekleme / Güncelleme sonrası satırın JSON temsili.</summary>
        public string? NewValues   { get; set; }

        public DateTime ChangedAt  { get; set; } = DateTime.UtcNow;
    }

    public enum AuditAction
    {
        Insert = 1,
        Update = 2,
        Delete = 3
    }
}
