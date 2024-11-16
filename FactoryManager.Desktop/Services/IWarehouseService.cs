using FactoryManager.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public interface IWarehouseService
    {
        Task<IEnumerable<WarehouseItem>> GetWarehouseItemsAsync();
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<IEnumerable<WarehouseItem>> GetLocationItemsAsync(int locationId);
        Task<IEnumerable<WarehouseTransaction>> GetItemTransactionsAsync(int itemId);
        Task<bool> ReceiveItemsAsync(WarehouseTransaction transaction);
        Task<bool> IssueItemsAsync(WarehouseTransaction transaction);
        Task<bool> TransferItemsAsync(WarehouseTransaction transaction);
        Task<IEnumerable<StockAlert>> GetStockAlertsAsync();
        Task<IEnumerable<WarehouseItem>> SearchItemsAsync(string query);
    }
}
