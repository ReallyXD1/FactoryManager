using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityZone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> AllowedIpRanges { get; set; }
        public List<string> AllowedCountries { get; set; }
        public Dictionary<string, object> SecurityPolicies { get; set; }
        public List<string> RequiredAuthMethods { get; set; }
        public int TrustLevel { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
