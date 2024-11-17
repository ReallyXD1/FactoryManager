using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityRegistry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Dictionary<string, object> Entries { get; set; }
        public DateTime LastModified { get; set; }
        public string ModifiedBy { get; set; }
        public bool IsLocked { get; set; }
        public List<string> Tags { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public int Version { get; set; }
    }
}
