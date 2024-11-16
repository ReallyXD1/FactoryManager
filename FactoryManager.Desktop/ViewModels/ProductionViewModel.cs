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
    public class ProductionViewModel : ViewModelBase
    {
        private readonly IProductionService _productionService;
        private readonly IDialogService _dialogService;
        private readonly INotificationService _notificationService;
        private ProductionOrder _selectedOrder;
        private SeriesCollection _chartData;
        private bool _isLoading;

        public ProductionViewModel(
            IProductionService productionService,
            IDialogService dialogService,
            INotificationService notificationService)
        {
            _productionService = productionService;
            _dialogService = dialogService;
            _notificationService = notificationService;

            ProductionOrders = new ObservableCollection<ProductionOrder>();
            ChartData = new SeriesCollection();

            NewOrderCommand = new AsyncRelayCommand(ShowNewOrderDialog);
            RefreshCommand = new AsyncRelayCommand(LoadData);
            StartProductionCommand = new AsyncRelayCommand(StartProduction, CanStartProduction);
            PauseProductionCommand = new AsyncRelayCommand(PauseProduction, CanPauseProduction);
            CompleteOrderCommand = new AsyncRelayCommand(CompleteOrder, CanCompleteOrder);

            LoadData(null);
        }

        public ObservableCollection<ProductionOrder> ProductionOrders { get; }
        public ICommand NewOrderCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand StartProductionCommand { get; }
        public ICommand PauseProductionCommand { get; }
        public ICommand CompleteOrderCommand { get; }

        public ProductionOrder SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                if (SetProperty(ref _selectedOrder, value))
                {
                    ((AsyncRelayCommand)StartProductionCommand).RaiseCanExecuteChanged();
                    ((AsyncRelayCommand)PauseProductionCommand).RaiseCanExecuteChanged();
                    ((AsyncRelayCommand)CompleteOrderCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public SeriesCollection ChartData
        {
            get => _chartData;
            set => SetProperty(ref _chartData, value);
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
                var orders = await _productionService.GetProductionOrdersAsync();
                ProductionOrders.Clear();
                foreach (var order in orders)
                {
                    ProductionOrders.Add(order);
                }

                var statistics = await _productionService.GetProductionStatisticsAsync();
                UpdateChartData(statistics);
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error", "Failed to load production data.");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ShowNewOrderDialog(object parameter)
        {
            var dialog = new ProductionOrderDialog();
            var result = await _dialogService.ShowDialogAsync(dialog);
            if (result == true)
            {
                await LoadData(null);
            }
        }

        private async Task StartProduction(object parameter)
        {
            try
            {
                await _productionService.StartProductionAsync(SelectedOrder.Id);
                await LoadData(null);
                _notificationService.SendNotification(new Notification
                {
                    Message = $"Production started for order {SelectedOrder.Id}",
                    Type = "Production"
                });
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error", "Failed to start production.");
            }
        }

        private bool CanStartProduction(object parameter)
        {
            return SelectedOrder != null && SelectedOrder.Status == "Pending";
        }

        private async Task PauseProduction(object parameter)
        {
            try
            {
                await _productionService.PauseProductionAsync(SelectedOrder.Id);
                await LoadData(null);
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error", "Failed to pause production.");
            }
        }

        private bool CanPauseProduction(object parameter)
        {
            return SelectedOrder != null && SelectedOrder.Status == "InProgress";
        }

        private async Task CompleteOrder(object parameter)
        {
            try
            {
                await _productionService.CompleteOrderAsync(SelectedOrder.Id);
                await LoadData(null);
                _notificationService.SendNotification(new Notification
                {
                    Message = $"Order {SelectedOrder.Id} completed",
                    Type = "Production"
                });
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error", "Failed to complete order.");
            }
        }

        private bool CanCompleteOrder(object parameter)
        {
            return SelectedOrder != null && SelectedOrder.Status == "InProgress";
        }

        private void UpdateChartData(ProductionStatistics statistics)
        {
            ChartData.Clear();
            ChartData.Add(new LineSeries
            {
                Title = "Efficiency",
                Values = new ChartValues<double>(statistics.ChartData.Select(x => x.Value))
            });
        }
    }
}
