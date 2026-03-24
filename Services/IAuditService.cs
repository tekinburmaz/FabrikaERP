using FabrikaERP.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface IAuditService
    {
        /// <summary>Son N denetim log kaydını getirir.</summary>
        Task<IEnumerable<AuditLog>> GetRecentLogsAsync(int count = 50);

        /// <summary>Belirli bir entity için tüm geçmiş değişiklikleri getirir.</summary>
        Task<IEnumerable<AuditLog>> GetLogsByEntityAsync(string entityName, string entityKey);

        /// <summary>Belirli bir kullanıcının işlem geçmişini getirir.</summary>
        Task<IEnumerable<AuditLog>> GetLogsByUserAsync(string userId, DateTime? from = null, DateTime? to = null);
    }
}
