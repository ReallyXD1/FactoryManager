using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAdapter
    {
        public int Id { get; set; }
        public string AdapterType { get; set; }
        public string SourceFormat { get; set; }
        public string TargetFormat { get; set; }
        public Dictionary<string, object> Mappings { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> SupportedOperations { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public DateTime LastUsed { get; set; }
        public int Version { get; set; }
    }
}
