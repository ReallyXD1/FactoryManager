using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;
using FactoryManager.Desktop.Views.Dialogs;
using LiveCharts;
using LiveCharts.Wpf;

namespace FactoryManager.Desktop.ViewModels
{
    public class QualityViewModel : ViewModelBase
    {
        private readonly IQualityService _qualityService;
        private readonly IDialogService _dialogService;
        private readonly INotificationService _notificationService;
        private QualityControl _selectedControl;
        private SeriesCollection _qualityTrends;
        private double _qualityRate;
        private int _openIssues;
        private bool _isLoading;

        public QualityViewModel(
            IQualityService qualityService,
            IDialogService dialogService,
            INotificationService notificationService)
        {
            _qualityService = qualityService;
            _dialogService = dialogService;
            _notificationService = notificationService;

            QualityControls = new ObservableCollection<QualityControl>();
            QualityTrends = new SeriesCollection();

            NewControlCommand = new AsyncRelayCommand(ShowNewControlDialog);
            ReportIssueCommand = new AsyncRelayCommand(ShowReportIssueDialog, CanReportIssue);
            RefreshCommand = new AsyncRelayCommand(LoadData);

            LoadData(null);
        }

        public ObservableCollection<QualityControl> QualityControls { get; }
        public ICommand NewControlCommand { get; }
        public ICommand ReportIssueCommand { get; }
        public ICommand RefreshCommand { get; }

        public QualityControl SelectedControl
        {
            get => _selectedControl;
            set
            {
                if (SetProperty(ref _selectedControl, value))
                {
                    ((AsyncRelayCommand)ReportIssueCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public SeriesCollection QualityTrends
        {
            get => _qualityTrends;
            set => SetProperty(ref _qualityTrends, value);
        }

        public double QualityRate
        {
            get => _qualityRate;
            set => SetProperty(ref _qualityRate, value);
        }

        public int OpenIssues
        {
            get => _openIssues;
            set => SetProperty(ref _openIssues, value);
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
                var controls = await _qualityService.GetQualityControlsAsync();
                QualityControls.Clear();
                foreach (var control in controls)
                {
                    QualityControls.Add(control);
                }

                var statistics = await _qualityService.GetQualityStatisticsAsync();
                UpdateStatistics(statistics);
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error", "Failed to load quality control data.");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ShowNewControlDialog(object parameter)
        {
            var dialog = new QualityControlDialog();
            var result = await _dialogService.ShowDialogAsync(dialog);
            if (result == true)
            {
                await LoadData(null);
                _notificationService.SendNotification(new Notification
                {
                    Message = "New quality control created",
                    Type = "Quality"
                });
            }
        }

        private async Task ShowReportIssueDialog(object parameter)
        {
            var dialog = new NonConformityDialog(SelectedControl);
            var result = await _dialogService.ShowDialogAsync(dialog);
            if (result == true)
            {
                await LoadData(null);
                _notificationService.SendNotification(new Notification
                {
                    Message = "Quality issue reported",
                    Type = "Quality",
                    Severity = "Warning"
                });
            }
        }

        private bool CanReportIssue(object parameter)
        {
            return SelectedControl != null && !SelectedControl.IsPassed;
        }

        private void UpdateStatistics(QualityStatistics statistics)
        {
            QualityRate = statistics.QualityRate;
            OpenIssues = statistics.OpenNonConformities;

            QualityTrends.Clear();
            QualityTrends.Add(new LineSeries
            {
                Title = "Quality Rate",
                Values = new ChartValues<double>(statistics.QualityTrends.Select(x => x.Value))
            });
        }
    }
}
