using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionStatistics
    {
        public double OverallEfficiency { get; set; }
        public int CompletedOrders { get; set; }
        public int PendingOrders { get; set; }
        public int DelayedOrders { get; set; }
        public TimeSpan AverageProductionTime { get; set; }
        public List<ChartDataPoint> ChartData { get; set; }
        public Dictionary<string, double> ProductionByLine { get; set; }
        public Dictionary<string, int> OrdersByStatus { get; set; }
        public Dictionary<string, double> EfficiencyByShift { get; set; }
        public Dictionary<string, int> DefectsByType { get; set; }
        public double ResourceUtilization { get; set; }
        public TimeSpan TotalDowntime { get; set; }
        public double QualityRate { get; set; }
        public Dictionary<string, double> KPIs { get; set; }
    }
}
