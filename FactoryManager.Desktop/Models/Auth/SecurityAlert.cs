using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAlert
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Severity { get; set; }
        public string Message { get; set; }
        public DateTime DetectedAt { get; set; }
        public string Source { get; set; }
        public Dictionary<string, object> Details { get; set; }
        public bool IsActive { get; set; }
        public List<string> AffectedResources { get; set; }
        public string Status { get; set; }
    }
}
