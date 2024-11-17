using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityBridge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SourceSystem { get; set; }
        public string TargetSystem { get; set; }
        public Dictionary<string, object> Mappings { get; set; }
        public List<string> Transformations { get; set; }
        public bool IsActive { get; set; }
        public TimeSpan SyncInterval { get; set; }
        public DateTime LastSync { get; set; }
        public string Status { get; set; }
    }
}
