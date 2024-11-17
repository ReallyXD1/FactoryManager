using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public int? UserId { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public bool Success { get; set; }
        public string Details { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public string SessionId { get; set; }
    }
}
