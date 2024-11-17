using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityViolation
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string ViolationType { get; set; }
        public string Description { get; set; }
        public int Severity { get; set; }
        public string Source { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public string Status { get; set; }
        public string Resolution { get; set; }
        public List<string> AffectedResources { get; set; }
    }
}
