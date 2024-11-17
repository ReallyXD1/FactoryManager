using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public List<string> Capabilities { get; set; }
        public bool IsDefault { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public int Priority { get; set; }
        public Dictionary<string, object> Restrictions { get; set; }
    }
}
