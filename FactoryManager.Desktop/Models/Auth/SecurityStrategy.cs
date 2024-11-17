using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityStrategy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Implementation { get; set; }
        public List<string> ApplicableContexts { get; set; }
        public bool IsDefault { get; set; }
        public int Priority { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
    }
}
