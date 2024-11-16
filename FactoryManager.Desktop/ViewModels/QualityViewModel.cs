using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactoryManager.Desktop.ViewModels
{
    public class QualityViewModel : ViewModelBase
    {
        private readonly IQualityService _qualityService;
        private readonly IProductionService _productionService;

        private QualityControl _selectedControl;
        private NonConformity _selectedNonConformity;
        private string _selectedStatus;
        private bool _isLoading;

        public QualityControl SelectedControl
        {
            get => _selectedControl;
            set
            {
                if (SetProperty(ref _selectedControl, value))
                {
                    LoadControlDetails();
                }
            }
        }

        public NonConformity SelectedNonConformity
        {
            get => _selectedNonConformity;
            set
            {
                if (SetProperty(ref _selectedNonConformity, value))
                {
                    LoadNonConformityDetails();
                }
            }
        }

        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                if (SetProperty(ref _selectedStatus, value))
                {
                    RefreshControlsCommand.Execute(null);
                }
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ObservableCollection<QualityControl> Controls { get; } = new();
        public ObservableCollection<NonConformity> NonConformities { get; } = new();
        public ObservableCollection<QualityParameter> Parameters { get; } = new();
        public ObservableCollection<QualityAlert> Alerts { get; } = new();

        public ICommand RefreshControlsCommand { get; }
        public ICommand CreateControlCommand { get; }
        public ICommand StartControlCommand { get; }
        public ICommand CompleteControlCommand { get; }
        public ICommand ReportNonConformityCommand { get; }
        public ICommand GenerateReportCommand { get; }

        public QualityViewModel(
            IQualityService qualityService,
            IProductionService productionService)
        {
            _qualityService = qualityService;
            _productionService = productionService;

            RefreshControlsCommand = new RelayCommand(async _ => await RefreshControls());
            CreateControlCommand = new RelayCommand(async _ => await CreateControl());
            StartControlCommand = new RelayCommand(async _ => await StartControl(), CanStartControl);
            CompleteControlCommand = new RelayCommand(async _ => await CompleteControl(), CanCompleteControl);
            ReportNonConformityCommand = new RelayCommand(async _ => await ReportNonConformity());
            GenerateReportCommand = new RelayCommand(async _ => await GenerateReport());

            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadParameters();
            await RefreshControls();
            await LoadAlerts();
        }

        private async Task LoadParameters()
        {
            try
            {
                var parameters = await _qualityService.GetQualityParametersAsync();
                Parameters.Clear();
                foreach (var parameter in parameters)
                {
                    Parameters.Add(parameter);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading parameters: {ex.Message}");
            }
        }

        private async Task RefreshControls()
        {
            IsLoading = true;
            try
            {
                var controls = await _qualityService.GetQualityControlsAsync(SelectedStatus);
                Controls.Clear();
                foreach (var control in controls)
                {
                    Controls.Add(control);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error refreshing controls: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task LoadAlerts()
        {
            try
            {
                var alerts = await _qualityService.GetQualityAlertsAsync();
                Alerts.Clear();
                foreach (var alert in alerts)
                {
                    Alerts.Add(alert);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading alerts: {ex.Message}");
            }
        }

        private async void LoadControlDetails()
        {
            if (SelectedControl == null) return;

            try
            {
                var nonConformities = await _qualityService.GetControlNonConformitiesAsync(SelectedControl.Id);
                NonConformities.Clear();
                foreach (var nonConformity in nonConformities)
                {
                    NonConformities.Add(nonConformity);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading control details: {ex.Message}");
            }
        }

        private async void LoadNonConformityDetails()
        {
            if (SelectedNonConformity == null) return;

            try
            {
                // Załaduj szczegóły niezgodności
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading nonconformity details: {ex.Message}");
            }
        }

        private async Task CreateControl()
        {
            // Implementacja tworzenia nowej kontroli
        }

        private async Task StartControl()
        {
            if (SelectedControl == null) return;

            try
            {
                await _qualityService.StartControlAsync(SelectedControl.Id);
                await RefreshControls();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error starting control: {ex.Message}");
            }
        }

        private bool CanStartControl(object parameter)
        {
            return SelectedControl != null && SelectedControl.Status == "Planned";
        }

        private async Task CompleteControl()
        {
            if (SelectedControl == null) return;

            try
            {
                await _qualityService.CompleteControlAsync(SelectedControl.Id);
                await RefreshControls();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error completing control: {ex.Message}");
            }
        }

        private bool CanCompleteControl(object parameter)
        {
            return SelectedControl != null && SelectedControl.Status == "InProgress";
        }

        private async Task ReportNonConformity()
        {
            // Implementacja zgłaszania niezgodności
        }

        private async Task GenerateReport()
        {
            // Implementacja generowania raportu
        }
    }

    public class QualityControl
    {
        public int Id { get; set; }
        public string ControlNumber { get; set; }
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
    }

    public class NonConformity
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Description { get; set; }
        public string Severity { get; set; }
        public string Status { get; set; }
    }

    public class QualityParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public double MinValue { get; set; }
        public double MaxValue { get; set; }
    }

    public class QualityAlert
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string Priority { get; set; }
    }
}
