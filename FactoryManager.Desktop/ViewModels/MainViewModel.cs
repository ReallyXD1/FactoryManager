using System;
using System.Windows;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Services.Interfaces;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IAuthenticationService _authService;
        private readonly IDialogService _dialogService;
        private readonly INotificationService _notificationService;
        private ViewModelBase _currentViewModel;
        private string _statusMessage;
        private User _currentUser;

        public MainViewModel(
            IAuthenticationService authService,
            IDialogService dialogService,
            INotificationService notificationService,
            ProductionViewModel productionViewModel,
            WarehouseViewModel warehouseViewModel,
            QualityViewModel qualityViewModel,
            ReportsViewModel reportsViewModel)
        {
            _authService = authService;
            _dialogService = dialogService;
            _notificationService = notificationService;

            NavigateCommand = new RelayCommand(Navigate);
            ShowSettingsCommand = new RelayCommand(ShowSettings);
            ShowAboutCommand = new RelayCommand(ShowAbout);
            ExitCommand = new RelayCommand(Exit);
            LogoutCommand = new RelayCommand(Logout);

            ProductionViewModel = productionViewModel;
            WarehouseViewModel = warehouseViewModel;
            QualityViewModel = qualityViewModel;
            ReportsViewModel = reportsViewModel;

            CurrentViewModel = ProductionViewModel;
            CurrentUser = _authService.GetCurrentUser();

            _notificationService.OnNotificationReceived += HandleNotification;
        }

        public ICommand NavigateCommand { get; }
        public ICommand ShowSettingsCommand { get; }
        public ICommand ShowAboutCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand LogoutCommand { get; }

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set => SetProperty(ref _currentViewModel, value);
        }

        public string StatusMessage
        {
            get => _statusMessage;
            set => SetProperty(ref _statusMessage, value);
        }

        public User CurrentUser
        {
            get => _currentUser;
            private set => SetProperty(ref _currentUser, value);
        }

        public ProductionViewModel ProductionViewModel { get; }
        public WarehouseViewModel WarehouseViewModel { get; }
        public QualityViewModel QualityViewModel { get; }
        public ReportsViewModel ReportsViewModel { get; }

        private void Navigate(object parameter)
        {
            if (!_authService.IsAuthenticated)
            {
                ShowLoginDialog();
                return;
            }

            CurrentViewModel = parameter switch
            {
                "Production" => ProductionViewModel,
                "Warehouse" => WarehouseViewModel,
                "Quality" => QualityViewModel,
                "Reports" => ReportsViewModel,
                _ => CurrentViewModel
            };
        }

        private async void ShowSettings(object parameter)
        {
            var dialog = new SettingsDialog();
            await _dialogService.ShowDialogAsync(dialog);
        }

        private async void ShowAbout(object parameter)
        {
            var dialog = new AboutDialog();
            await _dialogService.ShowDialogAsync(dialog);
        }

        private async void ShowLoginDialog()
        {
            var dialog = new LoginDialog();
            var result = await _dialogService.ShowDialogAsync(dialog);
            if (result == true)
            {
                CurrentUser = _authService.GetCurrentUser();
            }
        }

        private void Logout(object parameter)
        {
            _authService.Logout();
            CurrentUser = null;
            CurrentViewModel = ProductionViewModel;
        }

        private void Exit(object parameter)
        {
            Application.Current.Shutdown();
        }

        private void HandleNotification(object sender, Notification notification)
        {
            StatusMessage = notification.Message;
        }
    }
}
