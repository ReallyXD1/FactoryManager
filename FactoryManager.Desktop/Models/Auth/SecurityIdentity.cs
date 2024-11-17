using System;
using System.Collections.Generic;

namespace FactoryManager.Desktop.Models.Auth
{
    public class SecurityIdentity
    {
        public int Id { get; set; }
        public string IdentityType { get; set; }
        public string Identifier { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public List<string> Roles { get; set; }
        public List<string> Permissions { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime LastVerified { get; set; }
        public string Status { get; set; }
        public Dictionary<string, object> Metadata { get; set; }
    }
}
