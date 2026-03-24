using FabrikaERP.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class DashboardPage : UserControl
    {
        public DashboardPage()
        {
            InitializeComponent();
            // DataContext = DashboardWindow'un ViewModel'ini miras alır (Parent üzerinden)
            Loaded += (_, _) => BindToParentViewModel();
        }

        private void BindToParentViewModel()
        {
            // DashboardWindow'dan DashboardViewModel'i bul ve set et
            var window = Window.GetWindow(this);
            if (window?.DataContext is DashboardViewModel vm)
                DataContext = vm;
        }
    }
}
