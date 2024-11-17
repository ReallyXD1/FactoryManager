using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityResponse
    {
        public int Id { get; set; }
        public string RequestId { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public DateTime ResponseTime { get; set; }
        public string RespondedBy { get; set; }
        public List<string> Actions { get; set; }
        public TimeSpan ProcessingTime { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public int Version { get; set; }
    }
}
