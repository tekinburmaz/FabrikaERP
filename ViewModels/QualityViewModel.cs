using FabrikaERP.Data;
using FabrikaERP.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace FabrikaERP.ViewModels
{
    public class QualityViewModel : ObservableObject
    {
        public ObservableCollection<QualityRecord> Records { get; } = new();

        private string _barcodeInput = string.Empty;
        public string BarcodeInput
        {
            get => _barcodeInput;
            set => SetProperty(ref _barcodeInput, value);
        }

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

        private int _totalInspected;
        public int TotalInspected { get => _totalInspected; set => SetProperty(ref _totalInspected, value); }
        private int _passCount;
        public int PassCount      { get => _passCount;      set => SetProperty(ref _passCount, value); }
        private int _failCount;
        public int FailCount      { get => _failCount;      set => SetProperty(ref _failCount, value); }
        private double _passRate;
        public double PassRate    { get => _passRate;       set => SetProperty(ref _passRate, value); }

        public RelayCommand ScanCommand   { get; }
        public RelayCommand RefreshCommand { get; }
        public RelayCommand ClearCommand  { get; }

        public QualityViewModel()
        {
            ScanCommand    = new RelayCommand(_ => ExecuteScan(),     _ => !string.IsNullOrWhiteSpace(BarcodeInput));
            RefreshCommand = new RelayCommand(_ => _ = LoadAsync());
            ClearCommand   = new RelayCommand(_ => { BarcodeInput = string.Empty; StatusMessage = string.Empty; });
            _ = LoadAsync();
        }

        private async void ExecuteScan()
        {
            if (string.IsNullOrWhiteSpace(BarcodeInput)) return;

            try
            {
                await using var db = new FabrikaDbContext();
                var record = new QualityRecord
                {
                    Barcode     = BarcodeInput.Trim(),
                    ProductName = "Tarama — " + BarcodeInput.Trim(),
                    Result      = QualityResult.Pass,
                    InspectorId = Services.SessionManager.Instance.CurrentUser?.Username ?? "System",
                    InspectedAt = DateTime.UtcNow
                };
                db.QualityRecords.Add(record);
                await db.SaveChangesAsync();

                Records.Insert(0, record);
                StatusMessage = $"Barkod kabul edildi: {BarcodeInput}";
                BarcodeInput  = string.Empty;
                UpdateStats();
            }
            catch
            {
                // Demo mod
                Records.Insert(0, new QualityRecord
                {
                    Barcode     = BarcodeInput,
                    ProductName = "Demo Ürün",
                    Result      = QualityResult.Pass,
                    InspectedAt = DateTime.Now
                });
                StatusMessage = $"Demo: Barkod kabul edildi: {BarcodeInput}";
                BarcodeInput  = string.Empty;
                UpdateStats();
            }
        }

        public async Task LoadAsync()
        {
            try
            {
                await using var db = new FabrikaDbContext();
                var list = await db.QualityRecords
                    .Include(q => q.WorkOrder)
                    .OrderByDescending(q => q.InspectedAt)
                    .Take(50)
                    .ToListAsync();
                Records.Clear();
                foreach (var r in list) Records.Add(r);
                UpdateStats();
            }
            catch
            {
                LoadSample();
            }
        }

        private void UpdateStats()
        {
            TotalInspected = Records.Count;
            PassCount      = Records.Count(r => r.Result == QualityResult.Pass);
            FailCount      = Records.Count(r => r.Result == QualityResult.Fail);
            PassRate       = TotalInspected == 0 ? 100 : (PassCount / (double)TotalInspected) * 100;
        }

        private void LoadSample()
        {
            Records.Clear();
            Records.Add(new QualityRecord { Barcode = "BC-2024-001", ProductName = "Dişli Grubu A-12", Result = QualityResult.Pass, InspectorId = "QC-01", InspectedAt = DateTime.Now.AddHours(-4) });
            Records.Add(new QualityRecord { Barcode = "BC-2024-002", ProductName = "Dişli Grubu A-12", Result = QualityResult.Fail, FailReason = "Çap toleransı dışı", InspectorId = "QC-01", InspectedAt = DateTime.Now.AddHours(-3) });
            Records.Add(new QualityRecord { Barcode = "BC-2024-003", ProductName = "Rulman Seti C-3",  Result = QualityResult.Pass, InspectorId = "QC-02", InspectedAt = DateTime.Now.AddHours(-2) });
            Records.Add(new QualityRecord { Barcode = "BC-2024-004", ProductName = "Rulman Seti C-3",  Result = QualityResult.Pass, InspectorId = "QC-02", InspectedAt = DateTime.Now.AddHours(-1) });
            Records.Add(new QualityRecord { Barcode = "BC-2024-005", ProductName = "Piston D-1",       Result = QualityResult.Conditional, InspectorId = "QC-01", InspectedAt = DateTime.Now.AddMinutes(-30) });
            UpdateStats();
        }
    }
}
