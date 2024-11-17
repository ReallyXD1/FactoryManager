using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityAccess
    {
        public int Id { get; set; }
        public string ResourceId { get; set; }
        public string PrincipalId { get; set; }
        public List<string> Permissions { get; set; }
        public DateTime GrantedAt { get; set; }
        public DateTime ExpiresAt { get; set; }
        public string GrantedBy { get; set; }
        public bool IsActive { get; set; }
        public Dictionary<string, object> Conditions { get; set; }
        public int Priority { get; set; }
    }
}
