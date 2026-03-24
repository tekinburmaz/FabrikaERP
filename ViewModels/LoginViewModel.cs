using FabrikaERP.Services;
using System.Windows;
using System.Windows.Input;

namespace FabrikaERP.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private readonly IAuthService _authService;
        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _errorMessage = string.Empty;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                // Clear error message when user starts typing again
                if (!string.IsNullOrEmpty(ErrorMessage)) ErrorMessage = string.Empty;
            }
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
            LoginCommand = new RelayCommand(ExecuteLogin, CanExecuteLogin);
        }

        private bool CanExecuteLogin(object? parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private async void ExecuteLogin(object? parameter)
        {
            var user = await _authService.LoginAsync(Username, Password);

            if (user != null)
            {
                // Login successful, open Dashboard and close this window
                var dashboard = new Views.DashboardWindow();
                dashboard.Show();

                var currentWindow = parameter as Window;
                currentWindow?.Close();
            }
            else
            {
                ErrorMessage = "Hatalı kullanıcı adı veya şifre. Lütfen tekrar deneyin.";
            }
        }
    }
}
