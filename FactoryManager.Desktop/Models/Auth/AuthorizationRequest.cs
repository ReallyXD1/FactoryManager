using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationRequest
    {
        public string RequestId { get; set; }
        public int UserId { get; set; }
        public string ResourceType { get; set; }
        public string Action { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public DateTime RequestTime { get; set; }
        public string IpAddress { get; set; }
        public List<string> RequiredPermissions { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public string SessionId { get; set; }
    }
}
