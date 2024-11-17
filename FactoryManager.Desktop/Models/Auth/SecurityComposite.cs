using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityComposite
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Components { get; set; }
        public Dictionary<string, object> Relations { get; set; }
        public string Type { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Owner { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public int Version { get; set; }
    }
}
