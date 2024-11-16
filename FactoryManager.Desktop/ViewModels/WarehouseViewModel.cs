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
    public class WarehouseViewModel : ViewModelBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IDialogService _dialogService;
        private readonly INotificationService _notificationService;
        private WarehouseItem _selectedItem;
        private SeriesCollection _inventoryTrends;
        private int _totalItems;
        private int _lowStockItems;
        private bool _isLoading;

        public WarehouseViewModel(
            IWarehouseService warehouseService,
            IDialogService dialogService,
            INotificationService notificationService)
        {
            _warehouseService = warehouseService;
            _dialogService = dialogService;
            _notificationService = notificationService;

            WarehouseItems = new ObservableCollection<WarehouseItem>();
            InventoryTrends = new SeriesCollection();

            ReceiveItemsCommand = new AsyncRelayCommand(ShowReceiveItemsDialog);
            IssueItemsCommand = new AsyncRelayCommand(ShowIssueItemsDialog);
            MoveItemsCommand = new AsyncRelayCommand(ShowMoveItemsDialog);
            RefreshCommand = new AsyncRelayCommand(LoadData);

            LoadData(null);
        }

        public ObservableCollection<WarehouseItem> WarehouseItems { get; }
        public ICommand ReceiveItemsCommand { get; }
        public ICommand IssueItemsCommand { get; }
        public ICommand MoveItemsCommand { get; }
        public ICommand RefreshCommand { get; }

        public WarehouseItem SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        public SeriesCollection InventoryTrends
        {
            get => _inventoryTrends;
            set => SetProperty(ref _inventoryTrends, value);
        }

        public int TotalItems
        {
            get => _totalItems;
            set => SetProperty(ref _totalItems, value);
        }

        public int LowStockItems
        {
            get => _lowStockItems;
            set => SetProperty(ref _lowStockItems, value);
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
                var items = await _warehouseService.GetWarehouseItemsAsync();
                WarehouseItems.Clear();
                foreach (var item in items)
                {
                    WarehouseItems.Add(item);
                }

                var statistics = await _warehouseService.GetWarehouseStatisticsAsync();
                UpdateStatistics(statistics);
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error", "Failed to load warehouse data.");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ShowReceiveItemsDialog(object parameter)
        {
            var dialog = new WarehouseTransactionDialog("Receive Items");
            var result = await _dialogService.ShowDialogAsync(dialog);
            if (result == true)
            {
                await LoadData(null);
                _notificationService.SendNotification(new Notification
                {
                    Message = "Items received successfully",
                    Type = "Warehouse"
                });
            }
        }

        private async Task ShowIssueItemsDialog(object parameter)
        {
            var dialog = new WarehouseTransactionDialog("Issue Items");
            var result = await _dialogService.ShowDialogAsync(dialog);
            if (result == true)
            {
                await LoadData(null);
                _notificationService.SendNotification(new Notification
                {
                    Message = "Items issued successfully",
                    Type = "Warehouse"
                });
            }
        }

        private async Task ShowMoveItemsDialog(object parameter)
        {
            var dialog = new WarehouseTransactionDialog("Move Items");
            var result = await _dialogService.ShowDialogAsync(dialog);
            if (result == true)
            {
                await LoadData(null);
            }
        }

        private void UpdateStatistics(WarehouseStatistics statistics)
        {
            TotalItems = statistics.TotalItems;
            LowStockItems = statistics.LowStockItems;

            InventoryTrends.Clear();
            InventoryTrends.Add(new LineSeries
            {
                Title = "Inventory Level",
                Values = new ChartValues<double>(statistics.MovementHistory.Select(x => x.Value))
            });
        }
    }
}
