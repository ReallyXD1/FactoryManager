using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityVault
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Secrets { get; set; }
        public List<string> AccessPolicies { get; set; }
        public bool IsSealed { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Owner { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public int Version { get; set; }
    }
}
