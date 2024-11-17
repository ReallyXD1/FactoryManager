using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SessionActivity
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public int UserId { get; set; }
        public string ActivityType { get; set; }
        public DateTime Timestamp { get; set; }
        public string ResourceAccessed { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public Dictionary<string, object> Details { get; set; }
        public TimeSpan Duration { get; set; }
        public string Status { get; set; }
    }
}
