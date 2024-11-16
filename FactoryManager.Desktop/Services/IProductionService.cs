using FactoryManager.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FactoryManager.Desktop.Services
{
    public interface IProductionService
    {
        Task<IEnumerable<ProductionOrder>> GetProductionOrdersAsync(string line = null, string status = null);
        Task<ProductionOrder> CreateOrderAsync(ProductionOrder order);
        Task<bool> StartProductionAsync(int orderId);
        Task<bool> PauseProductionAsync(int orderId);
        Task<bool> CompleteOrderAsync(int orderId);
        Task<IEnumerable<ProductionLine>> GetProductionLinesAsync();
        Task<IEnumerable<ProductionEvent>> GetProductionEventsAsync(int orderId);
        Task<ProductionStatistics> GetProductionStatisticsAsync(DateTime startDate, DateTime endDate);
        Task<bool> ReportIssueAsync(ProductionIssue issue);
    }
}
