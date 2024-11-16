using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseItem>> GetWarehouseItemsAsync();
        Task<WarehouseItem> GetWarehouseItemAsync(int itemId);
        Task<bool> ReceiveItemsAsync(WarehouseTransaction transaction);
        Task<bool> IssueItemsAsync(WarehouseTransaction transaction);
        Task<bool> MoveItemsAsync(WarehouseItemMove move);
        Task<WarehouseStatistics> GetWarehouseStatisticsAsync();
        Task<IEnumerable<WarehouseLocation>> GetLocationsAsync();
        Task<IEnumerable<WarehouseCategory>> GetCategoriesAsync();
        Task<IEnumerable<WarehouseTransaction>> GetTransactionHistoryAsync(int itemId);
        Task<IEnumerable<StockAlert>> GetStockAlertsAsync();
        Task UpdateStockLevelsAsync(int itemId, int minimumLevel, int maximumLevel);
        Task<byte[]> GenerateInventoryReportAsync(InventoryReportOptions options);
        Task<IEnumerable<WarehouseAuditLog>> GetAuditLogsAsync(WarehouseAuditFilter filter);
    }
}
