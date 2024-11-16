using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactoryManager.Desktop.ViewModels
{
    public class ReportsViewModel : ViewModelBase
    {
        private readonly IReportService _reportService;
        private readonly IProductionService _productionService;
        private readonly IQualityService _qualityService;

        private Report _selectedReport;
        private string _selectedReportType;
        private DateTime _startDate;
        private DateTime _endDate;
        private bool _isLoading;

        public Report SelectedReport
        {
            get => _selectedReport;
            set
            {
                if (SetProperty(ref _selectedReport, value))
                {
                    LoadReportDetails();
                }
            }
        }

        public string SelectedReportType
        {
            get => _selectedReportType;
            set
            {
                if (SetProperty(ref _selectedReportType, value))
                {
                    GenerateReportCommand.Execute(null);
                }
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        public DateTime EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ObservableCollection<Report> Reports { get; } = new();
        public ObservableCollection<ReportType> ReportTypes { get; } = new();
        public ObservableCollection<KpiIndicator> KpiIndicators { get; } = new();
        public ObservableCollection<ChartData> ChartData { get; } = new();

        public ICommand GenerateReportCommand { get; }
        public ICommand ExportReportCommand { get; }
        public ICommand ScheduleReportCommand { get; }
        public ICommand ShareReportCommand { get; }

        public ReportsViewModel(
            IReportService reportService,
            IProductionService productionService,
            IQualityService qualityService)
        {
            _reportService = reportService;
            _productionService = productionService;
            _qualityService = qualityService;

            StartDate = DateTime.Today.AddMonths(-1);
            EndDate = DateTime.Today;

            GenerateReportCommand = new RelayCommand(async _ => await GenerateReport());
            ExportReportCommand = new RelayCommand(async _ => await ExportReport(), CanExportReport);
            ScheduleReportCommand = new RelayCommand(async _ => await ScheduleReport());
            ShareReportCommand = new RelayCommand(async _ => await ShareReport(), CanShareReport);

            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadReportTypes();
            await LoadKpiIndicators();
            await LoadReports();
        }

        private async Task LoadReportTypes()
        {
            try
            {
                var types = await _reportService.GetReportTypesAsync();
                ReportTypes.Clear();
                foreach (var type in types)
                {
                    ReportTypes.Add(type);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading report types: {ex.Message}");
            }
        }

        private async Task LoadKpiIndicators()
        {
            try
            {
                var indicators = await _reportService.GetKpiIndicatorsAsync();
                KpiIndicators.Clear();
                foreach (var indicator in indicators)
                {
                    KpiIndicators.Add(indicator);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading KPI indicators: {ex.Message}");
            }
        }

        private async Task LoadReports()
        {
            IsLoading = true;
            try
            {
                var reports = await _reportService.GetReportsAsync();
                Reports.Clear();
                foreach (var report in reports)
                {
                    Reports.Add(report);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading reports: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async void LoadReportDetails()
        {
            if (SelectedReport == null) return;

            try
            {
                var chartData = await _reportService.GetReportChartDataAsync(SelectedReport.Id);
                ChartData.Clear();
                foreach (var data in chartData)
                {
                    ChartData.Add(data);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading report details: {ex.Message}");
            }
        }

        private async Task GenerateReport()
        {
            if (string.IsNullOrEmpty(SelectedReportType)) return;

            IsLoading = true;
            try
            {
                var report = await _reportService.GenerateReportAsync(SelectedReportType, StartDate, EndDate);
                Reports.Add(report);
                SelectedReport = report;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error generating report: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ExportReport()
        {
            if (SelectedReport == null) return;

            try
            {
                await _reportService.ExportReportAsync(SelectedReport.Id);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error exporting report: {ex.Message}");
            }
        }

        private bool CanExportReport(object parameter)
        {
            return SelectedReport != null;
        }

        private async Task ScheduleReport()
        {
            // Implementacja harmonogramowania raportu
        }

        private async Task ShareReport()
        {
            if (SelectedReport == null) return;

            try
            {
                await _reportService.ShareReportAsync(SelectedReport.Id);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error sharing report: {ex.Message}");
            }
        }

        private bool CanShareReport(object parameter)
        {
            return SelectedReport != null;
        }
    }

    public class Report
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime GeneratedDate { get; set; }
        public string Status { get; set; }
    }

    public class ReportType
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class KpiIndicator
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Unit { get; set; }
        public double Target { get; set; }
    }

    public class ChartData
    {
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
    }
}
