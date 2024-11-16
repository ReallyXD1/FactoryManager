using System.Collections.Generic;

namespace FactoryManager.Desktop.Models
{
    public class ProductionStatistics
    {
        public double Efficiency { get; set; }
        public double Trend { get; set; }
        public int CompletedOrders { get; set; }
        public int PendingOrders { get; set; }
        public double AverageCompletionTime { get; set; }
        public List<ChartDataPoint> ChartData { get; set; }
    }
}
