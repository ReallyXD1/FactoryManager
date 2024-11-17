using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationAudit
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string RequestId { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public string Resource { get; set; }
        public bool IsAllowed { get; set; }
        public List<string> AppliedPolicies { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public string IpAddress { get; set; }
        public TimeSpan ProcessingTime { get; set; }
        public Dictionary<string, string> Metadata { get; set; }
    }
}
