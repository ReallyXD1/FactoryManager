using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.ViewModels.Dialogs
{
    public class ScheduleReportDialogViewModel : ViewModelBase
    {
        private ReportType _selectedReportType;
        private string _selectedFrequency;
        private TimeSpan _selectedTime;
        private string _recipients;
        private string _selectedFormat;
        private bool _canSchedule;

        public ScheduleReportDialogViewModel()
        {
            ReportTypes = new ObservableCollection<ReportType>();
            Frequencies = new ObservableCollection<string>
            {
                "Daily",
                "Weekly",
                "Monthly",
                "Quarterly"
            };
            ExportFormats = new ObservableCollection<string>
            {
                "PDF",
                "Excel",
                "CSV"
            };

            SelectedTime = DateTime.Now.TimeOfDay;

            ScheduleCommand = new RelayCommand(_ => Schedule(), _ => CanSchedule);
            CancelCommand = new RelayCommand(_ => Cancel());

            LoadReportTypes();
        }

        public ObservableCollection<ReportType> ReportTypes { get; }
        public ObservableCollection<string> Frequencies { get; }
        public ObservableCollection<string> ExportFormats { get; }

        public ReportType SelectedReportType
        {
            get => _selectedReportType;
            set
            {
                _selectedReportType = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string SelectedFrequency
        {
            get => _selectedFrequency;
            set
            {
                _selectedFrequency = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public TimeSpan SelectedTime
        {
            get => _selectedTime;
            set
            {
                _selectedTime = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string Recipients
        {
            get => _recipients;
            set
            {
                _recipients = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string SelectedFormat
        {
            get => _selectedFormat;
            set
            {
                _selectedFormat = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public bool CanSchedule
        {
            get => _canSchedule;
            set
            {
                _canSchedule = value;
                OnPropertyChanged();
            }
        }

        public ICommand ScheduleCommand { get; }
        public ICommand CancelCommand { get; }

        public ReportSchedule Schedule => new ReportSchedule
        {
            ReportTypeId = SelectedReportType?.Id ?? 0,
            Frequency = SelectedFrequency,
            ExecutionTime = SelectedTime,
            Recipients = Recipients?.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries),
            ExportFormat = SelectedFormat
        };

        private void LoadReportTypes()
        {
            // Load report types from service
            // This would typically be async in a real application
        }

        private void ValidateInput()
        {
            CanSchedule = SelectedReportType != null &&
                         !string.IsNullOrEmpty(SelectedFrequency) &&
                         !string.IsNullOrEmpty(Recipients) &&
                         !string.IsNullOrEmpty(SelectedFormat);
        }

        private void Schedule()
        {
            DialogResult = true;
            CloseDialog();
        }

        private void Cancel()
        {
            DialogResult = false;
            CloseDialog();
        }

        public bool? DialogResult { get; private set; }
        private Action CloseDialog { get; set; }

        public void SetCloseAction(Action closeAction)
        {
            CloseDialog = closeAction;
        }
    }
}
