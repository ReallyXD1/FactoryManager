using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string EventType { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string IpAddress { get; set; }
        public string Action { get; set; }
        public string Resource { get; set; }
        public string Status { get; set; }
        public Dictionary<string, string> Details { get; set; }
        public string SessionId { get; set; }
        public string DeviceInfo { get; set; }
        public string Location { get; set; }
        public string Severity { get; set; }
    }
}
