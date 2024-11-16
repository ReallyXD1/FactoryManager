using System.Threading.Tasks;
using System.Windows;
using FactoryManager.Desktop.Services.Interfaces;
using Microsoft.Win32;

namespace FactoryManager.Desktop.Services
{
    public class DialogService : IDialogService
    {
        public Task<bool?> ShowDialogAsync(Window dialog)
        {
            return Task.FromResult(dialog.ShowDialog());
        }

        public Task ShowErrorAsync(string title, string message)
        {
            return Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Error);
                });
            });
        }

        public Task ShowInfoAsync(string title, string message)
        {
            return Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MessageBox.Show(message, title, MessageBoxButton.OK, MessageBoxImage.Information);
                });
            });
        }

        public Task<bool> ShowConfirmationAsync(string title, string message)
        {
            return Task.Run(() =>
            {
                return Application.Current.Dispatcher.Invoke(() =>
                {
                    var result = MessageBox.Show(message, title, MessageBoxButton.YesNo, MessageBoxImage.Question);
                    return result == MessageBoxResult.Yes;
                });
            });
        }

        public Task<string> ShowInputAsync(string title, string message, string defaultValue = "")
        {
            return Task.Run(() =>
            {
                return Application.Current.Dispatcher.Invoke(() =>
                {
                    var dialog = new InputDialog(title, message, defaultValue);
                    var result = dialog.ShowDialog();
                    return result == true ? dialog.InputText : null;
                });
            });
        }

        public async Task ShowProgressAsync(string title, string message, Task task)
        {
            var progressDialog = new ProgressDialog(title, message);
            var progressTask = Task.Run(() =>
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    progressDialog.Show();
                });
            });

            await task;

            Application.Current.Dispatcher.Invoke(() =>
            {
                progressDialog.Close();
            });
        }

        public void ShowNotification(string message, string type = "Info")
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                var notification = new NotificationWindow(message, type);
                notification.Show();
            });
        }

        public Task<string> ShowFileDialogAsync(string filter, bool isSaveDialog = false)
        {
            return Task.Run(() =>
            {
                return Application.Current.Dispatcher.Invoke(() =>
                {
                    if (isSaveDialog)
                    {
                        var saveDialog = new SaveFileDialog
                        {
                            Filter = filter
                        };
                        return saveDialog.ShowDialog() == true ? saveDialog.FileName : null;
                    }
                    else
                    {
                        var openDialog = new OpenFileDialog
                        {
                            Filter = filter
                        };
                        return openDialog.ShowDialog() == true ? openDialog.FileName : null;
                    }
                });
            });
        }
    }
}
