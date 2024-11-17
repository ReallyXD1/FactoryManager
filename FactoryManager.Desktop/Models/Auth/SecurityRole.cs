using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Permissions { get; set; }
        public int Level { get; set; }
        public bool IsSystem { get; set; }
        public DateTime CreatedAt { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
        public List<string> InheritedRoles { get; set; }
        public Dictionary<string, object> Restrictions { get; set; }
    }
}
