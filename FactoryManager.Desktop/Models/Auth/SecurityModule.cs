using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityModule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Features { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public bool IsEnabled { get; set; }
        public Version Version { get; set; }
        public List<string> Dependencies { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Status { get; set; }
    }
}
