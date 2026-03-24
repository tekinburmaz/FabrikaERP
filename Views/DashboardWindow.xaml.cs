using FabrikaERP.Services;
using FabrikaERP.ViewModels;
using FabrikaERP.Views.Pages;
using System.Windows;

namespace FabrikaERP.Views
{
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
        {
            InitializeComponent();
            var vm = new DashboardViewModel();
            DataContext = vm;

            // NavigationService'e ContentControl'ü kaydet
            NavigationService.Instance.Register(MainContent);

            // İlk sayfa: Dashboard KPI
            NavigationService.Instance.NavigateTo<DashboardPage>("Dashboard");

            // Sürükleme (başlık çubuğu yok)
            MouseLeftButtonDown += (_, e) =>
            {
                if (e.ClickCount == 2) ToggleMaximize();
                else DragMove();
            };
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
            => Application.Current.Shutdown();

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
            => WindowState = WindowState.Minimized;

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
            => ToggleMaximize();

        private void ToggleMaximize()
            => WindowState = WindowState == WindowState.Maximized
                ? WindowState.Normal
                : WindowState.Maximized;
    }
}
