using FabrikaERP.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FabrikaERP.Services
{
    public interface INotificationService
    {
        /// <summary>Yeni bir alarm/bildirim oluşturur ve kaydeder.</summary>
        Task<Alert> CreateAlertAsync(string title, string message, AlertSeverity severity, AlertCategory category, int? machineId = null);

        /// <summary>Okunmamış (IsRead == false) tüm uyarıları getirir.</summary>
        Task<IEnumerable<Alert>> GetUnreadAlertsAsync();

        /// <summary>Belirli bir alarm'ı okundu olarak işaretler.</summary>
        Task MarkAsReadAsync(int alertId);

        /// <summary>Tüm alarmları okundu olarak işaretler.</summary>
        Task MarkAllAsReadAsync();

        /// <summary>Son N alarmı getirir (okundu/okunmadı fark etmez).</summary>
        Task<IEnumerable<Alert>> GetRecentAlertsAsync(int count = 20);

        /// <summary>Kritik makine arızası gibi durumlarda çağrılır; ilgili standart uyarıyı otomatik oluşturur.</summary>
        Task RaiseBreakdownAlertAsync(int machineId, string machineName);

        /// <summary>Stok kritiğe düştüğünde çağrılır.</summary>
        Task RaiseLowStockAlertAsync(string itemName, double currentQty, double minQty);
    }
}
