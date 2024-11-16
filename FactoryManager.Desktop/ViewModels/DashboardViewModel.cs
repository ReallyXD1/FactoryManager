using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Services;
using LiveCharts;

namespace FactoryManager.Desktop.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly IProductionService _productionService;
        private readonly IQualityService _qualityService;
        private readonly IWarehouseService _warehouseService;
        private double _productionEfficiency;
        private double _qualityRate;
        private double _warehouseCapacity;
        private string _productionTrend;
        private string _qualityTrend;
        private string _warehouseTrend;

        public DashboardViewModel(
            IProductionService productionService,
            IQualityService qualityService,
            IWarehouseService warehouseService)
        {
            _productionService = productionService;
            _qualityService = qualityService;
            _warehouseService = warehouseService;

            RefreshCommand = new AsyncRelayCommand(async _ => await LoadDataAsync());
            ProductionSeries = new SeriesCollection();
            QualitySeries = new SeriesCollection();

            LoadDataAsync().ConfigureAwait(false);
        }

        public double ProductionEfficiency
        {
            get => _productionEfficiency;
            set
            {
                _productionEfficiency = value;
                OnPropertyChanged();
            }
        }

        public double QualityRate
        {
            get => _qualityRate;
            set
            {
                _qualityRate = value;
                OnPropertyChanged();
            }
        }

        public double WarehouseCapacity
        {
            get => _warehouseCapacity;
            set
            {
                _warehouseCapacity = value;
                OnPropertyChanged();
            }
        }

        public string ProductionTrend
        {
            get => _productionTrend;
            set
            {
                _productionTrend = value;
                OnPropertyChanged();
            }
        }

        public string QualityTrend
        {
            get => _qualityTrend;
            set
            {
                _qualityTrend = value;
                OnPropertyChanged();
            }
        }

        public string WarehouseTrend
        {
            get => _warehouseTrend;
            set
            {
                _warehouseTrend = value;
                OnPropertyChanged();
            }
        }

        public SeriesCollection ProductionSeries { get; private set; }
        public SeriesCollection QualitySeries { get; private set; }
        public ICommand RefreshCommand { get; }

        private async Task LoadDataAsync()
        {
            try
            {
                var productionStats = await _productionService.GetProductionStatisticsAsync();
                ProductionEfficiency = productionStats.Efficiency;
                ProductionTrend = FormatTrend(productionStats.Trend);
                UpdateProductionChart(productionStats.ChartData);

                var qualityStats = await _qualityService.GetQualityStatisticsAsync();
                QualityRate = qualityStats.QualityRate;
                QualityTrend = FormatTrend(qualityStats.Trend);
                UpdateQualityChart(qualityStats.ChartData);

                var warehouseStats = await _warehouseService.GetWarehouseStatisticsAsync();
                WarehouseCapacity = warehouseStats.Capacity;
                WarehouseTrend = FormatTrend(warehouseStats.Trend);
            }
            catch (Exception ex)
            {
                // Handle error
            }
        }

        private void UpdateProductionChart(IEnumerable<ChartDataPoint> data)
        {
            ProductionSeries.Clear();
            // Add series based on data
        }

        private void UpdateQualityChart(IEnumerable<ChartDataPoint> data)
        {
            QualitySeries.Clear();
            // Add series based on data
        }

        private string FormatTrend(double trend)
        {
            return trend >= 0 ? $"+{trend:F1}%" : $"{trend:F1}%";
        }
    }
}
