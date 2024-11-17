using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityBundle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Components { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public string Version { get; set; }
        public bool IsEnabled { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Author { get; set; }
        public List<string> Tags { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
