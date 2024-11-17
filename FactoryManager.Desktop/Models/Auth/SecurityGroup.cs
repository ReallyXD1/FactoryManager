using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Members { get; set; }
        public Dictionary<string, object> Permissions { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Owner { get; set; }
        public int Priority { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
    }
}
