using System;

namespace FactoryManager.Desktop.Models.Production
{
    public class ChartDataPoint
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public string Label { get; set; }
        public string Series { get; set; }
        public string Category { get; set; }
        public Dictionary<string, double> AdditionalValues { get; set; }
        public string Color { get; set; }
    }
}
