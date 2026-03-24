using System.Windows.Controls;

namespace FabrikaERP.Services
{
    /// <summary>
    /// DashboardWindow içindeki ContentControl'ü yöneten basit navigasyon servisi.
    /// MVVM: ViewModel'ler bu servis aracılığıyla sayfa geçişi yapabilir.
    /// </summary>
    public class NavigationService
    {
        private static NavigationService? _instance;
        public static NavigationService Instance => _instance ??= new NavigationService();

        private ContentControl? _frame;

        public event EventHandler<string>? PageChanged;

        private NavigationService() { }

        /// <summary>DashboardWindow başladığında ContentControl'ü kaydeder.</summary>
        public void Register(ContentControl frame) => _frame = frame;

        /// <summary>Verilen UserControl'ü ana alana yükler.</summary>
        public void NavigateTo(UserControl page, string pageTitle = "")
        {
            if (_frame is null) return;
            _frame.Content = page;
            PageChanged?.Invoke(this, pageTitle);
        }

        /// <summary>Type ile sayfa yükleme — parametre gerektirmeyen sayfalar için.</summary>
        public void NavigateTo<T>(string pageTitle = "") where T : UserControl, new()
            => NavigateTo(new T(), pageTitle);
    }
}
