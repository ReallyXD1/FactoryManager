using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityFacade
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Operations { get; set; }
        public Dictionary<string, object> Implementation { get; set; }
        public bool IsPublic { get; set; }
        public string Version { get; set; }
        public Dictionary<string, object> Cache { get; set; }
        public List<string> Dependencies { get; set; }
        public DateTime LastAccessed { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
