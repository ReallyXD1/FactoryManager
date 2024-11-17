using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class AuthorizationGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<string> Members { get; set; }
        public List<string> Permissions { get; set; }
        public Dictionary<string, object> Policies { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Priority { get; set; }
        public string Category { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
