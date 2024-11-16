using System.Threading.Tasks;
using System.Windows;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IDialogService
    {
        Task<bool?> ShowDialogAsync(Window dialog);
        Task ShowErrorAsync(string title, string message);
        Task ShowInfoAsync(string title, string message);
        Task<bool> ShowConfirmationAsync(string title, string message);
        Task<string> ShowInputAsync(string title, string message, string defaultValue = "");
        Task ShowProgressAsync(string title, string message, Task task);
        void ShowNotification(string message, string type = "Info");
        Task<string> ShowFileDialogAsync(string filter, bool isSaveDialog = false);
    }
}
