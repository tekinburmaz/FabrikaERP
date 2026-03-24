using FabrikaERP.Data;
using FabrikaERP.Models;
using FabrikaERP.Services;
using FabrikaERP.Views.Pages;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.Windows;

namespace FabrikaERP.ViewModels
{
    public class DashboardViewModel : ObservableObject
    {
        // ── Hoş geldiniz mesajı (Antigravity pattern) ────
        private string _welcomeMessage = string.Empty;
        public string WelcomeMessage
        {
            get => _welcomeMessage;
            set => SetProperty(ref _welcomeMessage, value);
        }

        // ── Üst bar ───────────────────────────────────────
        private string _userName = "Admin";
        public string UserName
        {
            get => _userName;
            set => SetProperty(ref _userName, value);
        }

        private string _pageTitle = "Dashboard";
        public string PageTitle
        {
            get => _pageTitle;
            set => SetProperty(ref _pageTitle, value);
        }

        private string _breadcrumb = "Ana Sayfa / Dashboard";
        public string Breadcrumb
        {
            get => _breadcrumb;
            set => SetProperty(ref _breadcrumb, value);
        }

        // ── KPI ───────────────────────────────────────────
        private int    _productionRate;
        public int    ProductionRate { get => _productionRate; set => SetProperty(ref _productionRate, value); }

        private double _oeePercent;
        public double OeePercent    { get => _oeePercent;    set => SetProperty(ref _oeePercent, value); }

        private double _qualityRate;
        public double QualityRate   { get => _qualityRate;   set => SetProperty(ref _qualityRate, value); }

        private int _activeMachines;
        public int ActiveMachines   { get => _activeMachines; set => SetProperty(ref _activeMachines, value); }

        private int _totalMachines;
        public int TotalMachines    { get => _totalMachines;  set => SetProperty(ref _totalMachines, value); }

        private int _activeAlerts;
        public int ActiveAlerts     { get => _activeAlerts;   set => SetProperty(ref _activeAlerts, value); }

        // ── Koleksiyonlar ─────────────────────────────────
        public ObservableCollection<WorkOrder> RecentWorkOrders { get; } = new();
        public ObservableCollection<Alert>     ActiveAlertList  { get; } = new();

        // ── Navigasyon Komutları ──────────────────────────
        public RelayCommand NavigateDashboard   { get; }
        public RelayCommand NavigateShopFloor   { get; }
        public RelayCommand NavigateMES         { get; }
        public RelayCommand NavigateMRP         { get; }
        public RelayCommand NavigateQuality     { get; }
        public RelayCommand NavigateInventory   { get; }
        public RelayCommand NavigateMaintenance { get; }
        public RelayCommand NavigateSafetyEnv   { get; }
        public RelayCommand NavigateTrade       { get; }
        public RelayCommand NavigateRnD         { get; }
        public RelayCommand NavigateHR          { get; }
        public RelayCommand NavigateFinance     { get; }
        public RelayCommand NavigateReports     { get; }
        public RelayCommand NavigateSettings    { get; }
        public RelayCommand NavigatePlanning    { get; }
        public RelayCommand NavigateQualityMgmt { get; }
        public RelayCommand NavigatePlm         { get; }
        public RelayCommand NavigatePayroll     { get; }
        public RelayCommand LogoutCommand       { get; }
        public RelayCommand RefreshCommand      { get; }

        // ── 35 MODÜL NAVİGASYON KOMUTLARI ───────────────────
        public RelayCommand NavigateProdLogistics { get; }
        public RelayCommand NavigateEnergy        { get; }
        public RelayCommand NavigateOEE           { get; }
        public RelayCommand NavigateProdDev       { get; }
        public RelayCommand NavigateForecast      { get; }
        public RelayCommand NavigateMPS           { get; }
        public RelayCommand NavigateCapacity      { get; }
        public RelayCommand NavigateQMS           { get; }
        public RelayCommand NavigateCompliance    { get; }
        public RelayCommand NavigateGL            { get; }
        public RelayCommand NavigateAP            { get; }
        public RelayCommand NavigateAR            { get; }
        public RelayCommand NavigateTax           { get; }
        public RelayCommand NavigateCost          { get; }
        public RelayCommand NavigateBudget        { get; }
        public RelayCommand NavigateSalesOrder    { get; }
        public RelayCommand NavigateDistribution  { get; }
        public RelayCommand NavigateSalesAnalytics { get; }
        public RelayCommand NavigateWorkforce     { get; }
        public RelayCommand NavigateAudit         { get; }
        public RelayCommand NavigateDocs          { get; }

        public DashboardViewModel()
        {
            // Antigravity SessionManager pattern
            var user = SessionManager.Instance.CurrentUser;
            if (user != null)
            {
                UserName       = user.FullName.Length > 0 ? user.FullName : user.Username;
                WelcomeMessage = $"Hoş Geldiniz, {UserName} ({user.Role?.RoleName ?? "Admin"})";
            }
            else
            {
                WelcomeMessage = "Hoş Geldiniz!";
            }

            // Navigasyon komutları
            NavigateDashboard   = new RelayCommand(_ => GoTo<DashboardPage>("Dashboard",       "Ana Sayfa / Dashboard"));
            NavigateShopFloor   = new RelayCommand(_ => GoTo<ShopFloorPage>("Üretim Hattı",   "Üretim / Hattı"));
            NavigateMES         = new RelayCommand(_ => GoTo<MesPage>       ("İş Emirleri",    "Üretim / MES"));
            NavigateMRP         = new RelayCommand(_ => GoTo<MrpPage>       ("MRP Planlama",   "Üretim / MRP"));
            NavigateQuality     = new RelayCommand(_ => GoTo<QualityPage>   ("Kalite Kontrol", "Üretim / Kalite"));
            NavigateInventory   = new RelayCommand(_ => GoTo<InventoryPage> ("Stok Yönetimi",  "Stok / Stok"));
            NavigateMaintenance = new RelayCommand(_ => GoTo<MaintenancePage>("Bakım",          "Bakım / Bakım"));
            NavigateSafetyEnv   = new RelayCommand(_ => GoTo<SafetyEnvPage> ("İSG & Çevre",     "İSG / Çevre"));
            NavigateTrade       = new RelayCommand(_ => GoTo<TradePage>     ("Ticari İşlemler", "Ticari / CRM-SRM"));
            NavigateRnD         = new RelayCommand(_ => GoTo<RnDPage>       ("Ar-Ge Yönetimi",  "Üretim / Ar-Ge"));
            NavigateHR          = new RelayCommand(_ => GoTo<HrPage>        ("İnsan Kaynakları","Kurumsal / IK"));
            NavigateFinance     = new RelayCommand(_ => GoTo<FinancePage>   ("Finans Yönetimi", "Finans / Hesaplar"));
            NavigateReports     = new RelayCommand(_ => GoTo<ReportsPage>   ("Raporlar",        "Finans / Raporlar"));
            NavigateSettings    = new RelayCommand(_ => GoTo<SettingsPage>   ("Ayarlar",            "Sistem / Ayarlar"));
            
            // ── Yatay Genişleme Komutları (Phase 2) ───────────
            NavigatePlanning    = new RelayCommand(_ => GoTo<PlanningPage>   ("Üretim Planlama",    "Planlama / Kapasite"));
            NavigateQualityMgmt = new RelayCommand(_ => GoTo<QualityMgmtPage>("Kalite Yönetimi",    "Kalite / QMS"));
            NavigatePlm         = new RelayCommand(_ => GoTo<PlmPage>        ("Ürün Yaşam Döngüsü", "Ar-Ge / PLM"));
            NavigatePayroll     = new RelayCommand(_ => GoTo<PayrollPage>    ("Bordro & Özlük",     "Kurumsal / Bordro"));

            // ── 35 Modül Init ──────────────────────────────
            NavigateProdLogistics = new RelayCommand(_ => GoTo(new GenericModulePage("Üretim Lojistiği", "🚚", "Fabrika içi hammadde ve WIP akış yönetimi."), "Üretim Lojistiği", "Lojistik / Akış"));
            NavigateEnergy        = new RelayCommand(_ => GoTo(new GenericModulePage("Enerji Yönetimi", "⚡", "Gerçek zamanlı enerji tüketim ve tasarruf analizi."), "Enerji Yönetimi", "Sistem / Enerji"));
            NavigateOEE           = new RelayCommand(_ => GoTo(new GenericModulePage("OEE Analizi", "📈", "Kullanılabilirlik, Performans ve Kalite (OEE) metrikleri."), "OEE Analizi", "Verimlilik / OEE"));
            NavigateProdDev       = new RelayCommand(_ => GoTo(new GenericModulePage("Ürün Geliştirme", "🎨", "Ürün tasarım ve prototipleme süreç yönetimi."), "Ürün Geliştirme", "Ar-Ge / Geliştirme"));
            
            NavigateForecast      = new RelayCommand(_ => GoTo(new GenericModulePage("Talep Tahmini", "🔮", "GEçmiş verilerle geleceğe dönük talep projeksiyonları."), "Talep Tahmini", "Planlama / Tahmin"));
            NavigateMPS           = new RelayCommand(_ => GoTo(new GenericModulePage("Ana Planlama (MPS)", "📅", "Haftalık ve aylık ana üretim çizelgeleme."), "Ana Planlama", "Planlama / MPS"));
            NavigateCapacity      = new RelayCommand(_ => GoTo<PlanningPage>("Kapasite Planlama", "Planlama / CRP"));
            
            NavigateQMS           = new RelayCommand(_ => GoTo<QualityMgmtPage>("Kalite Sistemi (QMS)", "Kalite / QMS"));
            NavigateCompliance    = new RelayCommand(_ => GoTo(new GenericModulePage("Yasal Uyumluluk", "⚖️", "Resmi gazete ve yasal mevzuat takip modülü."), "Yasal Uyumluluk", "Sistem / Mevzuat"));
            
            NavigateGL            = new RelayCommand(_ => GoTo(new GenericModulePage("Genel Muhasebe", "📒", "Bilanço, mizan ve yevmiye defteri yönetimi."), "Genel Muhasebe", "Finans / GL"));
            NavigateAP            = new RelayCommand(_ => GoTo(new GenericModulePage("Borçlar (AP)", "🧾", "Tedarikçi faturaları ve ödeme takibi."), "Borçlar", "Finans / AP"));
            NavigateAR            = new RelayCommand(_ => GoTo(new GenericModulePage("Alacaklar (AR)", "💰", "Müşteri faturaları ve tahsilat takibi."), "Alacaklar", "Finans / AR"));
            NavigateTax           = new RelayCommand(_ => GoTo(new GenericModulePage("Vergi Yönetimi", "🏛️", "KDV, Muhtasar ve Kurumlar Vergisi beyannameleri."), "Vergi Yönetimi", "Finans / Vergi"));
            NavigateCost          = new RelayCommand(_ => GoTo(new GenericModulePage("Maliyet Muhasebesi", "📐", "Ürün bazlı standart ve fiili maliyet analizi."), "Maliyet Muhasebesi", "Finans / Maliyet"));
            NavigateBudget        = new RelayCommand(_ => GoTo(new GenericModulePage("Bütçe Yönetimi", "📊", "Departman bazlı bütçe planlama ve kontrol."), "Bütçe Yönetimi", "Finans / Bütçe"));
            
            NavigateSalesOrder    = new RelayCommand(_ => GoTo(new GenericModulePage("Sipariş Yönetimi", "🛍️", "Müşteri sipariş girişi ve onay süreçleri."), "Sipariş Yönetimi", "Satış / Sipariş"));
            NavigateDistribution  = new RelayCommand(_ => GoTo(new GenericModulePage("Sevkiyat & Dağıtım", "📦", "Nakliye planlama ve sevkiyat takibi."), "Sevkiyat", "Lojistik / Dağıtım"));
            NavigateSalesAnalytics = new RelayCommand(_ => GoTo(new GenericModulePage("Satış Analizi", "📊", "Satış performans ve bölge analiz raporları."), "Satış Analizi", "Satış / Analiz"));
            
            NavigateWorkforce     = new RelayCommand(_ => GoTo(new GenericModulePage("İş Gücü Matrisi", "👷", "Personel yetkinlik ve eğitim takip sistemi."), "İş Gücü", "Kurumsal / Matris"));
            NavigateAudit         = new RelayCommand(_ => GoTo(new GenericModulePage("Denetim & Log", "🔍", "Sistem geneli işlem denetimi ve günlükleri."), "Denetim", "Sistem / Audit"));
            NavigateDocs          = new RelayCommand(_ => GoTo(new GenericModulePage("Doküman Yönetimi", "📄", "ISO prosedürleri ve teknik doküman arşivi."), "Dokümanlar", "Sistem / Doküman"));

            LogoutCommand       = new RelayCommand(_ => Logout());
            RefreshCommand      = new RelayCommand(_ => _ = LoadDataAsync());

            _ = LoadDataAsync();
        }

        private void GoTo<T>(string title, string crumb) where T : System.Windows.Controls.UserControl, new()
        {
            GoTo(new T(), title, crumb);
        }

        private void GoTo(System.Windows.Controls.UserControl page, string title, string crumb)
        {
            PageTitle  = title;
            Breadcrumb = crumb;
            NavigationService.Instance.NavigateTo(page, title);
        }

        public async Task LoadDataAsync()
        {
            try
            {
                await using var db = new FabrikaDbContext();

                var snapshot = await db.KpiSnapshots.OrderByDescending(k => k.Timestamp).FirstOrDefaultAsync();
                if (snapshot is not null)
                {
                    ProductionRate = snapshot.ProductionRate;
                    OeePercent     = snapshot.OeePercent;
                    QualityRate    = snapshot.QualityRate;
                    ActiveMachines = snapshot.ActiveMachines;
                    TotalMachines  = snapshot.TotalMachines;
                }
                else
                {
                    var machines   = await db.Machines.ToListAsync();
                    ActiveMachines = machines.Count(m => m.Status == MachineStatus.Running);
                    TotalMachines  = machines.Count;
                    OeePercent     = machines.Any(m => m.OeeCurrent > 0)
                        ? machines.Where(m => m.OeeCurrent > 0).Average(m => m.OeeCurrent)
                        : 87.3;
                    ProductionRate = 1247;
                    QualityRate    = 99.1;
                }

                var orders = await db.WorkOrders
                    .Include(w => w.Machine)
                    .OrderByDescending(w => w.CreatedAt)
                    .Take(8)
                    .ToListAsync();
                RecentWorkOrders.Clear();
                foreach (var o in orders) RecentWorkOrders.Add(o);

                var alerts = await db.Alerts
                    .Where(a => !a.IsResolved)
                    .OrderByDescending(a => a.Severity)
                    .Take(5)
                    .ToListAsync();
                ActiveAlertList.Clear();
                foreach (var a in alerts) ActiveAlertList.Add(a);
                ActiveAlerts = ActiveAlertList.Count;
            }
            catch
            {
                LoadSampleData();
            }
        }

        private void LoadSampleData()
        {
            ProductionRate = 1247; OeePercent = 87.3; QualityRate = 99.1;
            ActiveMachines = 6;    TotalMachines = 8;  ActiveAlerts = 3;

            RecentWorkOrders.Clear();
            RecentWorkOrders.Add(new WorkOrder { OrderNumber = "WO-2024-0891", ProductName = "Dişli Grubu A-12",  PlannedQty = 500,  ProducedQty = 390, Status = WorkOrderStatus.InProgress, PlannedEnd = DateTime.Today });
            RecentWorkOrders.Add(new WorkOrder { OrderNumber = "WO-2024-0890", ProductName = "Gövde Kasası B-7",  PlannedQty = 200,  ProducedQty = 90,  Status = WorkOrderStatus.OnHold,     PlannedEnd = DateTime.Today.AddDays(1) });
            RecentWorkOrders.Add(new WorkOrder { OrderNumber = "WO-2024-0889", ProductName = "Rulman Seti C-3",   PlannedQty = 1000, ProducedQty = 1000,Status = WorkOrderStatus.Completed,  PlannedEnd = DateTime.Today.AddDays(-1) });
            RecentWorkOrders.Add(new WorkOrder { OrderNumber = "WO-2024-0888", ProductName = "Piston Grubu D-1",  PlannedQty = 350,  ProducedQty = 0,   Status = WorkOrderStatus.Delayed,    PlannedEnd = DateTime.Today.AddDays(2) });

            ActiveAlertList.Clear();
            ActiveAlertList.Add(new Alert { Title = "Makine B-7 Ani Durdu",  Severity = AlertSeverity.Critical, CreatedAt = DateTime.Now.AddHours(-2) });
            ActiveAlertList.Add(new Alert { Title = "Hammadde Stok Kritik",  Severity = AlertSeverity.Warning,  CreatedAt = DateTime.Now.AddHours(-1) });
            ActiveAlertList.Add(new Alert { Title = "A Vardiyası Bitiyor",   Severity = AlertSeverity.Info,     CreatedAt = DateTime.Now.AddMinutes(-30) });
        }

        private void Logout()
        {
            SessionManager.Instance.Logout();
            var login = new Views.LoginWindow();
            login.Show();
            Application.Current.Windows
                .OfType<Views.DashboardWindow>()
                .FirstOrDefault()?.Close();
        }
    }
}
