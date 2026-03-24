using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class RnDPage : UserControl
    {
        public RnDPage()
        {
            InitializeComponent();
            DataContext = new RnDViewModel();
        }
    }
}
