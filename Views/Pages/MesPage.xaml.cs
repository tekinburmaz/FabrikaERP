using FabrikaERP.ViewModels;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class MesPage : UserControl
    {
        public MesPage()
        {
            InitializeComponent();
            var vm = new MesViewModel();
            DataContext = vm;
            
            // Sayfa yüklendiğinde ve UI thread hazır olduğunda veriyi yükle
            Loaded += (s, e) => _ = vm.LoadAsync();
        }
    }
}
