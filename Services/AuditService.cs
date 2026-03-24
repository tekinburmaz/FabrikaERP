using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class AuditService : IAuditService
    {
        private readonly FabrikaDbContext _db;

        public AuditService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<AuditLog>> GetRecentLogsAsync(int count = 50)
        {
            return await _db.AuditLogs
                .OrderByDescending(a => a.ChangedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByEntityAsync(string entityName, string entityKey)
        {
            return await _db.AuditLogs
                .Where(a => a.EntityName == entityName && a.EntityKey == entityKey)
                .OrderByDescending(a => a.ChangedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<AuditLog>> GetLogsByUserAsync(string userId, DateTime? from = null, DateTime? to = null)
        {
            var query = _db.AuditLogs.Where(a => a.UserId == userId);

            if (from.HasValue)
                query = query.Where(a => a.ChangedAt >= from.Value);

            if (to.HasValue)
                query = query.Where(a => a.ChangedAt <= to.Value);

            return await query.OrderByDescending(a => a.ChangedAt).ToListAsync();
        }
    }
}
