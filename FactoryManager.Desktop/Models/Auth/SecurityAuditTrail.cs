using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAuditTrail
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string ActivityType { get; set; }
        public int? UserId { get; set; }
        public string ResourceType { get; set; }
        public string ResourceId { get; set; }
        public Dictionary<string, object> Changes { get; set; }
        public string IpAddress { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public string Result { get; set; }
    }
}
