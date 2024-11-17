using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class ComplianceLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Category { get; set; }
        public string PolicyName { get; set; }
        public string Description { get; set; }
        public Dictionary<string, object> Details { get; set; }
        public string Status { get; set; }
        public int? UserId { get; set; }
        public string ResourceId { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
        public string Severity { get; set; }
    }
}
