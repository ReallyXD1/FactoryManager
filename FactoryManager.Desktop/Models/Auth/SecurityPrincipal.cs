using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityPrincipal
    {
        public int Id { get; set; }
        public string PrincipalType { get; set; }
        public string Identifier { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
        public Dictionary<string, object> Attributes { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public string TenantId { get; set; }
        public Dictionary<string, string> Claims { get; set; }
    }
}
