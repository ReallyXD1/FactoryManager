using System.Windows.Input;
using System.Collections.ObjectModel;

namespace FactoryManager.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentView;
        private readonly DashboardViewModel _dashboardViewModel;
        private readonly ProductionViewModel _productionViewModel;
        private readonly WarehouseViewModel _warehouseViewModel;
        private readonly PlanningViewModel _planningViewModel;
        private readonly QualityViewModel _qualityViewModel;
        private readonly ReportsViewModel _reportsViewModel;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand NavigateCommand { get; }

        public MainViewModel(
            DashboardViewModel dashboardViewModel,
            ProductionViewModel productionViewModel,
            WarehouseViewModel warehouseViewModel,
            PlanningViewModel planningViewModel,
            QualityViewModel qualityViewModel,
            ReportsViewModel reportsViewModel)
        {
            _dashboardViewModel = dashboardViewModel;
            _productionViewModel = productionViewModel;
            _warehouseViewModel = warehouseViewModel;
            _planningViewModel = planningViewModel;
            _qualityViewModel = qualityViewModel;
            _reportsViewModel = reportsViewModel;

            NavigateCommand = new RelayCommand(ExecuteNavigation);

            // Domyślny widok
            CurrentView = _dashboardViewModel;
        }

        private void ExecuteNavigation(object parameter)
        {
            CurrentView = parameter?.ToString()?.ToLower() switch
            {
                "dashboard" => _dashboardViewModel,
                "production" => _productionViewModel,
                "warehouse" => _warehouseViewModel,
                "planning" => _planningViewModel,
                "quality" => _qualityViewModel,
                "reports" => _reportsViewModel,
                _ => _dashboardViewModel
            };
        }

        public string UserName { get; set; }
        public string UserRole { get; set; }
        public ObservableCollection<string> Notifications { get; set; } = new();
    }
}
