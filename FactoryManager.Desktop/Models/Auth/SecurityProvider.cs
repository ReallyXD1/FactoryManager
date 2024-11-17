using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Configuration { get; set; }
        public bool IsEnabled { get; set; }
        public int Priority { get; set; }
        public List<string> SupportedFeatures { get; set; }
        public DateTime LastSync { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
