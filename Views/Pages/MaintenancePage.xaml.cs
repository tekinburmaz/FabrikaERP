using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class MaintenancePage : UserControl
    {
        public MaintenancePage()
        {
            InitializeComponent();
            DataContext = new MaintenanceViewModel();
        }
    }
}
