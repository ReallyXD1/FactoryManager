using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Production
{
    public class ProductionCapacity
    {
        public int Id { get; set; }
        public string ResourceId { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentUtilization { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
        public Dictionary<string, object> Constraints { get; set; }
        public List<string> Bottlenecks { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Forecasts { get; set; }
    }
}
