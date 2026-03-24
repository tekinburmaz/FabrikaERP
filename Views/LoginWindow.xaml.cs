using FabrikaERP.Data;
using FabrikaERP.Services;
using FabrikaERP.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace FabrikaERP.Views
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            
            // In a real DI container setup, DbContext and AuthService would be injected.
            // For bootstrap simplicity:
            var dbContext = new FabrikaDbContext();
            var authService = new AuthService(dbContext);
            DataContext = new LoginViewModel(authService);
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (DataContext is LoginViewModel viewModel)
            {
                viewModel.Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
