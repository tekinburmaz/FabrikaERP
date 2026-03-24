using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class ShopFloorPage : UserControl
    {
        public ShopFloorPage()
        {
            InitializeComponent();
            DataContext = new ShopFloorViewModel();
        }
    }
}
