using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationContext
    {
        public string RequestId { get; set; }
        public int UserId { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
        public string ResourceType { get; set; }
        public string Action { get; set; }
        public Dictionary<string, object> ResourceAttributes { get; set; }
        public Dictionary<string, string> Environment { get; set; }
        public DateTime Timestamp { get; set; }
        public string IpAddress { get; set; }
    }
}
