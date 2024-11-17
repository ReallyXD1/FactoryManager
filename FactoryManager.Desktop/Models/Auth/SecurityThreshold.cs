using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityThreshold
    {
        public int Id { get; set; }
        public string MetricName { get; set; }
        public double Threshold { get; set; }
        public string Severity { get; set; }
        public TimeSpan EvaluationPeriod { get; set; }
        public Dictionary<string, object> Conditions { get; set; }
        public List<string> Actions { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime LastTriggered { get; set; }
        public int TriggerCount { get; set; }
    }
}
