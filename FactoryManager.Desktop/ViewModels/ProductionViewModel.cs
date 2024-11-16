using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactoryManager.Desktop.ViewModels
{
    public class ProductionViewModel : ViewModelBase
    {
        private readonly IProductionService _productionService;
        private readonly IQualityService _qualityService;

        private ProductionOrder _selectedOrder;
        private string _selectedLine;
        private string _selectedStatus;
        private bool _isLoading;

        public ProductionOrder SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                if (SetProperty(ref _selectedOrder, value))
                {
                    LoadOrderDetails();
                }
            }
        }

        public string SelectedLine
        {
            get => _selectedLine;
            set
            {
                if (SetProperty(ref _selectedLine, value))
                {
                    RefreshOrdersCommand.Execute(null);
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
                    RefreshOrdersCommand.Execute(null);
                }
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ObservableCollection<ProductionOrder> ProductionOrders { get; } = new();
        public ObservableCollection<ProductionLine> ProductionLines { get; } = new();
        public ObservableCollection<ProductionStatus> StatusList { get; } = new();
        public ObservableCollection<ProductionEvent> ProductionEvents { get; } = new();

        public ICommand RefreshOrdersCommand { get; }
        public ICommand CreateOrderCommand { get; }
        public ICommand StartProductionCommand { get; }
        public ICommand PauseProductionCommand { get; }
        public ICommand CompleteOrderCommand { get; }
        public ICommand ReportIssueCommand { get; }

        public ProductionViewModel(
            IProductionService productionService,
            IQualityService qualityService)
        {
            _productionService = productionService;
            _qualityService = qualityService;

            RefreshOrdersCommand = new RelayCommand(async _ => await RefreshOrders());
            CreateOrderCommand = new RelayCommand(async _ => await CreateOrder());
            StartProductionCommand = new RelayCommand(async _ => await StartProduction(), CanStartProduction);
            PauseProductionCommand = new RelayCommand(async _ => await PauseProduction(), CanPauseProduction);
            CompleteOrderCommand = new RelayCommand(async _ => await CompleteOrder(), CanCompleteOrder);
            ReportIssueCommand = new RelayCommand(async _ => await ReportIssue());

            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadProductionLines();
            await LoadStatusList();
            await RefreshOrders();
        }

        private async Task LoadProductionLines()
        {
            try
            {
                var lines = await _productionService.GetProductionLinesAsync();
                ProductionLines.Clear();
                foreach (var line in lines)
                {
                    ProductionLines.Add(line);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading production lines: {ex.Message}");
            }
        }

        private async Task LoadStatusList()
        {
            try
            {
                var statuses = await _productionService.GetProductionStatusesAsync();
                StatusList.Clear();
                foreach (var status in statuses)
                {
                    StatusList.Add(status);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading status list: {ex.Message}");
            }
        }

        private async Task RefreshOrders()
        {
            IsLoading = true;
            try
            {
                var orders = await _productionService.GetProductionOrdersAsync(SelectedLine, SelectedStatus);
                ProductionOrders.Clear();
                foreach (var order in orders)
                {
                    ProductionOrders.Add(order);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error refreshing orders: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async void LoadOrderDetails()
        {
            if (SelectedOrder == null) return;

            try
            {
                var events = await _productionService.GetProductionEventsAsync(SelectedOrder.Id);
                ProductionEvents.Clear();
                foreach (var evt in events)
                {
                    ProductionEvents.Add(evt);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading order details: {ex.Message}");
            }
        }

        private async Task CreateOrder()
        {
            // Implementacja tworzenia nowego zlecenia
        }

        private async Task StartProduction()
        {
            if (SelectedOrder == null) return;

            try
            {
                await _productionService.StartProductionAsync(SelectedOrder.Id);
                await RefreshOrders();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error starting production: {ex.Message}");
            }
        }

        private bool CanStartProduction(object parameter)
        {
            return SelectedOrder != null && SelectedOrder.Status == "Planned";
        }

        private async Task PauseProduction()
        {
            if (SelectedOrder == null) return;

            try
            {
                await _productionService.PauseProductionAsync(SelectedOrder.Id);
                await RefreshOrders();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error pausing production: {ex.Message}");
            }
        }

        private bool CanPauseProduction(object parameter)
        {
            return SelectedOrder != null && SelectedOrder.Status == "InProgress";
        }

        private async Task CompleteOrder()
        {
            if (SelectedOrder == null) return;

            try
            {
                await _productionService.CompleteOrderAsync(SelectedOrder.Id);
                await RefreshOrders();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error completing order: {ex.Message}");
            }
        }

        private bool CanCompleteOrder(object parameter)
        {
            return SelectedOrder != null && SelectedOrder.Status == "InProgress";
        }

        private async Task ReportIssue()
        {
            // Implementacja zgłaszania problemu
        }
    }

    public class ProductionLine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
    }

    public class ProductionStatus
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class ProductionEvent
    {
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public string Description { get; set; }
        public string User { get; set; }
    }
}
