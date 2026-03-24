using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class FinancePage : UserControl
    {
        public FinancePage()
        {
            InitializeComponent();
            DataContext = new FinanceViewModel();
        }
    }
}
