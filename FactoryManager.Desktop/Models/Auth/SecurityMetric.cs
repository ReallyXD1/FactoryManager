using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityMetric
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public object Value { get; set; }
        public string Unit { get; set; }
        public DateTime CollectedAt { get; set; }
        public string Source { get; set; }
        public Dictionary<string, object> Tags { get; set; }
        public Dictionary<string, object> Dimensions { get; set; }
        public int Interval { get; set; }
    }
}
