using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityConfiguration
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime LastModified { get; set; }
        public string Environment { get; set; }
        public List<string> AppliesTo { get; set; }
        public int Version { get; set; }
        public Dictionary<string, object> DefaultValues { get; set; }
        public List<string> RequiredFeatures { get; set; }
    }
}
