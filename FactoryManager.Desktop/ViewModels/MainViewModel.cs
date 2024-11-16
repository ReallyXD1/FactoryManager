using System;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Services;

namespace FactoryManager.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;
        private readonly INotificationService _notificationService;
        private ViewModelBase _currentView;
        private string _userName;
        private string _userRole;

        public MainViewModel(
            IAuthenticationService authService,
            INotificationService notificationService,
            DashboardViewModel dashboardViewModel,
            ProductionViewModel productionViewModel,
            WarehouseViewModel warehouseViewModel,
            PlanningViewModel planningViewModel,
            QualityViewModel qualityViewModel,
            ReportsViewModel reportsViewModel)
        {
            _authService = authService;
            _notificationService = notificationService;

            NavigateCommand = new RelayCommand(Navigate);
            LogoutCommand = new RelayCommand(Logout);

            ViewModels = new Dictionary<string, ViewModelBase>
            {
                { "dashboard", dashboardViewModel },
                { "production", productionViewModel },
                { "warehouse", warehouseViewModel },
                { "planning", planningViewModel },
                { "quality", qualityViewModel },
                { "reports", reportsViewModel }
            };

            CurrentView = dashboardViewModel;
            LoadUserInfo();
            InitializeNotifications();
        }

        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        public string UserRole
        {
            get => _userRole;
            set
            {
                _userRole = value;
                OnPropertyChanged();
            }
        }

        public Dictionary<string, ViewModelBase> ViewModels { get; }
        public ICommand NavigateCommand { get; }
        public ICommand LogoutCommand { get; }

        private void Navigate(object parameter)
        {
            if (parameter is string viewName && ViewModels.ContainsKey(viewName))
            {
                CurrentView = ViewModels[viewName];
            }
        }

        private void Logout(object parameter)
        {
            _authService.Logout();
            // Handle navigation to login window
        }

        private void LoadUserInfo()
        {
            var user = _authService.GetCurrentUser();
            UserName = user.Name;
            UserRole = user.Role;
        }

        private void InitializeNotifications()
        {
            _notificationService.OnNotificationReceived += (sender, notification) =>
            {
                // Handle notification display
            };
        }
    }
}
