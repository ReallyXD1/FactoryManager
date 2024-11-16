using System.Windows;
using FactoryManager.Desktop.ViewModels;

namespace FactoryManager.Desktop
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
