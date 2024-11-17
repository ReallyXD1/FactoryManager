using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityIdentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Dictionary<string, object> Claims { get; set; }
        public List<string> Roles { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastAuthenticated { get; set; }
        public Dictionary<string, object> Properties { get; set; }
        public string Provider { get; set; }
    }
}
