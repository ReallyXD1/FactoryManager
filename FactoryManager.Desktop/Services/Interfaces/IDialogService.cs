using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IDialogService
    {
        Task<bool?> ShowDialogAsync(object dialog);
        Task ShowErrorAsync(string title, string message);
        Task ShowReportAsync(Report report);
        Task<string> ShowSaveFileDialogAsync(string title, string filter);
    }
}
