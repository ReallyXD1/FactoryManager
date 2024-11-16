using System.Threading.Tasks;
using System.Windows;
using FactoryManager.Desktop.Models;
using FactoryManager.Desktop.Services.Interfaces;
using Microsoft.Win32;

namespace FactoryManager.Desktop.Services
{
    public class DialogService : IDialogService
    {
        private readonly Window _mainWindow;

        public DialogService(Window mainWindow)
        {
            _mainWindow = mainWindow;
        }

        public async Task<bool?> ShowDialogAsync(object dialog)
        {
            if (dialog is Window window)
            {
                window.Owner = _mainWindow;
                return await Task.FromResult(window.ShowDialog());
            }
            return null;
        }

        public async Task ShowErrorAsync(string title, string message)
        {
            await Task.FromResult(MessageBox.Show(
                _mainWindow,
                message,
                title,
                MessageBoxButton.OK,
                MessageBoxImage.Error));
        }

        public async Task ShowReportAsync(Report report)
        {
            var window = new ReportViewerWindow
            {
                Owner = _mainWindow,
                DataContext = new ReportViewerViewModel(report)
            };

            await Task.FromResult(window.ShowDialog());
        }

        public async Task<string> ShowSaveFileDialogAsync(string title, string filter)
        {
            var dialog = new SaveFileDialog
            {
                Title = title,
                Filter = filter,
                FilterIndex = 1
            };

            return await Task.FromResult(dialog.ShowDialog(_mainWindow) == true ? dialog.FileName : null);
        }
    }
}
