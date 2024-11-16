using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services;
using FactoryManager.Desktop.Views.Dialogs;

namespace FactoryManager.Desktop.ViewModels
{
    public class QualityViewModel : ViewModelBase
    {
        private readonly IQualityService _qualityService;
        private readonly IDialogService _dialogService;
        private ObservableCollection<QualityControl> _controls;
        private ObservableCollection<string> _controlTypes;
        private ObservableCollection<string> _statuses;
        private QualityControl _selectedControl;
        private string _selectedType;
        private string _selectedStatus;

        public QualityViewModel(
            IQualityService qualityService,
            IDialogService dialogService)
        {
            _qualityService = qualityService;
            _dialogService = dialogService;

            Controls = new ObservableCollection<QualityControl>();
            ControlTypes = new ObservableCollection<string>();
            Statuses = new ObservableCollection<string>();

            CreateControlCommand = new AsyncRelayCommand(async _ => await CreateControlAsync());
            StartControlCommand = new AsyncRelayCommand(async _ => await StartControlAsync());
            CompleteControlCommand = new AsyncRelayCommand(async _ => await CompleteControlAsync());
            ReportNonConformityCommand = new AsyncRelayCommand(async _ => await ReportNonConformityAsync());
            GenerateReportCommand = new AsyncRelayCommand(async _ => await GenerateReportAsync());
            RefreshCommand = new AsyncRelayCommand(async _ => await LoadDataAsync());

            LoadDataAsync().ConfigureAwait(false);
        }

        public ObservableCollection<QualityControl> Controls
        {
            get => _controls;
            set
            {
                _controls = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> ControlTypes
        {
            get => _controlTypes;
            set
            {
                _controlTypes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> Statuses
        {
            get => _statuses;
            set
            {
                _statuses = value;
                OnPropertyChanged();
            }
        }

        public QualityControl SelectedControl
        {
            get => _selectedControl;
            set
            {
                _selectedControl = value;
                OnPropertyChanged();
                UpdateCommandsState();
            }
        }

        public string SelectedType
        {
            get => _selectedType;
            set
            {
                _selectedType = value;
                OnPropertyChanged();
                FilterControls();
            }
        }

        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                OnPropertyChanged();
                FilterControls();
            }
        }

        public ICommand CreateControlCommand { get; }
        public ICommand StartControlCommand { get; }
        public ICommand CompleteControlCommand { get; }
        public ICommand ReportNonConformityCommand { get; }
        public ICommand GenerateReportCommand { get; }
        public ICommand RefreshCommand { get; }

        private async Task LoadDataAsync()
        {
            try
            {
                var controls = await _qualityService.GetQualityControlsAsync();
                Controls = new ObservableCollection<QualityControl>(controls);

                ControlTypes = new ObservableCollection<string>(await _qualityService.GetControlTypesAsync());
                Statuses = new ObservableCollection<string>(await _qualityService.GetStatusesAsync());
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error loading data", ex.Message);
            }
        }

        private async Task CreateControlAsync()
        {
            var dialog = new QualityControlDialog();
            if (await _dialogService.ShowDialogAsync(dialog) == true)
            {
                try
                {
                    await _qualityService.CreateControlAsync(dialog.ViewModel.Control);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    await _dialogService.ShowErrorAsync("Error creating control", ex.Message);
                }
            }
        }

        private async Task StartControlAsync()
        {
            if (SelectedControl == null) return;

            try
            {
                await _qualityService.StartControlAsync(SelectedControl.Id);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error starting control", ex.Message);
            }
        }

        private async Task CompleteControlAsync()
        {
            if (SelectedControl == null) return;

            try
            {
                await _qualityService.CompleteControlAsync(SelectedControl.Id);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error completing control", ex.Message);
            }
        }

        private async Task ReportNonConformityAsync()
        {
            if (SelectedControl == null) return;

            var dialog = new NonConformityDialog();
            if (await _dialogService.ShowDialogAsync(dialog) == true)
            {
                try
                {
                    await _qualityService.ReportNonConformityAsync(SelectedControl.Id, dialog.ViewModel.NonConformity);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    await _dialogService.ShowErrorAsync("Error reporting non-conformity", ex.Message);
                }
            }
        }

        private async Task GenerateReportAsync()
        {
            try
            {
                var report = await _qualityService.GenerateReportAsync();
                await _dialogService.ShowReportAsync(report);
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error generating report", ex.Message);
            }
        }

        private void FilterControls()
        {
            // Implement filtering logic based on type and status
        }

        private void UpdateCommandsState()
        {
            // Update commands' CanExecute state based on selected control
        }
    }
}
