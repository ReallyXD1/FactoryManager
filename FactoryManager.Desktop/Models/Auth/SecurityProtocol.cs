using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityProtocol
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public bool IsEnabled { get; set; }
        public List<string> SupportedOperations { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public int Priority { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Status { get; set; }
    }
}
