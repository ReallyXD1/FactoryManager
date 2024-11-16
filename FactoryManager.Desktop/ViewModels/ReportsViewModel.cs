using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;
using FactoryManager.Desktop.Views.Dialogs;

namespace FactoryManager.Desktop.ViewModels
{
    public class ReportsViewModel : ViewModelBase
    {
        private readonly IReportService _reportService;
        private readonly IDialogService _dialogService;
        private Report _selectedReport;
        private ReportPreview _reportPreview;
        private bool _isLoading;

        public ReportsViewModel(
            IReportService reportService,
            IDialogService dialogService)
        {
            _reportService = reportService;
            _dialogService = dialogService;

            Reports = new ObservableCollection<Report>();
            ScheduledReports = new ObservableCollection<ReportSchedule>();

            GenerateReportCommand = new AsyncRelayCommand(ShowGenerateReportDialog);
            ScheduleReportCommand = new AsyncRelayCommand(ShowScheduleReportDialog);
            ExportReportCommand = new AsyncRelayCommand(ExportReport, CanExportReport);
            ShareReportCommand = new AsyncRelayCommand(ShareReport, CanShareReport);
            RefreshCommand = new AsyncRelayCommand(LoadData);

            LoadData(null);
        }

        public ObservableCollection<Report> Reports { get; }
        public ObservableCollection<ReportSchedule> ScheduledReports { get; }
        public ICommand GenerateReportCommand { get; }
        public ICommand ScheduleReportCommand { get; }
        public ICommand ExportReportCommand { get; }
        public ICommand ShareReportCommand { get; }
        public ICommand RefreshCommand { get; }

        public Report SelectedReport
        {
            get => _selectedReport;
            set
            {
                if (SetProperty(ref _selectedReport, value))
                {
                    LoadReportPreview(value);
                    ((AsyncRelayCommand)ExportReportCommand).RaiseCanExecuteChanged();
                    ((AsyncRelayCommand)ShareReportCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public ReportPreview ReportPreview
        {
            get => _reportPreview;
            set => SetProperty(ref _reportPreview, value);
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        private async Task LoadData(object parameter)
        {
            try
            {
                IsLoading = true;
                var reports = await _reportService.GetReportsAsync();
                Reports.Clear();
                foreach (var report in reports)
                {
                    Reports.Add(report);
                }

                var schedules = await _reportService.GetReportSchedulesAsync();
                ScheduledReports.Clear();
                foreach (var schedule in schedules)
                {
                    ScheduledReports.Add(schedule);
                }
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error", "Failed to load reports data.");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ShowGenerateReportDialog(object parameter)
        {
            var dialog = new ReportGeneratorDialog();
            var result = await _dialogService.ShowDialogAsync(dialog);
            if (result == true)
            {
                await LoadData(null);
            }
        }

        private async Task ShowScheduleReportDialog(object parameter)
        {
            var dialog = new ReportScheduleDialog();
            var result = await _dialogService.ShowDialogAsync(dialog);
            if (result == true)
            {
                await LoadData(null);
            }
        }

        private async Task ExportReport(object parameter)
        {
            try
            {
                await _reportService.ExportReportAsync(SelectedReport.Id);
                await _dialogService.ShowInfoAsync("Success", "Report exported successfully.");
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error", "Failed to export report.");
            }
        }

        private bool CanExportReport(object parameter)
        {
            return SelectedReport != null;
        }

        private async Task ShareReport(object parameter)
        {
            var dialog = new ShareReportDialog(SelectedReport);
            await _dialogService.ShowDialogAsync(dialog);
        }

        private bool CanShareReport(object parameter)
        {
            return SelectedReport != null;
        }

        private async void LoadReportPreview(Report report)
        {
            if (report == null)
            {
                ReportPreview = null;
                return;
            }

            try
            {
                ReportPreview = await _reportService.GetReportPreviewAsync(report.Id);
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error", "Failed to load report preview.");
            }
        }
    }
}
