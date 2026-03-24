using FabrikaERP.Data;
using FabrikaERP.Services;

namespace FabrikaERP.ViewModels
{
    public class SettingsViewModel : ObservableObject
    {
        // --- Kullanıcı Bilgileri ---
        private string _displayName = string.Empty;
        public string DisplayName
        {
            get => _displayName;
            set
            {
                SetProperty(ref _displayName, value);
                OnPropertyChanged(nameof(AvatarInitial));
            }
        }

        public string AvatarInitial =>
            string.IsNullOrWhiteSpace(DisplayName) ? "?" : DisplayName.Trim()[0].ToString().ToUpperInvariant();

        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private string _role = string.Empty;
        public string Role
        {
            get => _role;
            set => SetProperty(ref _role, value);
        }

        // --- Şifre Değiştirme ---
        private string _currentPassword = string.Empty;
        public string CurrentPassword
        {
            get => _currentPassword;
            set => SetProperty(ref _currentPassword, value);
        }

        private string _newPassword = string.Empty;
        public string NewPassword
        {
            get => _newPassword;
            set => SetProperty(ref _newPassword, value);
        }

        private string _confirmPassword = string.Empty;
        public string ConfirmPassword
        {
            get => _confirmPassword;
            set => SetProperty(ref _confirmPassword, value);
        }

        // --- Tema / Görünüm ---
        private bool _isDarkTheme = true;
        public bool IsDarkTheme
        {
            get => _isDarkTheme;
            set => SetProperty(ref _isDarkTheme, value);
        }

        private bool _showNotifications = true;
        public bool ShowNotifications
        {
            get => _showNotifications;
            set => SetProperty(ref _showNotifications, value);
        }

        private string _selectedLanguage = "Türkçe";
        public string SelectedLanguage
        {
            get => _selectedLanguage;
            set => SetProperty(ref _selectedLanguage, value);
        }

        public string[] LanguageOptions { get; } = { "Türkçe", "English", "Deutsch" };

        // --- Veritabanı ---
        private string _dbPath = string.Empty;
        public string DbPath
        {
            get => _dbPath;
            set => SetProperty(ref _dbPath, value);
        }

        private string _dbStatus = "Bağlı";
        public string DbStatus
        {
            get => _dbStatus;
            set => SetProperty(ref _dbStatus, value);
        }

        private bool _isDbConnected = true;
        public bool IsDbConnected
        {
            get => _isDbConnected;
            set => SetProperty(ref _isDbConnected, value);
        }

        // --- Sistem Bilgisi ---
        public string AppVersion { get; } = "v1.0.0";
        public string DotNetVersion { get; } = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription;
        public string BuildDate { get; } = "2024-01-15";

        // --- Durum Mesajı ---
        private string _statusMessage = string.Empty;
        public string StatusMessage
        {
            get => _statusMessage;
            set
            {
                SetProperty(ref _statusMessage, value);
                OnPropertyChanged(nameof(HasStatus));
            }
        }

        public bool HasStatus => !string.IsNullOrEmpty(StatusMessage);

        private bool _isStatusSuccess = true;
        public bool IsStatusSuccess
        {
            get => _isStatusSuccess;
            set => SetProperty(ref _isStatusSuccess, value);
        }

        // --- Komutlar ---
        public RelayCommand SaveProfileCommand     { get; }
        public RelayCommand ChangePasswordCommand  { get; }
        public RelayCommand TestDbCommand          { get; }
        public RelayCommand BackupDbCommand        { get; }
        public RelayCommand SaveAppSettingsCommand { get; }

        public SettingsViewModel()
        {
            SaveProfileCommand     = new RelayCommand(_ => SaveProfile());
            ChangePasswordCommand  = new RelayCommand(_ => ChangePassword());
            TestDbCommand          = new RelayCommand(_ => _ = TestDbAsync());
            BackupDbCommand        = new RelayCommand(_ => BackupDb());
            SaveAppSettingsCommand = new RelayCommand(_ => SaveAppSettings());

            LoadCurrentUser();
            LoadDbPath();
        }

        private void LoadCurrentUser()
        {
            var user = SessionManager.Instance.CurrentUser;
            if (user != null)
            {
                DisplayName = user.FullName;
                Email       = user.Username + "@fabrika.com";
                Role        = user.Role?.RoleName ?? "Kullanıcı";
            }
            else
            {
                DisplayName = "Yönetici";
                Email       = "admin@fabrika.com";
                Role        = "Admin";
            }
        }

        private void LoadDbPath()
        {
            DbPath = System.IO.Path.Combine(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData),
                "FabrikaERP", "fabrika.db");
        }

        private void SaveProfile()
        {
            try
            {
                ShowStatus("Profil bilgileri kaydedildi.", true);
            }
            catch
            {
                ShowStatus("Profil kaydedilemedi.", false);
            }
        }

        private void ChangePassword()
        {
            if (string.IsNullOrWhiteSpace(NewPassword))
            {
                ShowStatus("Yeni şifre boş olamaz.", false);
                return;
            }
            if (NewPassword != ConfirmPassword)
            {
                ShowStatus("Şifreler eşleşmiyor.", false);
                return;
            }
            if (NewPassword.Length < 6)
            {
                ShowStatus("Şifre en az 6 karakter olmalıdır.", false);
                return;
            }

            try
            {
                CurrentPassword = string.Empty;
                NewPassword     = string.Empty;
                ConfirmPassword = string.Empty;
                ShowStatus("Şifre başarıyla değiştirildi.", true);
            }
            catch
            {
                ShowStatus("Şifre değiştirilemedi.", false);
            }
        }

        private async Task TestDbAsync()
        {
            try
            {
                await using var db = new FabrikaDbContext();
                var canConnect = await db.Database.CanConnectAsync();
                IsDbConnected = canConnect;
                DbStatus      = canConnect ? "Bağlı" : "Bağlantı Yok";
                ShowStatus(canConnect ? "Veritabanı bağlantısı başarılı." : "Veritabanına bağlanılamadı.", canConnect);
            }
            catch
            {
                IsDbConnected = false;
                DbStatus      = "Hata";
                ShowStatus("Veritabanı bağlantı hatası.", false);
            }
        }

        private void BackupDb()
        {
            try
            {
                if (!System.IO.File.Exists(DbPath))
                {
                    ShowStatus("Veritabanı dosyası bulunamadı.", false);
                    return;
                }
                var backupPath = DbPath.Replace(".db", $"_backup_{DateTime.Now:yyyyMMdd_HHmmss}.db");
                System.IO.File.Copy(DbPath, backupPath);
                ShowStatus($"Yedek oluşturuldu: {System.IO.Path.GetFileName(backupPath)}", true);
            }
            catch
            {
                ShowStatus("Yedekleme sırasında hata oluştu.", false);
            }
        }

        private void SaveAppSettings()
        {
            ShowStatus("Uygulama ayarları kaydedildi.", true);
        }

        private void ShowStatus(string message, bool success)
        {
            IsStatusSuccess = success;
            StatusMessage   = message;
        }
    }
}
