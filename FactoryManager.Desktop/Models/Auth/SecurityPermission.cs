using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityPermission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<string> RequiredRoles { get; set; }
        public int SecurityLevel { get; set; }
        public bool IsSystemPermission { get; set; }
        public Dictionary<string, object> Constraints { get; set; }
        public List<string> DependentPermissions { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
