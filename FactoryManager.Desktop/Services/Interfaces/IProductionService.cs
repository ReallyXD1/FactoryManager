using System.Collections.Generic;
using System.Threading.Tasks;
using FactoryManager.Desktop.Models;

namespace FactoryManager.Desktop.Services.Interfaces
{
    public interface IProductionService
    {
        Task<IEnumerable<ProductionOrder>> GetProductionOrdersAsync();
        Task<IEnumerable<ProductionLine>> GetProductionLinesAsync();
        Task<IEnumerable<string>> GetStatusesAsync();
        Task<ProductionOrder> CreateOrderAsync(ProductionOrder order);
        Task StartProductionAsync(int orderId);
        Task PauseProductionAsync(int orderId);
        Task CompleteOrderAsync(int orderId);
        Task<ProductionStatistics> GetProductionStatisticsAsync();
    }
}
