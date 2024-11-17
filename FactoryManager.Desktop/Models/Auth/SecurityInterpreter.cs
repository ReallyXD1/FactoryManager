using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityInterpreter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public Dictionary<string, object> Grammar { get; set; }
        public List<string> Keywords { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastUsed { get; set; }
        public Dictionary<string, object> Context { get; set; }
        public string Version { get; set; }
        public List<string> SupportedOperations { get; set; }
    }
}
