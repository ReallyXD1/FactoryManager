using FactoryManager.Desktop.Models.Production;
using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Warehouse
{
    public class WarehouseStatistics
    {
        public int TotalItems { get; set; }
        public int LowStockItems { get; set; }
        public int OutOfStockItems { get; set; }
        public decimal TotalInventoryValue { get; set; }
        public double WarehouseUtilization { get; set; }
        public int PendingOrders { get; set; }
        public Dictionary<string, int> ItemsByCategory { get; set; }
        public Dictionary<string, double> UtilizationByZone { get; set; }
        public List<ChartDataPoint> MovementHistory { get; set; }
        public Dictionary<string, decimal> ValueByCategory { get; set; }
        public int TotalTransactions { get; set; }
        public TimeSpan AverageProcessingTime { get; set; }
    }
}
