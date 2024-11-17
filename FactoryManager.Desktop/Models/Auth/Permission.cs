using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<string> RequiredRoles { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public string ResourceType { get; set; }
        public List<string> Actions { get; set; }
        public bool IsSystem { get; set; }
        public int Priority { get; set; }
    }
}
