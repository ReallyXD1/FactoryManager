using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services;
using FactoryManager.Desktop.Views.Dialogs;
using LiveCharts;

namespace FactoryManager.Desktop.ViewModels
{
    public class ReportsViewModel : ViewModelBase
    {
        private readonly IReportService _reportService;
        private readonly IDialogService _dialogService;
        private ObservableCollection<ReportType> _reportTypes;
        private ObservableCollection<Report> _reports;
        private ReportType _selectedReportType;
        private Report _selectedReport;
        private DateTime _startDate;
        private DateTime _endDate;
        private SeriesCollection _chartData;

        public ReportsViewModel(
            IReportService reportService,
            IDialogService dialogService)
        {
            _reportService = reportService;
            _dialogService = dialogService;

            ReportTypes = new ObservableCollection<ReportType>();
            Reports = new ObservableCollection<Report>();
            ChartData = new SeriesCollection();

            StartDate = DateTime.Today.AddMonths(-1);
            EndDate = DateTime.Today;

            GenerateReportCommand = new AsyncRelayCommand(async _ => await GenerateReportAsync());
            ScheduleReportCommand = new AsyncRelayCommand(async _ => await ScheduleReportAsync());
            ExportReportCommand = new AsyncRelayCommand(async _ => await ExportReportAsync());
            ShareReportCommand = new AsyncRelayCommand(async _ => await ShareReportAsync());
            RefreshCommand = new AsyncRelayCommand(async _ => await LoadDataAsync());

            LoadDataAsync().ConfigureAwait(false);
        }

        public ObservableCollection<ReportType> ReportTypes
        {
            get => _reportTypes;
            set
            {
                _reportTypes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Report> Reports
        {
            get => _reports;
            set
            {
                _reports = value;
                OnPropertyChanged();
            }
        }

        public ReportType SelectedReportType
        {
            get => _selectedReportType;
            set
            {
                _selectedReportType = value;
                OnPropertyChanged();
                UpdatePreview();
            }
        }

        public Report SelectedReport
        {
            get => _selectedReport;
            set
            {
                _selectedReport = value;
                OnPropertyChanged();
                UpdateCommandsState();
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
                UpdatePreview();
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                _endDate = value;
                OnPropertyChanged();
                UpdatePreview();
            }
        }

        public SeriesCollection ChartData
        {
            get => _chartData;
            set
            {
                _chartData = value;
                OnPropertyChanged();
            }
        }

        public ICommand GenerateReportCommand { get; }
        public ICommand ScheduleReportCommand { get; }
        public ICommand ExportReportCommand { get; }
        public ICommand ShareReportCommand { get; }
        public ICommand RefreshCommand { get; }

        private async Task LoadDataAsync()
        {
            try
            {
                var reportTypes = await _reportService.GetReportTypesAsync();
                ReportTypes = new ObservableCollection<ReportType>(reportTypes);

                var reports = await _reportService.GetReportsAsync();
                Reports = new ObservableCollection<Report>(reports);
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error loading data", ex.Message);
            }
        }

        private async Task GenerateReportAsync()
        {
            if (SelectedReportType == null) return;

            try
            {
                var report = await _reportService.GenerateReportAsync(
                    SelectedReportType.Id,
                    StartDate,
                    EndDate);

                Reports.Insert(0, report);
                SelectedReport = report;
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error generating report", ex.Message);
            }
        }

        private async Task ScheduleReportAsync()
        {
            var dialog = new ScheduleReportDialog();
            if (await _dialogService.ShowDialogAsync(dialog) == true)
            {
                try
                {
                    await _reportService.ScheduleReportAsync(dialog.ViewModel.Schedule);
                }
                catch (Exception ex)
                {
                    await _dialogService.ShowErrorAsync("Error scheduling report", ex.Message);
                }
            }
        }

        private async Task ExportReportAsync()
        {
            if (SelectedReport == null) return;

            try
            {
                var path = await _dialogService.ShowSaveFileDialogAsync(
                    "Export Report",
                    "PDF Files|*.pdf|Excel Files|*.xlsx");

                if (!string.IsNullOrEmpty(path))
                {
                    await _reportService.ExportReportAsync(SelectedReport.Id, path);
                }
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error exporting report", ex.Message);
            }
        }

        private async Task ShareReportAsync()
        {
            if (SelectedReport == null) return;

            var dialog = new ShareReportDialog();
            if (await _dialogService.ShowDialogAsync(dialog) == true)
            {
                try
                {
                    await _reportService.ShareReportAsync(
                        SelectedReport.Id,
                        dialog.ViewModel.Recipients);
                }
                catch (Exception ex)
                {
                    await _dialogService.ShowErrorAsync("Error sharing report", ex.Message);
                }
            }
        }

        private async void UpdatePreview()
        {
            if (SelectedReportType == null) return;

            try
            {
                var previewData = await _reportService.GetReportPreviewAsync(
                    SelectedReportType.Id,
                    StartDate,
                    EndDate);

                ChartData = new SeriesCollection(previewData.Series);
            }
            catch (Exception)
            {
                // Handle preview update error silently
            }
        }

        private void UpdateCommandsState()
        {
            // Update commands' CanExecute state based on selected report
        }
    }
}
