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
    public class ProductionViewModel : ViewModelBase
    {
        private readonly IProductionService _productionService;
        private readonly IDialogService _dialogService;
        private ObservableCollection<ProductionOrder> _productionOrders;
        private ObservableCollection<ProductionLine> _productionLines;
        private ObservableCollection<string> _statuses;
        private ProductionOrder _selectedOrder;
        private ProductionLine _selectedLine;
        private string _selectedStatus;
        private DateTime? _selectedDate;

        public ProductionViewModel(
            IProductionService productionService,
            IDialogService dialogService)
        {
            _productionService = productionService;
            _dialogService = dialogService;

            ProductionOrders = new ObservableCollection<ProductionOrder>();
            ProductionLines = new ObservableCollection<ProductionLine>();
            Statuses = new ObservableCollection<string>();

            CreateOrderCommand = new AsyncRelayCommand(async _ => await CreateOrderAsync());
            StartProductionCommand = new AsyncRelayCommand(async _ => await StartProductionAsync());
            PauseProductionCommand = new AsyncRelayCommand(async _ => await PauseProductionAsync());
            CompleteOrderCommand = new AsyncRelayCommand(async _ => await CompleteOrderAsync());
            RefreshCommand = new AsyncRelayCommand(async _ => await LoadDataAsync());

            LoadDataAsync().ConfigureAwait(false);
        }

        public ObservableCollection<ProductionOrder> ProductionOrders
        {
            get => _productionOrders;
            set
            {
                _productionOrders = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ProductionLine> ProductionLines
        {
            get => _productionLines;
            set
            {
                _productionLines = value;
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

        public ProductionOrder SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged();
                UpdateCommandsState();
            }
        }

        public ProductionLine SelectedLine
        {
            get => _selectedLine;
            set
            {
                _selectedLine = value;
                OnPropertyChanged();
                FilterOrders();
            }
        }

        public string SelectedStatus
        {
            get => _selectedStatus;
            set
            {
                _selectedStatus = value;
                OnPropertyChanged();
                FilterOrders();
            }
        }

        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                _selectedDate = value;
                OnPropertyChanged();
                FilterOrders();
            }
        }

        public ICommand CreateOrderCommand { get; }
        public ICommand StartProductionCommand { get; }
        public ICommand PauseProductionCommand { get; }
        public ICommand CompleteOrderCommand { get; }
        public ICommand RefreshCommand { get; }

        private async Task LoadDataAsync()
        {
            try
            {
                var orders = await _productionService.GetProductionOrdersAsync();
                ProductionOrders = new ObservableCollection<ProductionOrder>(orders);

                var lines = await _productionService.GetProductionLinesAsync();
                ProductionLines = new ObservableCollection<ProductionLine>(lines);

                Statuses = new ObservableCollection<string>(await _productionService.GetStatusesAsync());
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error loading data", ex.Message);
            }
        }

        private async Task CreateOrderAsync()
        {
            var dialog = new NewOrderDialog();
            if (await _dialogService.ShowDialogAsync(dialog) == true)
            {
                try
                {
                    await _productionService.CreateOrderAsync(dialog.ViewModel.Order);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    await _dialogService.ShowErrorAsync("Error creating order", ex.Message);
                }
            }
        }

        private async Task StartProductionAsync()
        {
            if (SelectedOrder == null) return;

            try
            {
                await _productionService.StartProductionAsync(SelectedOrder.Id);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error starting production", ex.Message);
            }
        }

        private async Task PauseProductionAsync()
        {
            if (SelectedOrder == null) return;

            try
            {
                await _productionService.PauseProductionAsync(SelectedOrder.Id);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error pausing production", ex.Message);
            }
        }

        private async Task CompleteOrderAsync()
        {
            if (SelectedOrder == null) return;

            try
            {
                await _productionService.CompleteOrderAsync(SelectedOrder.Id);
                await LoadDataAsync();
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error completing order", ex.Message);
            }
        }

        private void FilterOrders()
        {
            // Implement filtering logic based on selected line, status and date
        }

        private void UpdateCommandsState()
        {
            // Update commands' CanExecute state based on selected order
        }
    }
}
