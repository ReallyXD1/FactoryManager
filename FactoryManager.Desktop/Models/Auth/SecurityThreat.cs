using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityThreat
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public string Target { get; set; }
        public int Severity { get; set; }
        public Dictionary<string, object> Indicators { get; set; }
        public DateTime DetectedAt { get; set; }
        public List<string> AffectedAssets { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> CounterMeasures { get; set; }
    }
}