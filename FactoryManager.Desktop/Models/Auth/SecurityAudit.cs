using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAudit
    {
        public int Id { get; set; }
        public string EventType { get; set; }
        public DateTime Timestamp { get; set; }
        public string Actor { get; set; }
        public string Action { get; set; }
        public string Resource { get; set; }
        public string Result { get; set; }
        public Dictionary<string, object> Details { get; set; }
        public string IpAddress { get; set; }
        public Dictionary<string, object> Context { get; set; }
    }
}
