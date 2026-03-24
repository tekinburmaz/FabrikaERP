using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FabrikaERP.ViewModels
{
    public class ReportSummaryItem
    {
        public string Label  { get; set; } = string.Empty;
        public string Value  { get; set; } = string.Empty;
        public string Change { get; set; } = string.Empty;
        public bool   IsUp   { get; set; }
    }

    public class ReportsViewModel : ObservableObject
    {
        public ObservableCollection<ReportSummaryItem> ProductionSummary { get; } = new();
        public ObservableCollection<ReportSummaryItem> QualitySummary    { get; } = new();
        public ObservableCollection<ReportSummaryItem> MaintenanceSummary { get; } = new();
        public ObservableCollection<ReportSummaryItem> InventorySummary  { get; } = new();

        private string _selectedPeriod = "Bu Ay";
        public string SelectedPeriod
        {
            get => _selectedPeriod;
            set { SetProperty(ref _selectedPeriod, value); _ = LoadAsync(); }
        }

        public string[] PeriodOptions { get; } = { "Bugün", "Bu Hafta", "Bu Ay", "Bu Çeyrek", "Bu Yıl" };

        public RelayCommand RefreshCommand   { get; }
        public RelayCommand ExportPdfCommand { get; }
        public RelayCommand ExportXlsCommand { get; }

        public ReportsViewModel()
        {
            RefreshCommand   = new RelayCommand(_ => _ = LoadAsync());
            ExportPdfCommand = new RelayCommand(_ => ExportPdf());
            ExportXlsCommand = new RelayCommand(_ => ExportXls());
            _ = LoadAsync();
        }

        public async Task LoadAsync()
        {
            try
            {
                await using var db = new FabrikaDbContext();
                var orders    = await db.WorkOrders.ToListAsync();
                var quality   = await db.QualityRecords.ToListAsync();
                var inventory = await db.InventoryItems.ToListAsync();
                var maint     = await db.MaintenanceRecords.ToListAsync();

                BuildProductionSummary(orders);
                BuildQualitySummary(quality);
                BuildMaintenanceSummary(maint);
                BuildInventorySummary(inventory);
            }
            catch { LoadSampleData(); }
        }

        private void BuildProductionSummary(List<WorkOrder> orders)
        {
            ProductionSummary.Clear();
            ProductionSummary.Add(new ReportSummaryItem { Label = "Toplam İş Emri",   Value = orders.Count.ToString(),                                          Change = "▲ 8%",   IsUp = true });
            ProductionSummary.Add(new ReportSummaryItem { Label = "Tamamlanan",        Value = orders.Count(o => o.Status == WorkOrderStatus.Completed).ToString(), Change = "▲ 12%",  IsUp = true });
            ProductionSummary.Add(new ReportSummaryItem { Label = "Toplam Üretilen",   Value = $"{orders.Sum(o => o.ProducedQty):N0} adet",                      Change = "▲ 5.2%", IsUp = true });
            ProductionSummary.Add(new ReportSummaryItem { Label = "Geciken Emirler",   Value = orders.Count(o => o.Status == WorkOrderStatus.Delayed).ToString(), Change = "▼ 3%",   IsUp = false });
        }

        private void BuildQualitySummary(List<QualityRecord> records)
        {
            QualitySummary.Clear();
            var pass = records.Count(r => r.Result == QualityResult.Pass);
            var rate = records.Count > 0 ? (pass / (double)records.Count) * 100 : 99.1;
            QualitySummary.Add(new ReportSummaryItem { Label = "Toplam Kontrol",  Value = records.Count.ToString(),           Change = "▲ 15%",  IsUp = true });
            QualitySummary.Add(new ReportSummaryItem { Label = "Geçiş Oranı",    Value = $"{rate:F1}%",                       Change = "▲ 0.3%", IsUp = true });
            QualitySummary.Add(new ReportSummaryItem { Label = "Başarısız Ürün", Value = records.Count(r => r.Result == QualityResult.Fail).ToString(), Change = "▼ 2",   IsUp = false });
            QualitySummary.Add(new ReportSummaryItem { Label = "Koşullu Geçen",  Value = records.Count(r => r.Result == QualityResult.Conditional).ToString(), Change = "=",   IsUp = true });
        }

        private void BuildMaintenanceSummary(List<MaintenanceRecord> records)
        {
            MaintenanceSummary.Clear();
            MaintenanceSummary.Add(new ReportSummaryItem { Label = "Toplam Bakım",    Value = records.Count.ToString(),                                             Change = "▲ 2",  IsUp = true });
            MaintenanceSummary.Add(new ReportSummaryItem { Label = "Tamamlanan",      Value = records.Count(r => r.Status == MaintenanceStatus.Completed).ToString(), Change = "▲ 1",  IsUp = true });
            MaintenanceSummary.Add(new ReportSummaryItem { Label = "Toplam Maliyet",  Value = $"₺ {records.Where(r => r.Cost.HasValue).Sum(r => r.Cost!.Value):N0}", Change = "▲ 8%", IsUp = false });
            MaintenanceSummary.Add(new ReportSummaryItem { Label = "Ortalama Süre",   Value = "4.2 saat",                                                            Change = "▼ 0.5h", IsUp = true });
        }

        private void BuildInventorySummary(List<InventoryItem> items)
        {
            InventorySummary.Clear();
            InventorySummary.Add(new ReportSummaryItem { Label = "Toplam Kalem",  Value = items.Count.ToString(),                                         Change = "=",    IsUp = true });
            InventorySummary.Add(new ReportSummaryItem { Label = "Stok Değeri",   Value = $"₺ {items.Sum(i => i.StockValue):N0}",                        Change = "▲ 3%", IsUp = true });
            InventorySummary.Add(new ReportSummaryItem { Label = "Kritik Kalem",  Value = items.Count(i => i.IsLowStock).ToString(),                     Change = "▲ 1",  IsUp = false });
            InventorySummary.Add(new ReportSummaryItem { Label = "Tedarikçi",     Value = items.Where(i => i.Supplier != null).Select(i => i.Supplier).Distinct().Count().ToString(), Change = "=", IsUp = true });
        }

        private void LoadSampleData()
        {
            ProductionSummary.Clear();
            ProductionSummary.Add(new ReportSummaryItem { Label = "Toplam İş Emri",  Value = "28",          Change = "▲ 8%",   IsUp = true });
            ProductionSummary.Add(new ReportSummaryItem { Label = "Tamamlanan",       Value = "18",          Change = "▲ 12%",  IsUp = true });
            ProductionSummary.Add(new ReportSummaryItem { Label = "Toplam Üretilen",  Value = "24,750 adet", Change = "▲ 5.2%", IsUp = true });
            ProductionSummary.Add(new ReportSummaryItem { Label = "Geciken Emirler",  Value = "3",           Change = "▼ 3%",   IsUp = false });

            QualitySummary.Clear();
            QualitySummary.Add(new ReportSummaryItem { Label = "Toplam Kontrol",  Value = "1,247", Change = "▲ 15%",  IsUp = true });
            QualitySummary.Add(new ReportSummaryItem { Label = "Geçiş Oranı",    Value = "99.1%", Change = "▲ 0.3%", IsUp = true });
            QualitySummary.Add(new ReportSummaryItem { Label = "Başarısız Ürün", Value = "11",    Change = "▼ 2",    IsUp = false });
            QualitySummary.Add(new ReportSummaryItem { Label = "Koşullu Geçen",  Value = "3",     Change = "=",      IsUp = true });

            MaintenanceSummary.Clear();
            MaintenanceSummary.Add(new ReportSummaryItem { Label = "Toplam Bakım",   Value = "12",      Change = "▲ 2",    IsUp = true });
            MaintenanceSummary.Add(new ReportSummaryItem { Label = "Tamamlanan",     Value = "9",       Change = "▲ 1",    IsUp = true });
            MaintenanceSummary.Add(new ReportSummaryItem { Label = "Toplam Maliyet", Value = "₺ 28,400",Change = "▲ 8%",   IsUp = false });
            MaintenanceSummary.Add(new ReportSummaryItem { Label = "Ortalama Süre",  Value = "4.2 saat",Change = "▼ 0.5h", IsUp = true });

            InventorySummary.Clear();
            InventorySummary.Add(new ReportSummaryItem { Label = "Toplam Kalem",  Value = "8",          Change = "=",    IsUp = true });
            InventorySummary.Add(new ReportSummaryItem { Label = "Stok Değeri",   Value = "₺ 312,500",  Change = "▲ 3%", IsUp = true });
            InventorySummary.Add(new ReportSummaryItem { Label = "Kritik Kalem",  Value = "2",           Change = "▲ 1",  IsUp = false });
            InventorySummary.Add(new ReportSummaryItem { Label = "Tedarikçi",     Value = "6",           Change = "=",    IsUp = true });
        }

        private void ExportPdf()
        {
            // TODO: PDF export (ReportingService entegrasyonu)
            System.Windows.MessageBox.Show("PDF raporu hazırlanıyor...", "FabrikaERP", System.Windows.MessageBoxButton.OK);
        }

        private void ExportXls()
        {
            // TODO: Excel export
            System.Windows.MessageBox.Show("Excel raporu hazırlanıyor...", "FabrikaERP", System.Windows.MessageBoxButton.OK);
        }
    }
}
