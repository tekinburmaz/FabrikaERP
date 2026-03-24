using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class InventoryPage : UserControl
    {
        public InventoryPage()
        {
            InitializeComponent();
            DataContext = new InventoryViewModel();
        }
    }
}
