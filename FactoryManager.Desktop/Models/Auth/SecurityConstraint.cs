using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityConstraint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Rules { get; set; }
        public List<string> AppliesTo { get; set; }
        public bool IsEnforced { get; set; }
        public int Priority { get; set; }
        public string Action { get; set; }
        public Dictionary<string, string> Parameters { get; set; }
        public DateTime LastModified { get; set; }
    }
}
