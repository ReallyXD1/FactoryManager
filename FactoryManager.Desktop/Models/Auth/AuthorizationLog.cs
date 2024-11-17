using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationLog
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string Operation { get; set; }
        public string Resource { get; set; }
        public int UserId { get; set; }
        public bool Allowed { get; set; }
        public string Reason { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public string PolicyApplied { get; set; }
        public TimeSpan ProcessingTime { get; set; }
    }
}
