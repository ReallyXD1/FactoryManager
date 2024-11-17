using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityPolicy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Rules { get; set; }
        public bool IsEnabled { get; set; }
        public int Priority { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public string Author { get; set; }
        public List<string> AppliesTo { get; set; }
    }
}
