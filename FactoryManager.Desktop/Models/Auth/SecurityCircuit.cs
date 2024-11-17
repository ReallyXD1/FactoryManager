using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityCircuit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int FailureThreshold { get; set; }
        public TimeSpan ResetTimeout { get; set; }
        public DateTime LastStateChange { get; set; }
        public int FailureCount { get; set; }
        public Dictionary<string, object> Metrics { get; set; }
        public List<string> AffectedServices { get; set; }
        public string Strategy { get; set; }
    }
}
