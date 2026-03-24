using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class QualityPage : UserControl
    {
        public QualityPage()
        {
            InitializeComponent();
            DataContext = new QualityViewModel();
        }
    }
}
