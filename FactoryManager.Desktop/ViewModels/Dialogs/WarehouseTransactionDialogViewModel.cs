using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.ViewModels.Dialogs
{
    public class WarehouseTransactionDialogViewModel : ViewModelBase
    {
        private readonly string _transactionType;
        private WarehouseItem _selectedItem;
        private Location _selectedLocation;
        private decimal _quantity;
        private string _referenceNumber;
        private string _notes;
        private bool _canConfirm;

        public WarehouseTransactionDialogViewModel(string transactionType)
        {
            _transactionType = transactionType;
            WarehouseItems = new ObservableCollection<WarehouseItem>();
            Locations = new ObservableCollection<Location>();

            ConfirmCommand = new RelayCommand(_ => Confirm(), _ => CanConfirm);
            CancelCommand = new RelayCommand(_ => Cancel());

            LoadData();
        }

        public string DialogTitle => $"{_transactionType} Items";
        public ObservableCollection<WarehouseItem> WarehouseItems { get; }
        public ObservableCollection<Location> Locations { get; }

        public WarehouseItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public Location SelectedLocation
        {
            get => _selectedLocation;
            set
            {
                _selectedLocation = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public decimal Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string ReferenceNumber
        {
            get => _referenceNumber;
            set
            {
                _referenceNumber = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string Notes
        {
            get => _notes;
            set
            {
                _notes = value;
                OnPropertyChanged();
            }
        }

        public bool CanConfirm
        {
            get => _canConfirm;
            set
            {
                _canConfirm = value;
                OnPropertyChanged();
            }
        }

        public ICommand ConfirmCommand { get; }
        public ICommand CancelCommand { get; }

        public WarehouseTransaction Transaction => new WarehouseTransaction
        {
            Type = _transactionType,
            ItemId = SelectedItem?.Id ?? 0,
            LocationId = SelectedLocation?.Id ?? 0,
            Quantity = Quantity,
            ReferenceNumber = ReferenceNumber,
            Notes = Notes,
            TransactionDate = DateTime.Now
        };

        private void LoadData()
        {
            // Load warehouse items and locations from service
            // This would typically be async in a real application
        }

        private void ValidateInput()
        {
            CanConfirm = SelectedItem != null &&
                        SelectedLocation != null &&
                        Quantity > 0 &&
                        !string.IsNullOrEmpty(ReferenceNumber);
        }

        private void Confirm()
        {
            DialogResult = true;
            CloseDialog();
        }

        private void Cancel()
        {
            DialogResult = false;
            CloseDialog();
        }

        public bool? DialogResult { get; private set; }
        private Action CloseDialog { get; set; }

        public void SetCloseAction(Action closeAction)
        {
            CloseDialog = closeAction;
        }
    }
}
