using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class TradePage : UserControl
    {
        public TradePage()
        {
            InitializeComponent();
            DataContext = new TradeViewModel();
        }
    }
}
