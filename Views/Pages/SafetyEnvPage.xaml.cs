using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class SafetyEnvPage : UserControl
    {
        public SafetyEnvPage()
        {
            InitializeComponent();
            DataContext = new SafetyEnvViewModel();
        }
    }
}
