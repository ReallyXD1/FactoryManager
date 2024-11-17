using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityTemplate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public Dictionary<string, object> Parameters { get; set; }
        public bool IsActive { get; set; }
        public string Version { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> Tags { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
