using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityFlyweight
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public Dictionary<string, object> SharedState { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ReferenceCount { get; set; }
        public bool IsReusable { get; set; }
        public string Category { get; set; }
        public List<string> Dependencies { get; set; }
        public TimeSpan TimeToLive { get; set; }
        public string Status { get; set; }
    }
}
