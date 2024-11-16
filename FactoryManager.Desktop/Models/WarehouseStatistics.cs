using System.Collections.Generic;

namespace FactoryManager.Desktop.Models
{
    public class WarehouseStatistics
    {
        public double Capacity { get; set; }
        public double UsedCapacity { get; set; }
        public double Trend { get; set; }
        public int TotalItems { get; set; }
        public int LowStockItems { get; set; }
        public decimal TotalValue { get; set; }
        public List<ChartDataPoint> MovementHistory { get; set; }
    }
}
