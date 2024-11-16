using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FactoryManager.Desktop.Commands;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.ViewModels.Dialogs
{
    public class NewOrderDialogViewModel : ViewModelBase
    {
        private Product _selectedProduct;
        private ProductionLine _selectedLine;
        private string _selectedPriority;
        private int _quantity;
        private DateTime _startDate;
        private bool _canCreate;

        public NewOrderDialogViewModel()
        {
            StartDate = DateTime.Today;
            Products = new ObservableCollection<Product>();
            ProductionLines = new ObservableCollection<ProductionLine>();
            Priorities = new ObservableCollection<string> { "Low", "Medium", "High", "Critical" };

            CreateCommand = new RelayCommand(_ => Create(), _ => CanCreate);
            CancelCommand = new RelayCommand(_ => Cancel());

            LoadData();
        }

        public ObservableCollection<Product> Products { get; }
        public ObservableCollection<ProductionLine> ProductionLines { get; }
        public ObservableCollection<string> Priorities { get; }

        public Product SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public ProductionLine SelectedLine
        {
            get => _selectedLine;
            set
            {
                _selectedLine = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public string SelectedPriority
        {
            get => _selectedPriority;
            set
            {
                _selectedPriority = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                _startDate = value;
                OnPropertyChanged();
                ValidateInput();
            }
        }

        public bool CanCreate
        {
            get => _canCreate;
            set
            {
                _canCreate = value;
                OnPropertyChanged();
            }
        }

        public ICommand CreateCommand { get; }
        public ICommand CancelCommand { get; }

        public ProductionOrder Order => new ProductionOrder
        {
            ProductId = SelectedProduct?.Id ?? 0,
            ProductionLineId = SelectedLine?.Id ?? 0,
            Quantity = Quantity,
            StartDate = StartDate,
            Priority = SelectedPriority
        };

        private void LoadData()
        {
            // Load products and production lines from service
            // This would typically be async in a real application
        }

        private void ValidateInput()
        {
            CanCreate = SelectedProduct != null &&
                       SelectedLine != null &&
                       Quantity > 0 &&
                       StartDate >= DateTime.Today;
        }

        private void Create()
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
