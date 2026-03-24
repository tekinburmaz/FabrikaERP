using FabrikaERP.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FabrikaERP.Views.Pages
{
    public partial class SettingsPage : UserControl
    {
        public SettingsPage()
        {
            InitializeComponent();
            DataContext = new SettingsViewModel();
        }

        // PasswordBox binding helper — PasswordBox.Password cannot be data-bound directly
        private void PasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is SettingsViewModel vm)
            {
                vm.CurrentPassword = TxtCurrentPwd.Password;
                vm.NewPassword     = TxtNewPwd.Password;
                vm.ConfirmPassword = TxtConfirmPwd.Password;
            }
        }
    }
}
