using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IProductionService
    {
        Task<IEnumerable<ProductionOrder>> GetProductionOrdersAsync();
        Task<ProductionOrder> GetProductionOrderAsync(int orderId);
        Task<ProductionOrder> CreateProductionOrderAsync(ProductionOrderCreate order);
        Task<bool> StartProductionAsync(int orderId);
        Task<bool> PauseProductionAsync(int orderId);
        Task<bool> CompleteOrderAsync(int orderId);
        Task<bool> CancelOrderAsync(int orderId);
        Task<ProductionStatistics> GetProductionStatisticsAsync();
        Task<IEnumerable<ProductionLine>> GetProductionLinesAsync();
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<ProductionShift>> GetShiftsAsync();
        Task UpdateOrderProgressAsync(int orderId, double progress);
        Task<IEnumerable<ProductionEvent>> GetProductionEventsAsync(int orderId);
        Task LogProductionEventAsync(ProductionEvent productionEvent);
    }
}
