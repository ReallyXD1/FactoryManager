using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.ViewModels.Dialogs
{
    public class NonConformityDialogViewModel : ViewModelBase
    {
        private string _selectedType;
        private string _selectedSeverity;
        private string _description;
        private string _correctiveAction;
        private bool _canReport;

        public NonConformityDialogViewModel()
        {
            NonConformityTypes = new ObservableCollection<string>
            {
                "Product Defect",
                "Process Deviation",
                "Material Issue",
                "Equipment Malfunction"
            };

            SeverityLevels = new ObservableCollection<string>
            {
                "Minor",
                "Major",
                "Critical"
            };

            ReportCommand = new RelayCommand(_ => Report(), _ => CanReport);
            CancelCommand = new RelayCommand(_ => Cancel());
        }

        public ObservableCollection<string> NonConformityTypes { get; }
        public ObservableCollection<string> SeverityLevels { get; }

        public string SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string SelectedSeverity
        {
            get => _selectedSeverity;
            set
            {
                _selectedSeverity = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string CorrectiveAction
        {
            get => _correctiveAction;
            set
            {
                _correctiveAction = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public bool CanReport
        {
            get => _canReport;
            set
            {
                _canReport = value;
                OnPropertyChanged();
            }
        }

        public ICommand ReportCommand { get; }
        public ICommand CancelCommand { get; }

        public NonConformity NonConformity => new NonConformity
        {
            Type = SelectedType,
            Severity = SelectedSeverity,
            Description = Description,
            CorrectiveAction = CorrectiveAction,
            ReportDate = DateTime.Now
        };

        private void ValidateInput()
        {
            CanReport = !string.IsNullOrEmpty(SelectedType) &&
                       !string.IsNullOrEmpty(SelectedSeverity) &&
                       !string.IsNullOrEmpty(Description) &&
                       !string.IsNullOrEmpty(CorrectiveAction);
        }

        private void Report()
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
