using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityMetric
    {
        public int Id { get; set; }
        public string MetricName { get; set; }
        public string Category { get; set; }
        public double Value { get; set; }
        public DateTime CollectedAt { get; set; }
        public string Unit { get; set; }
        public Dictionary<string, object> Dimensions { get; set; }
        public string Source { get; set; }
        public TimeSpan AggregationPeriod { get; set; }
        public Dictionary<string, object> Tags { get; set; }
    }
}
