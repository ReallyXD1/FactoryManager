using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAudit
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public string Category { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string ResourceType { get; set; }
        public string ResourceId { get; set; }
        public string Action { get; set; }
        public string Result { get; set; }
        public Dictionary<string, string> Changes { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string Severity { get; set; }
    }
}
