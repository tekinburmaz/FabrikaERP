using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class MrpPage : UserControl
    {
        public MrpPage()
        {
            InitializeComponent();
            DataContext = new MrpViewModel();
        }
    }
}
