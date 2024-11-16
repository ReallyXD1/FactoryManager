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
    public class WarehouseViewModel : ViewModelBase
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IDialogService _dialogService;
        private ObservableCollection<WarehouseItem> _warehouseItems;
        private ObservableCollection<Category> _categories;
        private ObservableCollection<Location> _locations;
        private WarehouseItem _selectedItem;
        private Category _selectedCategory;
        private Location _selectedLocation;
        private string _searchQuery;

        public WarehouseViewModel(
            IWarehouseService warehouseService,
            IDialogService dialogService)
        {
            _warehouseService = warehouseService;
            _dialogService = dialogService;

            WarehouseItems = new ObservableCollection<WarehouseItem>();
            Categories = new ObservableCollection<Category>();
            Locations = new ObservableCollection<Location>();

            ReceiveItemsCommand = new AsyncRelayCommand(async _ => await ReceiveItemsAsync());
            IssueItemsCommand = new AsyncRelayCommand(async _ => await IssueItemsAsync());
            MoveItemCommand = new AsyncRelayCommand(async _ => await MoveItemAsync());
            RefreshCommand = new AsyncRelayCommand(async _ => await LoadDataAsync());

            LoadDataAsync().ConfigureAwait(false);
        }

        public ObservableCollection<WarehouseItem> WarehouseItems
        {
            get => _warehouseItems;
            set
            {
                _warehouseItems = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Location> Locations
        {
            get => _locations;
            set
            {
                _locations = value;
                OnPropertyChanged();
            }
        }

        public WarehouseItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                UpdateCommandsState();
            }
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged();
                FilterItems();
            }
        }

        public Location SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                _selectedLocation = value;
                OnPropertyChanged();
                FilterItems();
            }
        }

        public string SearchQuery
        {
            get => _searchQuery;
            set
            {
                _searchQuery = value;
                OnPropertyChanged();
                FilterItems();
            }
        }

        public ICommand ReceiveItemsCommand { get; }
        public ICommand IssueItemsCommand { get; }
        public ICommand MoveItemCommand { get; }
        public ICommand RefreshCommand { get; }

        private async Task LoadDataAsync()
        {
            try
            {
                var items = await _warehouseService.GetWarehouseItemsAsync();
                WarehouseItems = new ObservableCollection<WarehouseItem>(items);

                var categories = await _warehouseService.GetCategoriesAsync();
                Categories = new ObservableCollection<Category>(categories);

                var locations = await _warehouseService.GetLocationsAsync();
                Locations = new ObservableCollection<Location>(locations);
            }
            catch (Exception ex)
            {
                await _dialogService.ShowErrorAsync("Error loading data", ex.Message);
            }
        }

        private async Task ReceiveItemsAsync()
        {
            var dialog = new WarehouseTransactionDialog("Receive Items");
            if (await _dialogService.ShowDialogAsync(dialog) == true)
            {
                try
                {
                    await _warehouseService.ReceiveItemsAsync(dialog.ViewModel.Transaction);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    await _dialogService.ShowErrorAsync("Error receiving items", ex.Message);
                }
            }
        }

        private async Task IssueItemsAsync()
        {
            if (SelectedItem == null) return;

            var dialog = new WarehouseTransactionDialog("Issue Items");
            if (await _dialogService.ShowDialogAsync(dialog) == true)
            {
                try
                {
                    await _warehouseService.IssueItemsAsync(dialog.ViewModel.Transaction);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    await _dialogService.ShowErrorAsync("Error issuing items", ex.Message);
                }
            }
        }

        private async Task MoveItemAsync()
        {
            if (SelectedItem == null) return;

            var dialog = new WarehouseTransactionDialog("Move Items");
            if (await _dialogService.ShowDialogAsync(dialog) == true)
            {
                try
                {
                    await _warehouseService.MoveItemsAsync(dialog.ViewModel.Transaction);
                    await LoadDataAsync();
                }
                catch (Exception ex)
                {
                    await _dialogService.ShowErrorAsync("Error moving items", ex.Message);
                }
            }
        }

        private void FilterItems()
        {
            // Implement filtering logic based on category, location and search query
        }

        private void UpdateCommandsState()
        {
            // Update commands' CanExecute state based on selected item
        }
    }
}
