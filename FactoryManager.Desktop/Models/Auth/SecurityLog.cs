using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityLog
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public string Source { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public string Category { get; set; }
        public string EventId { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public string CorrelationId { get; set; }
    }
}
