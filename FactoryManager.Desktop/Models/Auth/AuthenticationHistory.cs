using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthenticationHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public string AuthMethod { get; set; }
        public string IpAddress { get; set; }
        public string DeviceInfo { get; set; }
        public bool Success { get; set; }
        public string FailureReason { get; set; }
        public Dictionary<string, object> Context { get; set; }
    }
}
