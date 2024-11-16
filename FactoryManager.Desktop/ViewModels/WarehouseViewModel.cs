using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FactoryManager.Desktop.ViewModels
{
    public class WarehouseViewModel : ViewModelBase
    {
        private readonly IWarehouseService _warehouseService;
        private WarehouseItem _selectedItem;
        private Location _selectedLocation;
        private string _searchQuery;
        private bool _isLoading;

        public WarehouseItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (SetProperty(ref _selectedItem, value))
                {
                    LoadItemDetails();
                }
            }
        }

        public Location SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                if (SetProperty(ref _selectedLocation, value))
                {
                    LoadLocationItems();
                }
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                if (SetProperty(ref _searchQuery, value))
                {
                    SearchCommand.Execute(null);
                }
            }
        }

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public ObservableCollection<WarehouseItem> Items { get; } = new();
        public ObservableCollection<Location> Locations { get; } = new();
        public ObservableCollection<WarehouseTransaction> Transactions { get; } = new();
        public ObservableCollection<StockAlert> StockAlerts { get; } = new();

        public ICommand SearchCommand { get; }
        public ICommand ReceiveCommand { get; }
        public ICommand IssueCommand { get; }
        public ICommand TransferCommand { get; }
        public ICommand StockTakeCommand { get; }
        public ICommand GenerateReportCommand { get; }

        public WarehouseViewModel(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;

            SearchCommand = new RelayCommand(async _ => await SearchItems());
            ReceiveCommand = new RelayCommand(async _ => await ReceiveItems());
            IssueCommand = new RelayCommand(async _ => await IssueItems(), CanIssueItems);
            TransferCommand = new RelayCommand(async _ => await TransferItems(), CanTransferItems);
            StockTakeCommand = new RelayCommand(async _ => await StartStockTake());
            GenerateReportCommand = new RelayCommand(async _ => await GenerateReport());

            InitializeData();
        }

        private async void InitializeData()
        {
            await LoadLocations();
            await LoadItems();
            await LoadStockAlerts();
        }

        private async Task LoadLocations()
        {
            try
            {
                var locations = await _warehouseService.GetLocationsAsync();
                Locations.Clear();
                foreach (var location in locations)
                {
                    Locations.Add(location);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading locations: {ex.Message}");
            }
        }

        private async Task LoadItems()
        {
            IsLoading = true;
            try
            {
                var items = await _warehouseService.GetWarehouseItemsAsync();
                Items.Clear();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading items: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task LoadStockAlerts()
        {
            try
            {
                var alerts = await _warehouseService.GetStockAlertsAsync();
                StockAlerts.Clear();
                foreach (var alert in alerts)
                {
                    StockAlerts.Add(alert);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading stock alerts: {ex.Message}");
            }
        }

        private async void LoadItemDetails()
        {
            if (SelectedItem == null) return;

            try
            {
                var transactions = await _warehouseService.GetItemTransactionsAsync(SelectedItem.Id);
                Transactions.Clear();
                foreach (var transaction in transactions)
                {
                    Transactions.Add(transaction);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading item details: {ex.Message}");
            }
        }

        private async void LoadLocationItems()
        {
            if (SelectedLocation == null) return;

            try
            {
                var items = await _warehouseService.GetLocationItemsAsync(SelectedLocation.Id);
                Items.Clear();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading location items: {ex.Message}");
            }
        }

        private async Task SearchItems()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery)) return;

            IsLoading = true;
            try
            {
                var items = await _warehouseService.SearchItemsAsync(SearchQuery);
                Items.Clear();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error searching items: {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private async Task ReceiveItems()
        {
            // Implementacja przyjęcia towaru
        }

        private async Task IssueItems()
        {
            // Implementacja wydania towaru
        }

        private bool CanIssueItems(object parameter)
        {
            return SelectedItem != null && SelectedItem.Quantity > 0;
        }

        private async Task TransferItems()
        {
            // Implementacja przesunięcia międzymagazynowego
        }

        private bool CanTransferItems(object parameter)
        {
            return SelectedItem != null && SelectedLocation != null;
        }

        private async Task StartStockTake()
        {
            // Implementacja inwentaryzacji
        }

        private async Task GenerateReport()
        {
            // Implementacja generowania raportu
        }
    }

    public class WarehouseItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
    }

    public class Location
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Capacity { get; set; }
    }

    public class WarehouseTransaction
    {
        public DateTime Timestamp { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }
        public string User { get; set; }
    }

    public class StockAlert
    {
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string AlertType { get; set; }
        public string Message { get; set; }
    }
}
