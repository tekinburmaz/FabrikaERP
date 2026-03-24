using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public class NotificationService : INotificationService
    {
        private readonly FabrikaDbContext _db;

        public NotificationService(FabrikaDbContext db)
        {
            _db = db;
        }

        public async Task<Alert> CreateAlertAsync(string title, string message, AlertSeverity severity, AlertCategory category, int? machineId = null)
        {
            var alert = new Alert
            {
                Title      = title,
                Message    = message,
                Severity   = severity,
                Category   = category,
                MachineId  = machineId,
                CreatedAt  = DateTime.UtcNow,
                IsRead     = false
            };

            _db.Alerts.Add(alert);
            await _db.SaveChangesAsync();
            return alert;
        }

        public async Task<IEnumerable<Alert>> GetUnreadAlertsAsync()
        {
            return await _db.Alerts
                .Where(a => !a.IsRead)
                .OrderByDescending(a => a.Severity)
                .ThenByDescending(a => a.CreatedAt)
                .ToListAsync();
        }

        public async Task MarkAsReadAsync(int alertId)
        {
            var alert = await _db.Alerts.FindAsync(alertId);
            if (alert != null)
            {
                alert.IsRead   = true;
                alert.ReadAt   = DateTime.UtcNow;
                await _db.SaveChangesAsync();
            }
        }

        public async Task MarkAllAsReadAsync()
        {
            var unread = await _db.Alerts.Where(a => !a.IsRead).ToListAsync();
            foreach (var a in unread)
            {
                a.IsRead = true;
                a.ReadAt = DateTime.UtcNow;
            }
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Alert>> GetRecentAlertsAsync(int count = 20)
        {
            return await _db.Alerts
                .OrderByDescending(a => a.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        public async Task RaiseBreakdownAlertAsync(int machineId, string machineName)
        {
            await CreateAlertAsync(
                title:     $"Makine Arızası: {machineName}",
                message:   $"{machineName} ({machineId}) beklenmedik durma tespit edildi. Bakım ekibi bilgilendirildi.",
                severity:  AlertSeverity.Critical,
                category:  AlertCategory.Machine,
                machineId: machineId
            );
        }

        public async Task RaiseLowStockAlertAsync(string itemName, double currentQty, double minQty)
        {
            await CreateAlertAsync(
                title:   $"Düşük Stok: {itemName}",
                message: $"{itemName} stoku kritik seviyede. Mevcut: {currentQty:N0}, Minimum: {minQty:N0}. Satın alma talebi oluşturulması önerilir.",
                severity: AlertSeverity.Warning,
                category: AlertCategory.Inventory
            );
        }
    }
}
