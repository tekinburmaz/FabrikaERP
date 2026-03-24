using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class HrPage : UserControl
    {
        public HrPage()
        {
            InitializeComponent();
            DataContext = new HrViewModel();
        }
    }
}
