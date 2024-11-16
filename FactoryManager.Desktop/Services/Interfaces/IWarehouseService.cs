using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseItem>> GetWarehouseItemsAsync();
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<WarehouseTransaction> ReceiveItemsAsync(WarehouseTransaction transaction);
        Task<WarehouseTransaction> IssueItemsAsync(WarehouseTransaction transaction);
        Task<WarehouseTransaction> MoveItemsAsync(WarehouseTransaction transaction);
        Task<WarehouseStatistics> GetWarehouseStatisticsAsync();
    }
}
