using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationRule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResourceType { get; set; }
        public string Action { get; set; }
        public List<string> RequiredRoles { get; set; }
        public List<string> RequiredPermissions { get; set; }
        public Dictionary<string, object> Conditions { get; set; }
        public bool IsEnabled { get; set; }
        public int Priority { get; set; }
        public string Effect { get; set; }
        public DateTime CreatedAt { get; set; }
        public Dictionary<string, string> Variables { get; set; }
    }
}
