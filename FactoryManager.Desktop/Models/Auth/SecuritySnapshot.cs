using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecuritySnapshot
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Dictionary<string, object> State { get; set; }
        public string CreatedBy { get; set; }
        public bool IsValid { get; set; }
        public string Type { get; set; }
        public TimeSpan RetentionPeriod { get; set; }
        public List<string> Tags { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
