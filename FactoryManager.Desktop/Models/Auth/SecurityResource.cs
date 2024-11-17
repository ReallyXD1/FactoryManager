using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public Dictionary<string, object> AccessRules { get; set; }
        public bool IsProtected { get; set; }
        public List<string> Tags { get; set; }
        public string Owner { get; set; }
        public DateTime CreatedAt { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
