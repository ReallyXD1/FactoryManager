using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAggregate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Components { get; set; }
        public Dictionary<string, object> Rules { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUpdated { get; set; }
        public string Owner { get; set; }
        public int Version { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public List<string> Dependencies { get; set; }
    }
}
