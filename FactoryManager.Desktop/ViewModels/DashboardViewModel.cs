using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactoryManager.Desktop.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly IProductionService _productionService;
        private readonly IWarehouseService _warehouseService;
        private readonly IQualityService _qualityService;

        private double _currentOEE;
        private int _activeOrders;
        private int _completedOrders;
        private double _qualityRate;
        private string _selectedTimeRange = "Day";

        public double CurrentOEE
        {
            get => _currentOEE;
            set => SetProperty(ref _currentOEE, value);
        }

        public int ActiveOrders
        {
            get => _activeOrders;
            set => SetProperty(ref _activeOrders, value);
        }

        public int CompletedOrders
        {
            get => _completedOrders;
            set => SetProperty(ref _completedOrders, value);
        }

        public double QualityRate
        {
            get => _qualityRate;
            set => SetProperty(ref _qualityRate, value);
        }

        public string SelectedTimeRange
        {
            get => _selectedTimeRange;
            set
            {
                if (SetProperty(ref _selectedTimeRange, value))
                {
                    RefreshDataCommand.Execute(null);
                }
            }
        }

        public ObservableCollection<ProductionOrder> RecentOrders { get; } = new();
        public ObservableCollection<Alert> ActiveAlerts { get; } = new();
        public ObservableCollection<KpiData> KpiTrends { get; } = new();

        public ICommand RefreshDataCommand { get; }
        public ICommand ExportReportCommand { get; }

        public DashboardViewModel(
            IProductionService productionService,
            IWarehouseService warehouseService,
            IQualityService qualityService)
        {
            _productionService = productionService;
            _warehouseService = warehouseService;
            _qualityService = qualityService;

            RefreshDataCommand = new RelayCommand(async _ => await RefreshData());
            ExportReportCommand = new RelayCommand(async _ => await ExportReport());

            // Inicjalne załadowanie danych
            Task.Run(RefreshData);
        }

        private async Task RefreshData()
        {
            try
            {
                var productionData = await _productionService.GetProductionDataAsync(SelectedTimeRange);
                var qualityData = await _qualityService.GetQualityDataAsync(SelectedTimeRange);

                CurrentOEE = productionData.OEE;
                ActiveOrders = productionData.ActiveOrders;
                CompletedOrders = productionData.CompletedOrders;
                QualityRate = qualityData.QualityRate;

                UpdateRecentOrders(productionData.RecentOrders);
                UpdateActiveAlerts();
                UpdateKpiTrends();
            }
            catch (Exception ex)
            {
                // Obsługa błędów
                System.Diagnostics.Debug.WriteLine($"Error refreshing dashboard data: {ex.Message}");
            }
        }

        private void UpdateRecentOrders(IEnumerable<ProductionOrder> orders)
        {
            RecentOrders.Clear();
            foreach (var order in orders)
            {
                RecentOrders.Add(order);
            }
        }

        private void UpdateActiveAlerts()
        {
            ActiveAlerts.Clear();
            // Dodaj logikę pobierania alertów
        }

        private void UpdateKpiTrends()
        {
            KpiTrends.Clear();
            // Dodaj logikę pobierania trendów KPI
        }

        private async Task ExportReport()
        {
            try
            {
                // Implementacja eksportu raportu
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error exporting report: {ex.Message}");
            }
        }
    }

    public class ProductionOrder
    {
        public string OrderNumber { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
    }

    public class Alert
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Severity { get; set; }
    }

    public class KpiData
    {
        public DateTime TimeStamp { get; set; }
        public double Value { get; set; }
        public string KpiName { get; set; }
    }
}
