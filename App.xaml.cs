using System.Configuration;
using System.Data;
using System.Windows;

namespace FabrikaERP;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        Current.DispatcherUnhandledException += (s, args) =>
        {
            MessageBox.Show($"Kritik Hata: {args.Exception.Message}\n\nStack: {args.Exception.StackTrace}", "Sistem Hatası", MessageBoxButton.OK, MessageBoxImage.Error);
            args.Handled = true;
        };
    }
}

