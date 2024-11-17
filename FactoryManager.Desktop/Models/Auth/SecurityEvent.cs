using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityEvent
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public string Source { get; set; }
        public int? UserId { get; set; }
        public string IpAddress { get; set; }
        public Dictionary<string, object> EventData { get; set; }
        public string Severity { get; set; }
        public bool RequiresAction { get; set; }
        public string Status { get; set; }
        public List<string> Tags { get; set; }
    }
}
