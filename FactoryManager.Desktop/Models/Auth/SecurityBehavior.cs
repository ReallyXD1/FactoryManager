using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityBehavior
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Pattern { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public bool IsEnabled { get; set; }
        public int Confidence { get; set; }
        public DateTime DetectedAt { get; set; }
        public List<string> Indicators { get; set; }
        public string Severity { get; set; }
        public Dictionary<string, object> Context { get; set; }
    }
}